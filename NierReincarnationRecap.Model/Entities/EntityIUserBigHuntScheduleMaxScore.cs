namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserBigHuntScheduleMaxScore
{
    public long UserId { get; set; }

    public int BigHuntScheduleId { get; set; }

    public int BigHuntBossId { get; set; }

    public long MaxScore { get; set; }

    public long MaxScoreUpdateDatetime { get; set; }

    public long LatestVersion { get; set; }
}
