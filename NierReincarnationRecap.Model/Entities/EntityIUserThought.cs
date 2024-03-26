namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserThought
{
    public long UserId { get; set; }

    public string UserThoughtUuid { get; set; }

    public int ThoughtId { get; set; }

    public long AcquisitionDatetime { get; set; }

    public long LatestVersion { get; set; }
}
