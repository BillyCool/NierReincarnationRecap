﻿namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserCostumeLotteryEffect
{
    public long UserId { get; set; }

    public string UserCostumeUuid { get; set; }

    public int SlotNumber { get; set; }

    public int OddsNumber { get; set; }

    public long LatestVersion { get; set; }
}
