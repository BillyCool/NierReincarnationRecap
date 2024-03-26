using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserMainQuestProgressStatus
{
    public long UserId { get; set; }

    public int CurrentQuestSceneId { get; set; }

    public int HeadQuestSceneId { get; set; }

    public QuestFlowType CurrentQuestFlowType { get; set; }

    public long LatestVersion { get; set; }
}
