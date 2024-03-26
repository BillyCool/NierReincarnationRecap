namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserMovie
{
    public long UserId { get; set; }

    public int MovieId { get; set; }

    public long LatestViewedDatetime { get; set; }

    public long LatestVersion { get; set; }
}
