namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserCharacter
{
    public long UserId { get; set; }

    public int CharacterId { get; set; }

    public int Level { get; set; }

    public int Exp { get; set; }

    public long LatestVersion { get; set; }
}
