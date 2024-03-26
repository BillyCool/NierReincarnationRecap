namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserBigHuntProgressStatus
{
    public long UserId { get; set; }

    public int CurrentBigHuntBossQuestId { get; set; }

    public int CurrentBigHuntQuestId { get; set; }

    public int CurrentQuestSceneId { get; set; }

    public bool IsDryRun { get; set; }

    public long LatestVersion { get; set; }
}
