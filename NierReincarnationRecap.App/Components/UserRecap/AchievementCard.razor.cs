using Microsoft.AspNetCore.Components;
using NierReincarnationRecap.Model.Dto;

namespace NierReincarnationRecap.App.Components.UserRecap;

public partial class AchievementCard
{
    [CascadingParameter] public UserRecapDataDto UserRecapData { get; set; } = null!;
}
