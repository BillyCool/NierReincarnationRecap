namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserEventQuestTowerAccumulationReward
{
    public long UserId { get; set; }

    public int EventQuestChapterId { get; set; }

    public int LatestRewardReceiveQuestMissionClearCount { get; set; }

    public long LatestVersion { get; set; }
}
