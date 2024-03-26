namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserExplore
{
    public long UserId { get; set; }

    public bool IsUseExploreTicket { get; set; }

    public int PlayingExploreId { get; set; }

    public long LatestPlayDatetime { get; set; }

    public long LatestVersion { get; set; }
}
