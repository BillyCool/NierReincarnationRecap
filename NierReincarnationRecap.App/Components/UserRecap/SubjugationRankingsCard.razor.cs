using Microsoft.AspNetCore.Components;
using MudBlazor;
using NierReincarnationRecap.Model.Dto;
using NierReincarnationRecap.Model.Enums;
using System.Diagnostics.CodeAnalysis;

namespace NierReincarnationRecap.App.Components.UserRecap;

public partial class SubjugationRankingsCard
{
    [CascadingParameter] public UserRecapDataDto UserRecapData { get; set; } = null!;

    private List<SubjugationRankingDto> SubjugationRankings => [.. UserRecapData.SubjugationRankings.Where(x => x.Score > 0).OrderBy(x => x.Season)];

    public ChartOptions Options = new() { InterpolationOption = InterpolationOption.NaturalSpline };

    public List<ChartSeries> Series =>
    [
        new ChartSeries() { Name = AttributeType.FIRE.GetDisplayName(), Data = SubjugationRankings.Where(x => x.AttributeType == AttributeType.FIRE).Select(x => (double)x.Score).ToArray() },
        new ChartSeries() { Name = AttributeType.WATER.GetDisplayName(), Data = SubjugationRankings.Where(x => x.AttributeType == AttributeType.WATER).Select(x => (double)x.Score).ToArray() },
        new ChartSeries() { Name = AttributeType.WIND.GetDisplayName(), Data = SubjugationRankings.Where(x => x.AttributeType == AttributeType.WIND).Select(x => (double)x.Score).ToArray() },
        new ChartSeries() { Name = AttributeType.LIGHT.GetDisplayName(), Data = SubjugationRankings.Where(x => x.AttributeType == AttributeType.LIGHT).Select(x => (double)x.Score).ToArray() },
        new ChartSeries() { Name = AttributeType.DARK.GetDisplayName(), Data = SubjugationRankings.Where(x => x.AttributeType == AttributeType.DARK).Select(x => (double)x.Score).ToArray() },
    ];

    public string[] XAxisLabels => SubjugationRankings.GroupBy(x => x.AttributeType).MaxBy(x => x.Count())?.Select(x => $"S{x.Season}").ToArray() ?? [];
}
