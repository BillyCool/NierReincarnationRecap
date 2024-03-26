using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserDeckLimitContentRestricted
{
    public long UserId { get; set; }

    public int EventQuestChapterId { get; set; }

    public int QuestId { get; set; }

    public string DeckRestrictedUuid { get; set; }

    public PossessionType PossessionType { get; set; }

    public string TargetUuid { get; set; }

    public long LatestVersion { get; set; }
}
