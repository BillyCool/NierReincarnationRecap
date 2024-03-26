namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserBigHuntStatus
{
    public long UserId { get; set; }

    public int BigHuntBossQuestId { get; set; }

    public int DailyChallengeCount { get; set; }

    public long LatestChallengeDatetime { get; set; }

    public long LatestVersion { get; set; }
}
