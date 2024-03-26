namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserWeaponStory
{
    public long UserId { get; set; }

    public int WeaponId { get; set; }

    public int ReleasedMaxStoryIndex { get; set; }

    public long LatestVersion { get; set; }
}
