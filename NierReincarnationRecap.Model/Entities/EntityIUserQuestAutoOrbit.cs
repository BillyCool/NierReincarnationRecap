using NierReincarnationRecap.Model.Enums;
namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserQuestAutoOrbit
{
    public long UserId { get; set; }

    public QuestType QuestType { get; set; }

    public int ChapterId { get; set; }

    public int QuestId { get; set; }

    public int MaxAutoOrbitCount { get; set; }

    public int ClearedAutoOrbitCount { get; set; }

    public long LastClearDatetime { get; set; }

    public long LatestVersion { get; set; }
}
