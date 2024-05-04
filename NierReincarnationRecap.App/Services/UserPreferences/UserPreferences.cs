using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.App.Services;

public class UserPreferences
{
    public Guid Token { get; set; } = Guid.NewGuid();

    public Dictionary<AwardCategory, int> Votes { get; set; } = [];
}
