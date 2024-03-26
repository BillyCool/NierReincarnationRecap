using Microsoft.AspNetCore.Components;
using NierReincarnationRecap.Model.Dto;
using System.Net.Http.Json;

namespace NierReincarnationRecap.App.Pages;

public partial class UserRecap
{
    [Parameter] public string? UserSlug { get; set; }

    [Inject] private HttpClient Http { get; set; } = null!;

    private UserRecapDataDto? UserRecapData { get; set; }

    protected override async Task OnInitializedAsync()
    {
        UserRecapData = await Http.GetFromJsonAsync<UserRecapDataDto>($"/api/get-user-data?userSlug={UserSlug}");

        await base.OnInitializedAsync();
    }
}
