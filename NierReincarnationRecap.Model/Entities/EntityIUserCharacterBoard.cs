namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserCharacterBoard
{
    public long UserId { get; set; }

    public int CharacterBoardId { get; set; }

    public int PanelReleaseBit1 { get; set; }

    public int PanelReleaseBit2 { get; set; }

    public int PanelReleaseBit3 { get; set; }

    public int PanelReleaseBit4 { get; set; }

    public long LatestVersion { get; set; }
}
