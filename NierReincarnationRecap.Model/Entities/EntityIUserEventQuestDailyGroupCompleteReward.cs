namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserEventQuestDailyGroupCompleteReward
{
    public long UserId { get; set; }

    public int LastRewardReceiveEventQuestDailyGroupId { get; set; }

    public long LastRewardReceiveDatetime { get; set; }

    public long LatestVersion { get; set; }
}
