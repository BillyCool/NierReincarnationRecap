namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserMissionPassPoint
{
    public long UserId { get; set; }

    public int MissionPassId { get; set; }

    public int Point { get; set; }

    public int PremiumRewardReceivedLevel { get; set; }

    public int NoPremiumRewardReceivedLevel { get; set; }

    public long LatestVersion { get; set; }
}
