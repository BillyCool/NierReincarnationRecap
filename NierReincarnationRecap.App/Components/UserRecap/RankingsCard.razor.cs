using Microsoft.AspNetCore.Components;
using NierReincarnationRecap.Model.Dto;
using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.App.Components.UserRecap;

public partial class RankingsCard
{
    [CascadingParameter] public UserRecapDataDto UserRecapData { get; set; } = null!;

    private List<ArenaRankingDto> ArenaRankings => [.. UserRecapData.ArenaRankings.Where(x => x.Rank > 0).OrderBy(x => x.Season)];

    private List<SubjugationRankingDto> SubjugationRankings => [.. UserRecapData.SubjugationRankings.Where(x => x.Score > 0).OrderBy(x => x.Season)];

    public string HighestArenaRank => ArenaRankings.Count > 0 ? ArenaRankings.MinBy(x => x.Rank)!.Rank.ToString() : "-";

    public string AverageArenaRank => ArenaRankings.Count > 0 ? Math.Round(ArenaRankings.Average(x => x.Rank)).ToString() : "-";

    public string HighestSubjugationRank => SubjugationRankings.Count > 0 ? SubjugationRankings.MaxBy(x => x.Score)!.Score.ToSubjugationToRank() : "-";

    public string AverageSubjugationRank => SubjugationRankings.Count > 0 ? ((long)Math.Round(SubjugationRankings.Average(x => x.Score))).ToSubjugationToRank() : "-";

    public string BestSubjugationElement => SubjugationRankings.Count > 0 ? SubjugationRankings.GroupBy(x => x.AttributeType).MaxBy(x => x.Average(y => y.Score))!.First().AttributeType.GetDisplayName() : "-";

    public string HighestShootingNormalScore => UserRecapData!.ExplorationRankings.Find(x => x.ExplorationType == ExplorationType.Shooting &&
        x.DifficultyType == DifficultyType.NORMAL)?.Score.ToString() ?? "-";

    public string HighestShootingHardScore => UserRecapData!.ExplorationRankings.Find(x => x.ExplorationType == ExplorationType.Shooting &&
        x.DifficultyType == DifficultyType.HARD)?.Score.ToString() ?? "-";

    public string HighestFlyingMamaNormalScore => UserRecapData!.ExplorationRankings.Find(x => x.ExplorationType == ExplorationType.FlyingMama &&
        x.DifficultyType == DifficultyType.NORMAL)?.Score.ToString() ?? "-";

    public string HighestFlyingMamaHardScore => UserRecapData!.ExplorationRankings.Find(x => x.ExplorationType == ExplorationType.FlyingMama &&
        x.DifficultyType == DifficultyType.HARD)?.Score.ToString() ?? "-";
}
