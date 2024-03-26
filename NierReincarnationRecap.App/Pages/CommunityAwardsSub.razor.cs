using Microsoft.AspNetCore.Components;
using MudBlazor;
using NierReincarnationRecap.App.Services;
using NierReincarnationRecap.Model.Dto;
using NierReincarnationRecap.Model.Enums;
using NierReincarnationRecap.Model.ViewModel;
using System.Net.Http.Json;

namespace NierReincarnationRecap.App.Pages;

public partial class CommunityAwardsSub
{
    [CascadingParameter] public UserPreferences UserPreferences { get; set; } = null!;

    [Parameter] public string? AwardType { get; set; }

    [Inject] private HttpClient Http { get; set; } = null!;

    [Inject] private IUserPreferencesService UserPreferencesService { get; set; } = null!;

    [Inject] private ISnackbar SnackbarService { get; set; } = null!;

    private List<Award>? Awards;

    private List<CommunityAwardCategory> AwardCategories => Awards?.Select(x => x.Category).ToList() ?? [];

    private bool IsSubmitting { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Awards = await Http.GetFromJsonAsync<List<Award>>($"json/{AwardType}-awards.json") ?? [];
    }

    private async Task SubmitOptions()
    {
        if (UserPreferences.Votes.Any(x => AwardCategories.Contains(x.Key)))
        {
            IsSubmitting = true;
            try
            {
                var res = await Http.PostAsJsonAsync("/api/submit-votes", new UserSubmissionDto()
                {
                    Token = UserPreferences.Token,
                    Votes = UserPreferences.Votes.Select(x => new UserVoteDto { CommunityAwardCategory = x.Key, Selection = x.Value }).ToList()
                });

                if (res.IsSuccessStatusCode)
                {
                    SnackbarService.Add("Submitted", Severity.Success);
                }
                else
                {
                    SnackbarService.Add("Unexpected Error", Severity.Error);
                }
            }
            catch
            {
                SnackbarService.Add("Unexpected Error", Severity.Error);
            }
            finally
            {
                IsSubmitting = false;
            }

            StateHasChanged();
        }
    }

    private async Task ResetOptions()
    {
        AwardCategories.ForEach(x => UserPreferences.Votes.Remove(x));
        await UserPreferencesService.SaveUserPreferences(UserPreferences);
        StateHasChanged();
    }
}
