namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserGimmick
{
    public long UserId { get; set; }

    public int GimmickSequenceScheduleId { get; set; }

    public int GimmickSequenceId { get; set; }

    public int GimmickId { get; set; }

    public bool IsGimmickCleared { get; set; }

    public long StartDatetime { get; set; }

    public long LatestVersion { get; set; }
}
