namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserBigHuntWeeklyStatus
{
    public long UserId { get; set; }

    public long BigHuntWeeklyVersion { get; set; }

    public bool IsReceivedWeeklyReward { get; set; }

    public long LatestVersion { get; set; }
}
