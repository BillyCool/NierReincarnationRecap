namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserShopReplaceableLineup
{
    public long UserId { get; set; }

    public int SlotNumber { get; set; }

    public int ShopItemId { get; set; }

    public long LatestVersion { get; set; }
}
