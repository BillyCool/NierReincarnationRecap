using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Model.ViewModel;

public class Award
{
    public AwardCategory Category { get; init; }

    public List<AwardOption> OptionList { get; init; } = [];

    public long[]? Winners { get; set; }
}
