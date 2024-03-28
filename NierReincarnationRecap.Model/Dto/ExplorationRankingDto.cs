namespace NierReincarnationRecap.Model.Dto;

public class ExplorationRankingDto
{
    public ExplorationType ExplorationType { get; init; }

    public ExplorationDifficultyType DifficultyType { get; init; }

    public int Score { get; init; }
}

public enum ExplorationType
{
    Shooting,
    FlyingMama
}

public enum ExplorationDifficultyType
{
    Hard = 1,
    Normal = 2
}