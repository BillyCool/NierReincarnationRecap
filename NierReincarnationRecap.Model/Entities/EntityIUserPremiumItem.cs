namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserPremiumItem
{
    public long UserId { get; set; }

    public int PremiumItemId { get; set; }

    public long AcquisitionDatetime { get; set; }

    public long LatestVersion { get; set; }
}
