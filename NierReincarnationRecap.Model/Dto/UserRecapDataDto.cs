using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Model.Dto;

public class UserRecapDataDto
{
    public SystemRegion Region { get; init; }

    public DateTimeOffset RegisterDatetime { get; init; }

    public string Name { get; init; } = null!;

    public int FavoriteCostumeId { get; init; }

    public int TotalLoginCount { get; init; }

    public int Level { get; init; }

    public int? MaxForce { get; init; }

    public int? DistanceWalked { get; init; }

    public int CostumeCount { get; init; }

    public int WeaponCount { get; init; }

    public int CompanionCount { get; init; }

    public int MemoirCount { get; init; }

    public int DebrisCount { get; init; }

    public int AwakeningCount { get; init; }

    public List<ArenaRankingDto> ArenaRankings { get; init; } = [];

    public List<SubjugationRankingDto> SubjugationRankings { get; init; } = [];

    public List<ExplorationRankingDto> ExplorationRankings { get; init; } = [];
}
