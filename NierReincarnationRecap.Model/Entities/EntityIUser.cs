using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Model.Entities;

public class EntityIUser
{
    public long UserId { get; set; }

    public long PlayerId { get; set; }

    public int OsType { get; set; }

    public PlatformType PlatformType { get; set; }

    public int UserRestrictionType { get; set; }

    public long RegisterDatetime { get; set; }

    public long GameStartDatetime { get; set; }

    public long LatestVersion { get; set; }
}
