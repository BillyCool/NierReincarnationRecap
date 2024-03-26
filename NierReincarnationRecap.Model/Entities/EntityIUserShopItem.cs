namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserShopItem
{
    public long UserId { get; set; }

    public int ShopItemId { get; set; }

    public int BoughtCount { get; set; }

    public long LatestBoughtCountChangedDatetime { get; set; }

    public long LatestVersion { get; set; }
}
