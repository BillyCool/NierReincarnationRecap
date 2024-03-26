using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Model.Dto;

public class UserDataDto
{
    public SystemRegion Region { get; init; }

    public required long UserId { get; init; }

    public required long PlayerId { get; init; }

    public required long RegisterDatetime { get; init; }

    public required string Name { get; init; }

    public required int FavoriteCostumeId { get; init; }

    public required int TotalLoginCount { get; init; }

    public required int Level { get; init; }

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
