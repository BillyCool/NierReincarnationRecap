using Grpc.Core;

namespace NierReincarnationRecap.Business.Network.Interceptors;

public class SetCommonHeaderInterceptor : INetworkInterceptor
{
    private readonly string _appVersion;
    private readonly string _language;
    private readonly string _osVersion;
    private readonly string _deviceName;
    private readonly Random _rand = new();

    private const string kAppVersionHeader = "x-apb-app-version";
    private const string kLanguageHeader = "x-apb-language";
    private const string kOsVersionHeader = "x-apb-os-version";
    private const string kDeviceNameHeader = "x-apb-device-name";
    private const string kOsTypeHeader = "x-apb-os-type";
    private const string kPlatformTypeHeader = "x-apb-platform-type";
    private const string kRequestDateTimeHeader = "x-apb-request-datetime";
    private const string kRequestIdHeader = "x-apb-request-id";
    private const string kUserIdHeader = "x-apb-user-id";
    private const string kSessionKeyHeader = "x-apb-session-key";
    private const string kTokenHeader = "x-apb-token";
    private const string kMasterDataHashHeader = "x-apb-master-data-hash";
    private const string kAdjustIdHeader = "x-adjust-id";
    private const string kDeviceIdHeader = "x-apb-device-id";
    private const string kAdvertisingIdHeader = "x-apb-advertising-id";
    private const string kKeyChainUserIdHeader = "x-apb-keychain-user-id";
    private const string kOsTypeAndroid = "2";
    private const string kPlatformGooglePlayStore = "2";

    public SetCommonHeaderInterceptor()
    {
        _appVersion ??= Constants.AppVersion;
        _language ??= Constants.SystemLanguage;
        _osVersion ??= Constants.OperatingSystem;
        _deviceName ??= Constants.DeviceModel;
    }

    public Task<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, Task<ResponseContext>> next)
    {
        SetCommonHeader(context.Headers);
        return next.Invoke(context);
    }

    private void SetCommonHeader(Metadata headers)
    {
        headers.Add(kAppVersionHeader, _appVersion);
        headers.Add(kLanguageHeader, _language);
        headers.Add(kOsVersionHeader, _osVersion);
        headers.Add(kDeviceNameHeader, _deviceName);
        headers.Add(kDeviceIdHeader, Constants.DeviceUniqueIdentifier);
        headers.Add(kOsTypeHeader, kOsTypeAndroid);
        headers.Add(kPlatformTypeHeader, kPlatformGooglePlayStore);

        headers.Add(kRequestDateTimeHeader, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString());

        headers.Add(kRequestIdHeader, GetRandomLongValue().ToString());

        if (Variables.UserId.HasValue)
        {
            headers.Add(kUserIdHeader, Variables.UserId.Value.ToString());
            headers.Add(kAdvertisingIdHeader, Variables.AdvertisingId ?? string.Empty);
        }

        headers.Add(kSessionKeyHeader, Variables.SessionKey ?? string.Empty);
        headers.Add(kTokenHeader, Variables.Token ?? string.Empty);
        headers.Add(kMasterDataHashHeader, Variables.MasterDataHash ?? string.Empty);

        headers.Add(kAdjustIdHeader, string.Empty);
        headers.Add(kKeyChainUserIdHeader, string.Empty);
    }

    private long GetRandomLongValue() => _rand.Next();
}
