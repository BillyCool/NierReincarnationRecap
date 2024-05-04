using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Model.ViewModel;

public class Award
{
    public CommunityAwardCategory Category { get; init; }

    public List<AwardOption> OptionList { get; init; } = [];

    public int[]? Winners { get; set; }
}
