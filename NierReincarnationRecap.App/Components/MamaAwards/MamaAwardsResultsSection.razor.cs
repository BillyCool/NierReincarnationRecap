using Microsoft.AspNetCore.Components;
using NierReincarnationRecap.Model.ViewModel;

namespace NierReincarnationRecap.App.Components.MamaAwards;

public partial class MamaAwardsResultsSection
{
    [Parameter][EditorRequired] public List<Award> Awards { get; set; }
}
