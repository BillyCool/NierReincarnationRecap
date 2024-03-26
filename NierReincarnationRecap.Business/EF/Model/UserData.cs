using Microsoft.EntityFrameworkCore;
using NierReincarnationRecap.Model.Dto;
using NierReincarnationRecap.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace NierReincarnationRecap.Business.EF.Model;

[PrimaryKey(nameof(UserId), nameof(Region))]
public class UserData
{
    public long UserId { get; init; }

    public long PlayerId { get; init; }

    [MaxLength(50)]
    public string Slug { get; init; } = null!;

    public SystemRegion Region { get; init; }

    public DateTimeOffset RegisterDatetime { get; init; }

    [MaxLength(50)]
    public string Name { get; set; }

    public int FavoriteCostumeId { get; set; }

    public int TotalLoginCount { get; set; }

    public int Level { get; set; }

    public int? MaxForce { get; set; }

    public int? DistanceWalked { get; set; }

    public int CostumeCount { get; set; }

    public int WeaponCount { get; set; }

    public int CompanionCount { get; set; }

    public int MemoirCount { get; set; }

    public int DebrisCount { get; set; }

    public int AwakeningCount { get; set; }

    public List<ArenaRankingDto> ArenaRankings { get; set; } = [];

    public List<SubjugationRankingDto> SubjugationRankings { get; set; } = [];

    public List<ExplorationRankingDto> ExplorationRankings { get; set; } = [];

    public void UpdateFromDto(UserDataDto userDataDto)
    {
        Name = userDataDto.Name;
        FavoriteCostumeId = userDataDto.FavoriteCostumeId;
        TotalLoginCount = userDataDto.TotalLoginCount;
        Level = userDataDto.Level;
        MaxForce = userDataDto.MaxForce;
        DistanceWalked = userDataDto.DistanceWalked;
        CostumeCount = userDataDto.CostumeCount;
        WeaponCount = userDataDto.WeaponCount;
        CompanionCount = userDataDto.CompanionCount;
        MemoirCount = userDataDto.MemoirCount;
        DebrisCount = userDataDto.DebrisCount;
        AwakeningCount = userDataDto.AwakeningCount;
        ArenaRankings = userDataDto.ArenaRankings;
        SubjugationRankings = userDataDto.SubjugationRankings;
        ExplorationRankings = userDataDto.ExplorationRankings;
    }
}
