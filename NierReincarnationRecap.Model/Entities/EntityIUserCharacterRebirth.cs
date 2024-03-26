namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserCharacterRebirth
{
    public long UserId { get; set; }

    public int CharacterId { get; set; }

    public int RebirthCount { get; set; }

    public long LatestVersion { get; set; }
}
