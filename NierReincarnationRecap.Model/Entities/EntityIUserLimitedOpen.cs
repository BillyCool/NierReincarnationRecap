using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserLimitedOpen
{
    public long UserId { get; set; }

    public LimitedOpenTargetType LimitedOpenTargetType { get; set; }

    public int TargetId { get; set; }

    public long OpenDatetime { get; set; }

    public long CloseDatetime { get; set; }

    public long LatestVersion { get; set; }
}
