﻿namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserCostumeLotteryEffectAbility
{
    public long UserId { get; set; }

    public string UserCostumeUuid { get; set; }

    public int SlotNumber { get; set; }

    public int AbilityId { get; set; }

    public int AbilityLevel { get; set; }

    public long LatestVersion { get; set; }
}
