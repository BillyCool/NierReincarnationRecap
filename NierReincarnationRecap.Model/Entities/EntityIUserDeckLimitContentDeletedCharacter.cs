﻿namespace NierReincarnationRecap.Model.Entities;

public class EntityIUserDeckLimitContentDeletedCharacter
{
    public long UserId { get; set; }

    public int UserDeckNumber { get; set; }

    public int UserDeckCharacterNumber { get; set; }

    public int CostumeId { get; set; }

    public long LatestVersion { get; set; }
}
