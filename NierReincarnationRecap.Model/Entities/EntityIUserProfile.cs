namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserProfile
{
    public long UserId { get; set; }

    public string Name { get; set; }

    public long NameUpdateDatetime { get; set; }

    public string Message { get; set; }

    public long MessageUpdateDatetime { get; set; }

    public int FavoriteCostumeId { get; set; }

    public long FavoriteCostumeIdUpdateDatetime { get; set; }

    public long LatestVersion { get; set; }
}
