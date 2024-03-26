namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserSetting
{
    public long UserId { get; set; }

    public bool IsNotifyPurchaseAlert { get; set; }

    public long LatestVersion { get; set; }
}
