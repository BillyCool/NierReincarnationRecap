using NierReincarnationRecap.Business.Network;
using NierReincarnationRecap.Business.Proto;
using NierReincarnationRecap.Business;
using System.Text.Json;
using Google.Protobuf.WellKnownTypes;
using System.IO.Compression;
using NierReincarnationRecap.Model;
using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.SaveData;

public static class Program
{
    private static int BridgeGameId => Variables.Region == SystemRegion.GL ? 288 : 255;

    private static string PackageName => Variables.Region == SystemRegion.GL ? "com.square_enix.android_googleplay.nierspww" : "com.square_enix.android_googleplay.nierspjp";

    private static readonly DarkClient DarkClient = new();

    private static readonly string Uuid = Guid.NewGuid().ToString();

    private static string Signature { get; set; } = null!;

    private static readonly JsonSerializerOptions JsonSerializerOptions = new(JsonSerializerDefaults.Web);

    public static async Task Main(string[] _)
    {
        try
        {
            await RunInternalAsync();
        }
        catch (Exception ex)
        {
            ShowErrorAndExit(ex);
        }
    }

    private static async Task RunInternalAsync()
    {
        // Show region select
        ShowRegionSelect();

        // Get backup token
        string backupToken = await GetBackupTokenAsync();

        // Transfer user account
        await TransferUserAsync(backupToken);

        // Get Android args
        await GetAndroidArgsAsync();

        // Authenticate user
        await AuthenticateUserAsync();

        // Get user data table names
        var userDataTableNames = await GetUserDataTableNamesAsync();

        // Get user data
        DarkUserMemoryDatabase darkUserMemoryDatabase = await GetUserDataAsync(userDataTableNames);

        // Export user data
        ExportUserData(darkUserMemoryDatabase);

        // Confirm export
        Console.WriteLine();
        Console.WriteLine("Data exported in userdata.zip.");

        // Optionally upload data
        if (ShouldUploadUserData())
        {
            Console.WriteLine("Uploading...");
            await DataUploader.UploadUserDataAsync(darkUserMemoryDatabase);
        }

        Console.WriteLine();
        Console.WriteLine("All done. Press any key to exit.");
        Console.ReadKey();
    }

    private static void ShowRegionSelect()
    {
        Console.WriteLine("Choose your region:");
        Console.WriteLine("1. Global");
        Console.WriteLine("2. Japan");

        switch (Console.ReadLine())
        {
            case "1":
                Variables.Region = SystemRegion.GL;
                break;

            case "2":
                Variables.Region = SystemRegion.JP;
                break;

            default:
                ShowErrorAndExit();
                break;
        }
    }

    private static bool ShouldUploadUserData()
    {
        Console.WriteLine();
        Console.WriteLine("Do you wish to upload your data to the server on the moon?");
        Console.WriteLine("1. Yes");
        Console.WriteLine("2. No");

        return Console.ReadLine() switch
        {
            "1" => true,
            _ => false,
        };
    }

    private static void ShowErrorAndExit(Exception? ex = null)
    {
        Console.WriteLine("Something went wrong!");
        if (ex is not null)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Environment.Exit(0);
    }

    private static async Task<string> GetBackupTokenAsync()
    {
        var backupTokenResponse = await DarkClient.GetBackupTokenAsync(new GetBackupTokenRequest { Uuid = Uuid });

        if (backupTokenResponse is null)
        {
            ShowErrorAndExit();
        }

        return backupTokenResponse!.BackupToken;
    }

    private static async Task TransferUserAsync(string backupToken)
    {
        string transferUrl = $"https://psg.sqex-bridge.jp/ntv/{BridgeGameId}/update/top?type=2&token={backupToken}";

        Console.WriteLine();
        Console.WriteLine($"Login to your account at: {transferUrl}");
        Console.WriteLine("Once you login and confirm transfer, press ENTER to continue");
        Console.ReadKey();
        Console.WriteLine("Please wait...");

        var transferUserResponse = await DarkClient.TransferUserAsync(new TransferUserRequest { Uuid = Uuid });

        if (transferUserResponse is null)
        {
            ShowErrorAndExit();
        }

        Variables.UserId = transferUserResponse!.UserId;
        Signature = transferUserResponse!.Signature;
    }

    private static async Task GetAndroidArgsAsync()
    {
        var androidArgsResponse = await DarkClient.GetAndroidArgsAsync(new GetAndroidArgsRequest
        {
            Uuid = Uuid,
            Signature = Signature,
            PackageName = PackageName
        });

        if (androidArgsResponse is null)
        {
            ShowErrorAndExit();
        }
    }

    private static async Task AuthenticateUserAsync()
    {
        List<Tr> trList = [];
        trList.Add(new Tr("lr", null!));
        trList.Add(new Tr("ijb", false));
        trList.Add(new Tr("hig", false));
        trList.Add(new Tr("acs", string.Empty));
        trList.Add(new Tr("per", false));
        trList.Add(new Tr("imu", false));
        trList.Add(new Tr("ir", false));
        trList.Add(new Tr("ia", false));
        trList.Add(new Tr("ms", Array.Empty<string>()));
        trList.Add(new Tr("ics", string.Empty));

        var authUserResponse = await DarkClient.AuthAsync(new AuthUserRequest
        {
            Uuid = Uuid,
            Signature = Signature,
            AdvertisingId = Variables.AdvertisingId ?? string.Empty,
            IsTrackingEnabled = false,
            Tr = JsonSerializer.Serialize(trList, JsonSerializerOptions)
        });

        if (authUserResponse is null)
        {
            ShowErrorAndExit();
        }

        Variables.SessionKey = authUserResponse!.SessionKey;
        Variables.SessionExpire = authUserResponse!.ExpireDatetime.Seconds;
    }

    private static async Task<List<string>> GetUserDataTableNamesAsync()
    {
        var userDataGetNameResponseV2 = await DarkClient.GetUserDataNameV2Async(new Empty());

        if (userDataGetNameResponseV2 is null)
        {
            ShowErrorAndExit();
        }

        return userDataGetNameResponseV2!.TableNameList.SelectMany(x => x.TableName.ToList()).ToList();
    }

    private static async Task<DarkUserMemoryDatabase> GetUserDataAsync(List<string> userDataTableNames)
    {
        var userDataGetResponse = await DarkClient.GetUserDataAsync(new UserDataGetRequest
        {
            TableName = { userDataTableNames }
        });

        if (userDataGetResponse is null)
        {
            ShowErrorAndExit();
        }

        DarkUserMemoryDatabase darkUserMemoryDatabase = new();
        var properties = darkUserMemoryDatabase.GetType().GetProperties();
        var args = properties[0].PropertyType.GetGenericArguments()[0].Name;

        foreach (var kvp in userDataGetResponse!.UserDataJson)
        {
            string key = $"Entity{kvp.Key}";

            var property = Array.Find(properties, x => x.PropertyType.IsGenericType && x.PropertyType.GetGenericArguments().Any(y => y.Name == key));

            if (property is null) continue;

            object deserializedValue = JsonSerializer.Deserialize(kvp.Value, property.PropertyType, JsonSerializerOptions)!;
            property.SetValue(darkUserMemoryDatabase, deserializedValue);
        }

        return darkUserMemoryDatabase;
    }

    private static void ExportUserData(DarkUserMemoryDatabase darkUserMemoryDatabase)
    {
        using FileStream zipToOpen = new("userdata.zip", FileMode.Create);
        using ZipArchive archive = new(zipToOpen, ZipArchiveMode.Create);

        foreach (var property in typeof(DarkUserMemoryDatabase).GetProperties())
        {
            string fileName = $"{property.Name}.json";
            string fileContent = JsonSerializer.Serialize(property.GetValue(darkUserMemoryDatabase, null), new JsonSerializerOptions()
            {
                WriteIndented = true,
            });

            var entry = archive.CreateEntry(fileName, CompressionLevel.Fastest);

            using StreamWriter writer = new(entry.Open());
            writer.Write(fileContent);
        }
    }
}

public record Tr(string Ti, object Bo);
