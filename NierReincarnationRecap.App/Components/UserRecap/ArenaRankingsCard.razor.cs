using Microsoft.AspNetCore.Components;
using MudBlazor;
using NierReincarnationRecap.Model.Dto;

namespace NierReincarnationRecap.App.Components.UserRecap;

public partial class ArenaRankingsCard
{
    [CascadingParameter] public UserRecapDataDto UserRecapData { get; set; } = null!;

    private List<ArenaRankingDto> ArenaRankings => [.. UserRecapData.ArenaRankings.Where(x => x.Rank > 0).OrderBy(x => x.Season)];

    private int MagicValue => ArenaRankings.Count / 8;

    public ChartOptions Options = new();

    public List<ChartSeries> Series =>
    [
        new ChartSeries() { Name = $"{ArenaRankings.Count} seasons", Data = ArenaRankings.Select(x => (double)x.Rank).ToArray() },
    ];

    public string[] XAxisLabels => ArenaRankings.Select((x, i) => i % MagicValue == 0 ? $"S{x.Season}" : string.Empty).ToArray();
}
