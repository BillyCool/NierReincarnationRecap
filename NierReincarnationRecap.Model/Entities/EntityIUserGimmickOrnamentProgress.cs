namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserGimmickOrnamentProgress
{
    public long UserId { get; set; }

    public int GimmickSequenceScheduleId { get; set; }

    public int GimmickSequenceId { get; set; }

    public int GimmickId { get; set; }

    public int GimmickOrnamentIndex { get; set; }

    public int ProgressValueBit { get; set; }

    public long BaseDatetime { get; set; }

    public long LatestVersion { get; set; }
}
