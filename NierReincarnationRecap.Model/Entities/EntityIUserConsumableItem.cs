namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserConsumableItem
{
    public long UserId { get; set; }

    public int ConsumableItemId { get; set; }

    public int Count { get; set; }

    public long FirstAcquisitionDatetime { get; set; }

    public long LatestVersion { get; set; }
}
