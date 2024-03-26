using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Model.Dto;

public class ExplorationRankingDto
{
    public ExplorationType ExplorationType { get; init; }

    public DifficultyType DifficultyType { get; init; }

    public int Score { get; init; }
}

public enum ExplorationType
{
    Shooting,
    FlyingMama
}
