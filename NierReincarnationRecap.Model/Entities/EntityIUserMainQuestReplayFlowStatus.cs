namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserMainQuestReplayFlowStatus
{
    public long UserId { get; set; }

    public int CurrentHeadQuestSceneId { get; set; }

    public int CurrentQuestSceneId { get; set; }

    public long LatestVersion { get; set; }
}
