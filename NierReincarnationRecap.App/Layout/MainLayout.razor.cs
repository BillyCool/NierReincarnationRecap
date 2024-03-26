using Microsoft.AspNetCore.Components;
using MudBlazor;
using NierReincarnationRecap.App.Services;

namespace NierReincarnationRecap.App.Layout;
public partial class MainLayout
{
    [Inject] IUserPreferencesService UserPreferencesService { get; set; } = null!;

    private UserPreferences? UserPreferences;

    public static MudTheme MamaTheme => new()
    {
        PaletteDark = new PaletteDark()
        {
            Primary = "#FFFFFF",
            Tertiary = "#6759e9",
            Background = "#151515",
            AppbarBackground = "#101010"
        }
    };

    protected override async Task OnInitializedAsync()
    {
        try
        {
            UserPreferences = await UserPreferencesService.LoadUserPreferences();

            if (UserPreferences is null)
            {
                UserPreferences = new();
                await UserPreferencesService.SaveUserPreferences(UserPreferences);
            }
        }
        catch
        {
            UserPreferences = new();
            await UserPreferencesService.SaveUserPreferences(UserPreferences);
        }
        await base.OnInitializedAsync();
    }
}