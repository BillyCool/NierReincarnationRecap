namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserSideStoryQuestSceneProgressStatus
{
    public long UserId { get; set; }

    public int CurrentSideStoryQuestId { get; set; }

    public int CurrentSideStoryQuestSceneId { get; set; }

    public long LatestVersion { get; set; }
}
