using Blazored.LocalStorage;
using MudBlazor.Services;
using NierReincarnationRecap.App.Services;

namespace NierReincarnationRecap.App;

public static class ServiceExtension
{
    public static void AddNierReinRecapServices(this IServiceCollection services)
    {
        services.AddMudServices(x => x.SnackbarConfiguration = new()
        {
            PositionClass = MudBlazor.Defaults.Classes.Position.TopRight,
            PreventDuplicates = true,
            ClearAfterNavigation = true,
            VisibleStateDuration = 1000
        });
        services.AddBlazoredLocalStorage();
        services.AddScoped<IUserPreferencesService, UserPreferencesService>();
    }
}
