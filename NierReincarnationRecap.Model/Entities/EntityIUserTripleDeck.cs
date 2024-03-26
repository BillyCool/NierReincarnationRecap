using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserTripleDeck
{
    public long UserId { get; set; }

    public DeckType DeckType { get; set; }

    public int UserDeckNumber { get; set; }

    public string Name { get; set; }

    public int DeckNumber01 { get; set; }

    public int DeckNumber02 { get; set; }

    public int DeckNumber03 { get; set; }

    public long LatestVersion { get; set; }
}
