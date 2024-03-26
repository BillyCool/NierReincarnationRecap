namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserContentsStory
{
    public long UserId { get; set; }

    public int ContentsStoryId { get; set; }

    public long PlayDatetime { get; set; }

    public long LatestVersion { get; set; }
}
