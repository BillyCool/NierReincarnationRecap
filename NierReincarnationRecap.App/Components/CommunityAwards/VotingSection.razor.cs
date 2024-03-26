using Microsoft.AspNetCore.Components;
using NierReincarnationRecap.Model.ViewModel;

namespace NierReincarnationRecap.App.Components.CommunityAwards;

public partial class VotingSection
{
    [Parameter][EditorRequired] public required List<Award> Awards { get; set; }

    [Parameter][EditorRequired] public string? HeaderImagePath { get; set; }
}
