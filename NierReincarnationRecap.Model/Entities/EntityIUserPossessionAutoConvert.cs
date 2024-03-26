using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserPossessionAutoConvert
{
    public long UserId { get; set; }

    public PossessionType PossessionType { get; set; }

    public int PossessionId { get; set; }

    public int FromCount { get; set; }

    public PossessionType ToPossessionType { get; set; }

    public int ToPossessionId { get; set; }

    public int ToCount { get; set; }

    public long ConvertDatetime { get; set; }

    public long LatestVersion { get; set; }
}
