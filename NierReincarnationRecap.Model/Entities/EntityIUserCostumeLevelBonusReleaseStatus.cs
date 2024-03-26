namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserCostumeLevelBonusReleaseStatus
{
    public long UserId { get; set; }

    public int CostumeId { get; set; }

    public int LastReleasedBonusLevel { get; set; }

    public int ConfirmedBonusLevel { get; set; }

    public long LatestVersion { get; set; }
}
