namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserQuestSceneChoice
{
    public long UserId { get; set; }

    public int QuestSceneChoiceGroupingId { get; set; }

    public int QuestSceneChoiceEffectId { get; set; }

    public long LatestVersion { get; set; }
}
