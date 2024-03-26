namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserShopReplaceable
{
    public long UserId { get; set; }

    public int LineupUpdateCount { get; set; }

    public long LatestLineupUpdateDatetime { get; set; }

    public long LatestVersion { get; set; }
}
