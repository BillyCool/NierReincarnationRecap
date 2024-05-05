using System.ComponentModel.DataAnnotations;

namespace NierReincarnationRecap.Model.Enums;

public enum AwardCategory
{
    #region Community Awards

    [Display(Name = "Favorite Arc")]
    StoryArc,

    [Display(Name = "Favorite OST")]
    OstArc,

    [Display(Name = "Favorite Companion")]
    StoryCompanion,

    [Display(Name = "Favorite Character Story")]
    CharacterStory,

    [Display(Name = "Favorite Dark Memory Story")]
    DarkMemoryStory,

    [Display(Name = "Favorite False Light Memory Story")]
    LightMemoryStory,

    [Display(Name = "Favorite Hidden Story")]
    HiddenStory,

    [Display(Name = "Favorite Record Story")]
    RecordStory,

    [Display(Name = "Favorite Character Design")]
    CharacterDesign,

    [Display(Name = "Favorite English VA")]
    CharacterVaEng,

    [Display(Name = "Favorite Japanese VA")]
    CharacterVaJp,

    [Display(Name = "Favorite Rion Costume")]
    CostumeRion,

    [Display(Name = "Favorite Dimos Costume")]
    CostumeDimos,

    [Display(Name = "Favorite Gayle Costume")]
    CostumeGayle,

    [Display(Name = "Favorite Akeha Costume")]
    CostumeAkeha,

    [Display(Name = "Favorite Argo Costume")]
    CostumeArgo,

    [Display(Name = "Favorite Levania Costume")]
    CostumeLevania,

    [Display(Name = "Favorite 063y Costume")]
    Costume063y,

    [Display(Name = "Favorite F66x Costume")]
    CostumeF66x,

    [Display(Name = "Favorite Lars Costume")]
    CostumeLars,

    [Display(Name = "Favorite Griff Costume")]
    CostumeGriff,

    [Display(Name = "Favorite Noelle Costume")]
    CostumeNoelle,

    [Display(Name = "Favorite Fio Costume")]
    CostumeFio,

    [Display(Name = "Favorite Saryu Costume")]
    CostumeSaryu,

    [Display(Name = "Favorite Priyet Costume")]
    CostumePriyet,

    [Display(Name = "Favorite Marie Costume")]
    CostumeMarie,

    [Display(Name = "Favorite Yurie Costume")]
    CostumeYurie,

    [Display(Name = "Favorite Yudil Costume")]
    CostumeYudil,

    [Display(Name = "Favorite Sarafa Costume")]
    CostumeSarafa,

    [Display(Name = "Favorite Hina Costume")]
    CostumeHina,

    [Display(Name = "Favorite Yuzuki Costume")]
    CostumeYuzuki,

    [Display(Name = "Favorite 10H Costume")]
    Costume10H,

    [Display(Name = "Favorite Abstarct Costume")]
    CostumeAbstract,

    [Display(Name = "Favorite Bloody Costume")]
    CostumeBloody,

    [Display(Name = "Favorite Bloodless Costume")]
    CostumeBloodless,

    [Display(Name = "Favorite Lacrima Costume")]
    CostumeLacrima,

    [Display(Name = "Favorite Fractured Costume")]
    CostumeFractured,

    [Display(Name = "Favorite Mechanical Costume")]
    CostumeMechanical,

    [Display(Name = "Favorite Summer Costume")]
    CostumeSummer,

    [Display(Name = "Favorite Holy Night Costume")]
    CostumeHolyNight,

    [Display(Name = "Favorite New Year's Costume")]
    CostumeNewYears,

    [Display(Name = "Favorite Celebratory Costume")]
    CostumeCelebratory,

    [Display(Name = "Favorite Festive Costume")]
    CostumeFestive,

    [Display(Name = "Favorite Shadowbound Costume")]
    CostumeShadowbound,

    [Display(Name = "Favorite Abyssal Costume")]
    CostumeAbyssal,

    [Display(Name = "Favorite Divine Costume")]
    CostumeDivine,

    [Display(Name = "Favorite EX Costume")]
    CostumeEx,

    [Display(Name = "Favorite Frozen-Heart Costume")]
    CostumeFrozenHeart,

    [Display(Name = "Favorite Drake-NieR Costume")]
    CostumeDrakeNier,

    [Display(Name = "Favorite SINoALICE Costume")]
    CostumeSinoalice,

    [Display(Name = "Favorite Final Fantasy Costume")]
    CostumeFinalFantasy,

    [Display(Name = "Favorite Persona Costume")]
    CostumePersona,

    [Display(Name = "Favorite Dragon Quest Costume")]
    CostumeDragonQuest,

    #endregion Community Awards

    #region Mama Awards

    [Display(Name = "Most Days Logged In (JP)")]
    DaysLoggedInJp,

    [Display(Name = "Most Days Logged In (GL)")]
    DaysLoggedInGl,

    [Display(Name = "Highest Force")]
    MaxForce,

    [Display(Name = "Most Costumes Collected")]
    CostumesCollected,

    [Display(Name = "Most Weapons Collected")]
    WeaponsCollected,

    [Display(Name = "Biggest Whale 🐳")]
    AwakeningCount,

    [Display(Name = "Highest Average Arena Rank")]
    AvgArenaRank,

    [Display(Name = "Highest Average Subjugation Rank")]
    AvgSubjRank,

    [Display(Name = "Highest Shooting Normal Score")]
    ShootingNormalScore,

    [Display(Name = "Highest Shooting Hard Score")]
    ShootingHardScore,

    [Display(Name = "Highest Flying Mama Normal Score")]
    FlyingMamaNormalScore,

    [Display(Name = "Highest Flying Mama Hard Score")]
    FlyingMamaHardScore,

    [Display(Name = "Highest Subjugation Fire Moose Score")]
    SubjugationFireScore,

    [Display(Name = "Highest Subjugation Water Moose Score")]
    SubjugationWaterScore,

    [Display(Name = "Highest Subjugation Wind Moose Score")]
    SubjugationWindScore,

    [Display(Name = "Highest Subjugation Light Moose Score")]
    SubjugationLightScore,

    [Display(Name = "Highest Subjugation Dark Moose Score")]
    SubjugationDarkScore

    #endregion Mama Awards
}
