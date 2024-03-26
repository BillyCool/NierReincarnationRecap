namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserStatus
{
    public long UserId { get; set; }

    public int Level { get; set; }

    public int Exp { get; set; }

    public int StaminaMilliValue { get; set; }

    public long StaminaUpdateDatetime { get; set; }

    public long LatestVersion { get; set; }
}
