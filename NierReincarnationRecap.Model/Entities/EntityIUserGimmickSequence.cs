namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserGimmickSequence
{
    public long UserId { get; set; }

    public int GimmickSequenceScheduleId { get; set; }

    public int GimmickSequenceId { get; set; }

    public bool IsGimmickSequenceCleared { get; set; }

    public long ClearDatetime { get; set; }

    public long LatestVersion { get; set; }
}
