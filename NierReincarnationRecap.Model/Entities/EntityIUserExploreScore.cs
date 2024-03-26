namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserExploreScore
{
    public long UserId { get; set; }

    public int ExploreId { get; set; }

    public int MaxScore { get; set; }

    public long MaxScoreUpdateDatetime { get; set; }

    public long LatestVersion { get; set; }
}
