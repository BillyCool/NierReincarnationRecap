namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserOmikuji
{
    public long UserId { get; set; }

    public int OmikujiId { get; set; }

    public long LatestDrawDatetime { get; set; }

    public long LatestVersion { get; set; }
}
