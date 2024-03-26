namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserExtraQuestProgressStatus
{
    public long UserId { get; set; }

    public int CurrentQuestId { get; set; }

    public int CurrentQuestSceneId { get; set; }

    public int HeadQuestSceneId { get; set; }

    public long LatestVersion { get; set; }
}
