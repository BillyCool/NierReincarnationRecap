using NierReincarnationRecap.Model.ViewModel;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace NierReincarnationRecap.App.Pages;

public partial class MamaAwards
{
    [Inject] private HttpClient Http { get; set; } = null!;

    private List<Award>? Awards;

    protected override async Task OnInitializedAsync()
    {
        Awards = await Http.GetFromJsonAsync<List<Award>>("json/mama-awards.json") ?? [];
    }
}
