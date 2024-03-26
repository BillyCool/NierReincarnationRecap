using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserDeckTypeNote
{
    public long UserId { get; set; }

    public DeckType DeckType { get; set; }

    public int MaxDeckPower { get; set; }

    public long LatestVersion { get; set; }
}
