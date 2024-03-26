using Microsoft.AspNetCore.Components;
using NierReincarnationRecap.Model.Dto;
using System.Net.Http.Json;

namespace NierReincarnationRecap.App.Components.UserRecap;

public partial class ProfileCard
{
    [CascadingParameter] public UserRecapDataDto UserRecapData { get; set; } = null!;

    [Inject] private HttpClient Http { get; set; } = null!;

    public string? ImagePath { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Dictionary<int, string> costumeIdMap = await Http.GetFromJsonAsync<Dictionary<int, string>>("json/costume-map.json") ?? [];
        ImagePath = costumeIdMap?.TryGetValue(UserRecapData!.FavoriteCostumeId, out string? imagePath) == true
            ? $"/images/profile/ch{imagePath}_battle.png"
            : null;

        await base.OnInitializedAsync();
    }
}
