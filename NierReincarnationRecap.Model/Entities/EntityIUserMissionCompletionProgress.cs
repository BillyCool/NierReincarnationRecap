namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserMissionCompletionProgress
{
    public long UserId { get; set; }

    public int MissionId { get; set; }

    public long ProgressValue { get; set; }

    public long LatestVersion { get; set; }
}
