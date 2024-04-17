using NierReincarnationRecap.Business;
using NierReincarnationRecap.Model;
using NierReincarnationRecap.Model.Dto;
using NierReincarnationRecap.Model.Enums;
using System.Text;
using System.Text.Json;

namespace NierReincarnationRecap.SaveData;

public static class DataUploader
{
    public static async Task UploadUserDataAsync(DarkUserMemoryDatabase darkUserMemoryDatabase)
    {
        try
        {
            // Collect user data
            UserDataDto userData = GetUserData(darkUserMemoryDatabase);
            string userDataJson = JsonSerializer.Serialize(userData);

            // Upload user data
            using HttpClient httpClient = new();
            var res = await httpClient.PostAsync("https://nierreincarnationrecap.com/api/submit-user-data",
                new StringContent(userDataJson, Encoding.UTF8, "application/json"));

            if (res.IsSuccessStatusCode)
            {
                var recapUrl = await res.Content.ReadAsStringAsync();
                Console.WriteLine($"Your recap is ready at: {recapUrl}");
            }
            else
            {
                Console.WriteLine("Data upload failed");
            }
        }
        catch
        {
            Console.WriteLine("Data upload failed");
        }
    }

    private static UserDataDto GetUserData(DarkUserMemoryDatabase darkUserMemoryDatabase)
    {
        return new UserDataDto()
        {
            Region = Variables.Region,
            UserId = darkUserMemoryDatabase.EntityIUserTable[0].UserId,
            PlayerId = darkUserMemoryDatabase.EntityIUserTable[0].PlayerId,
            RegisterDatetime = darkUserMemoryDatabase.EntityIUserTable[0].RegisterDatetime,
            Name = darkUserMemoryDatabase.EntityIUserProfileTable[0].Name,
            FavoriteCostumeId = darkUserMemoryDatabase.EntityIUserProfileTable[0].FavoriteCostumeId,
            TotalLoginCount = darkUserMemoryDatabase.EntityIUserLoginTable[0].TotalLoginCount,
            Level = darkUserMemoryDatabase.EntityIUserStatusTable[0].Level,
            MaxForce = darkUserMemoryDatabase.EntityIUserMissionTable.Find(x => x.MissionId == 400120)?.ProgressValue,
            DistanceWalked = darkUserMemoryDatabase.EntityIUserMissionTable.Find(x => x.MissionId == 410013)?.ProgressValue,
            CostumeCount = darkUserMemoryDatabase.EntityIUserCostumeTable.DistinctBy(x => x.CostumeId).Count(x => x.CostumeId != 10112) + 1, // The Girl of Light
            WeaponCount = GetUniqueWeaponIdCount(darkUserMemoryDatabase),
            CompanionCount = darkUserMemoryDatabase.EntityIUserCompanionTable.Count,
            MemoirCount = darkUserMemoryDatabase.EntityIUserPartsGroupNoteTable.DistinctBy(x => x.PartsGroupId).Count(),
            DebrisCount = darkUserMemoryDatabase.EntityIUserThoughtTable.DistinctBy(x => x.ThoughtId).Count(),
            AwakeningCount = darkUserMemoryDatabase.EntityIUserCostumeTable.Sum(x => x.AwakenCount),
            ArenaRankings = darkUserMemoryDatabase.EntityIUserPvpWeeklyResultTable.GroupBy(x => x.PvpSeasonId)
                .Select(x => x.OrderBy(y => y.PvpWeeklyVersion).Last())
                .Select(x => new ArenaRankingDto()
                {
                    Season = PvpSeasonIdToNum(x.PvpSeasonId),
                    Rank = x.FinalRank
                }).ToList(),
            SubjugationRankings = darkUserMemoryDatabase.EntityIUserBigHuntScheduleMaxScoreTable
                .ConvertAll(x => new SubjugationRankingDto()
                {
                    Season = SubjugationSeasonIdToNum(x.BigHuntScheduleId),
                    AttributeType = SubjugationBossIdToAttributeType(x.BigHuntBossId),
                    Score = x.MaxScore
                }),
            ExplorationRankings = darkUserMemoryDatabase.EntityIUserExploreScoreTable.ConvertAll(x => new ExplorationRankingDto()
            {
                ExplorationType = ExplorationIdToExplorationType(x.ExploreId),
                DifficultyType = ExplorationIdToDifficultyTypeType(x.ExploreId),
                Score = x.MaxScore
            })
        };
    }

    private static int GetUniqueWeaponIdCount(DarkUserMemoryDatabase darkUserMemoryDatabase)
    {
        List<int> weaponIds = [.. darkUserMemoryDatabase.EntityIUserWeaponNoteTable
            .Select(x => x.WeaponId)
            .Distinct()
            .OrderBy(x => x)];

        foreach (int weaponId in weaponIds.ToList())
        {
            if (weaponIds.Contains(weaponId + 1))
            {
                weaponIds.Remove(weaponId);
            }
        }

        return weaponIds.Count;
    }

    private static int PvpSeasonIdToNum(int pvpSeasonId) => pvpSeasonId is 202001 or 202002 ? 1 : pvpSeasonId - 202001;

    private static int SubjugationSeasonIdToNum(int bigHuntScheduleId) => bigHuntScheduleId - 10;

    private static AttributeType SubjugationBossIdToAttributeType(int bigHuntBossId)
    {
        return bigHuntBossId switch
        {
            1 => AttributeType.FIRE,
            2 => AttributeType.WATER,
            3 => AttributeType.WIND,
            4 => AttributeType.LIGHT,
            5 => AttributeType.DARK,
            _ => AttributeType.UNKNOWN,
        };
    }

    private static ExplorationType ExplorationIdToExplorationType(int exploreId) => exploreId is 1 or 11 ? ExplorationType.Shooting : ExplorationType.FlyingMama;

    private static ExplorationDifficultyType ExplorationIdToDifficultyTypeType(int exploreId) => exploreId <= 10 ? ExplorationDifficultyType.Normal : ExplorationDifficultyType.Hard;
}
