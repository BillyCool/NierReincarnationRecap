namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserMainQuestSeasonRoute
{
    public long UserId { get; set; }

    public int MainQuestSeasonId { get; set; }

    public int MainQuestRouteId { get; set; }

    public long LatestVersion { get; set; }
}
