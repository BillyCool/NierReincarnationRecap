using Microsoft.AspNetCore.Components;
using NierReincarnationRecap.Model.ViewModel;

namespace NierReincarnationRecap.App.Components.CommunityAwards;

public partial class CommunityAwardsVotingSection
{
    [Parameter][EditorRequired] public List<Award> Awards { get; set; }

    [Parameter] public string? HeaderImagePath { get; set; }

    [Parameter][EditorRequired] public bool IsVotingEnabled { get; set; }
}
