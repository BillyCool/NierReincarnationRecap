namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserPvpStatus
{
    public long UserId { get; set; }

    public int StaminaMilliValue { get; set; }

    public long StaminaUpdateDatetime { get; set; }

    public int LatestRewardReceivePvpSeasonId { get; set; }

    public long LatestRewardReceivePvpWeeklyVersion { get; set; }

    public int WinStreakCount { get; set; }

    public long WinStreakCountUpdateDatetime { get; set; }

    public long LatestVersion { get; set; }
}
