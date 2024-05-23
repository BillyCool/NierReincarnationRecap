using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using NierReincarnationRecap.Business.EF;
using NierReincarnationRecap.Business.EF.Model;
using NierReincarnationRecap.Model.Dto;
using NierReincarnationRecap.Model.Enums;
using NierReincarnationRecap.Model.ViewModel;
using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NierReincarnationRecap.Api;

public class AwardGenerationFunctions(NierReincarnationRecapDbContext dbContext)
{
    [Function("story-awards-json")]
    public async Task<IActionResult> StoryAwardsJson([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
    {
        List<Award> awards =
        [
            new Award()
            {
                Category = AwardCategory.StoryArc,
                OptionList =
                [
                    new() { Name = "The Girl and the Monster" },
                    new() { Name = "The Sun and the Moon" },
                    new() { Name = "The People and the World" }
                ]
            },
            new Award()
            {
                Category = AwardCategory.OstArc,
                OptionList =
                [
                    new() { Name = "The Girl and the Monster" },
                    new() { Name = "The Sun and the Moon" },
                    new() { Name = "The People and the World" }
                ]
            },
            new Award()
            {
                Category = AwardCategory.CharacterStory,
                OptionList = GetCharacterAwardOptionsByCategory(AwardCategory.CharacterStory)
            },
            new Award()
            {
                Category = AwardCategory.DarkMemoryStory,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeEx)
            },
            new Award()
            {
                Category = AwardCategory.LightMemoryStory,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeFrozenHeart)
            },
            new Award()
            {
                Category = AwardCategory.HiddenStory,
                OptionList = GetCharacterAwardOptionsByCategory(AwardCategory.HiddenStory)
            },
            new Award()
            {
                Category = AwardCategory.RecordStory,
                OptionList =
                [
                    new() { Name = "The Cage of Reincarnation" },
                    new() { Name = "Sunset Port" },
                    new() { Name = "Garden of Benediction" },
                    new() { Name = "Coffin of Repose" },
                    new() { Name = "Pure Hills" },
                    new() { Name = "Seat of Shadow" },
                    new() { Name = "Blood Oath's Edge" },
                    new() { Name = "Rhythm's Citadel" },
                    new() { Name = "Path of Longing" },
                    new() { Name = "Bridge of Supplication" },
                    new() { Name = "Festive Fountain" },
                    new() { Name = "Den of Madness" },
                    new() { Name = "Foundation of Fortune" },
                    new() { Name = "Valley of Light" },
                    new() { Name = "Chamber of Prayer" },
                    new() { Name = "Garden of Paradise" },
                    new() { Name = "Stronghold of Desolation" },
                    new() { Name = "Vestiges of Paradise" },
                    new() { Name = "City of Discontent" },
                    new() { Name = "Town of Deceit" },
                    new() { Name = "Covetous Grove" },
                    new() { Name = "Original Sin's Door" },
                    new() { Name = "Playful Seas" },
                    new() { Name = "Trench of Lost Bonds" },
                    new() { Name = "Happy Home" },
                    new() { Name = "Rebellion's Illusion" },
                    new() { Name = "Rebellion's Reality" },
                    new() { Name = "The Pumpkin Box" },
                    new() { Name = "Mechanical Foundations" },
                    new() { Name = "A Distant Peak" },
                    new() { Name = "The Wishing Space" },
                    new() { Name = "Forest of Temptation" },
                    new() { Name = "Eternal Steps" },
                    new() { Name = "Hidden Truths" },
                    new() { Name = "Traces of Pursuit" },
                    new() { Name = "Market of Ruse" },
                    new() { Name = "The Devil's Tray" },
                    new() { Name = "Tower of Beginnings" },
                    new() { Name = "Ritual of Reverie" },
                    new() { Name = "Their Stage" },
                    new() { Name = "A Question of Decorum" },
                    new() { Name = "An Endearing Journey" },
                    new() { Name = "Hallowed Struggle" },
                    new() { Name = "Starfall Cliff" },
                    new() { Name = "The Cage of Rebirth" },
                ]
            },
        ];

        await SetWinnersAsync(awards);

        return new JsonResult(awards, new JsonSerializerOptions(JsonSerializerDefaults.Web) { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
    }

    [Function("character-awards-json")]
    public async Task<IActionResult> CharacterAwardsJson([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
    {
        List<Award> awards =
        [
            new Award()
            {
                Category = AwardCategory.CharacterDesign,
                OptionList = GetCharacterAwardOptionsByCategory(AwardCategory.CharacterStory)
            },
            new Award()
            {
                Category = AwardCategory.CharacterVaEng,
                OptionList = GetCharacterAwardOptionsByCategory(AwardCategory.CharacterVaEng)
            },
            new Award()
            {
                Category = AwardCategory.CharacterVaJp,
                OptionList = GetCharacterAwardOptionsByCategory(AwardCategory.CharacterVaJp)
            },
            new Award()
            {
                Category = AwardCategory.CostumeRion,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeRion)
            },
            new Award()
            {
                Category = AwardCategory.CostumeDimos,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeDimos)
            },
            new Award()
            {
                Category = AwardCategory.CostumeGayle,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeGayle)
            },
            new Award()
            {
                Category = AwardCategory.CostumeAkeha,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeAkeha)
            },
            new Award()
            {
                Category = AwardCategory.CostumeArgo,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeArgo)
            },
            new Award()
            {
                Category = AwardCategory.CostumeLevania,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeLevania)
            },
            new Award()
            {
                Category = AwardCategory.Costume063y,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.Costume063y)
            },
            new Award()
            {
                Category = AwardCategory.CostumeF66x,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeF66x)
            },
            new Award()
            {
                Category = AwardCategory.CostumeLars,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeLars)
            },
            new Award()
            {
                Category = AwardCategory.CostumeGriff,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeGriff)
            },
            new Award()
            {
                Category = AwardCategory.CostumeNoelle,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeNoelle)
            },
            new Award()
            {
                Category = AwardCategory.CostumeFio,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeFio)
            },
            new Award()
            {
                Category = AwardCategory.CostumeSaryu,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeSaryu)
            },
            new Award()
            {
                Category = AwardCategory.CostumePriyet,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumePriyet)
            },
            new Award()
            {
                Category = AwardCategory.CostumeMarie,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeMarie)
            },
            new Award()
            {
                Category = AwardCategory.CostumeYurie,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeYurie)
            },
            new Award()
            {
                Category = AwardCategory.CostumeYudil,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeYudil)
            },
            new Award()
            {
                Category = AwardCategory.CostumeSarafa,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeSarafa)
            },
            new Award()
            {
                Category = AwardCategory.CostumeHina,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeHina)
            },
            new Award()
            {
                Category = AwardCategory.CostumeYuzuki,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeYuzuki)
            },
            new Award()
            {
                Category = AwardCategory.Costume10H,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.Costume10H)
            },
        ];

        await SetWinnersAsync(awards);

        return new JsonResult(awards, new JsonSerializerOptions(JsonSerializerDefaults.Web) { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
    }

    [Function("costume-series-awards-json")]
    public async Task<IActionResult> CostumeSeriesAwardsJson([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
    {
        List<Award> awards =
        [
            new Award()
            {
                Category = AwardCategory.CostumeAbstract,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeAbstract)
            },
            new Award()
            {
                Category = AwardCategory.CostumeBloody,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeBloody)
            },
            new Award()
            {
                Category = AwardCategory.CostumeBloodless,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeBloodless)
            },
            new Award()
            {
                Category = AwardCategory.CostumeLacrima,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeLacrima)
            },
            new Award()
            {
                Category = AwardCategory.CostumeFractured,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeFractured)
            },
            new Award()
            {
                Category = AwardCategory.CostumeMechanical,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeMechanical)
            },
            new Award()
            {
                Category = AwardCategory.CostumeSummer,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeSummer)
            },
            new Award()
            {
                Category = AwardCategory.CostumeHolyNight,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeHolyNight)
            },
            new Award()
            {
                Category = AwardCategory.CostumeNewYears,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeNewYears)
            },
            new Award()
            {
                Category = AwardCategory.CostumeCelebratory,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeCelebratory)
            },
            new Award()
            {
                Category = AwardCategory.CostumeFestive,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeFestive)
            },
            new Award()
            {
                Category = AwardCategory.CostumeShadowbound,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeShadowbound)
            },
            new Award()
            {
                Category = AwardCategory.CostumeAbyssal,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeAbyssal)
            },
            new Award()
            {
                Category = AwardCategory.CostumeDivine,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeDivine)
            },
            new Award()
            {
                Category = AwardCategory.CostumeEx,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeEx)
            },
            new Award()
            {
                Category = AwardCategory.CostumeFrozenHeart,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeFrozenHeart)
            },
            new Award()
            {
                Category = AwardCategory.CostumeDrakeNier,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeDrakeNier)
            },
            new Award()
            {
                Category = AwardCategory.CostumeSinoalice,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeSinoalice)
            },
            new Award()
            {
                Category = AwardCategory.CostumeFinalFantasy,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeFinalFantasy)
            },
            new Award()
            {
                Category = AwardCategory.CostumePersona,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumePersona)
            },
            new Award()
            {
                Category = AwardCategory.CostumeDragonQuest,
                OptionList = GetCostumeAwardOptionsByCategory(AwardCategory.CostumeDragonQuest)
            }
        ];

        await SetWinnersAsync(awards);

        return new JsonResult(awards, new JsonSerializerOptions(JsonSerializerDefaults.Web) { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
    }

    [Function("mama-awards-json")]
    public async Task<IActionResult> MamaAwardsJson([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
    {
        List<UserData> userData = await dbContext.UserData.ToListAsync();

        List<Award> awards =
        [
            GenerateMamaAward(AwardCategory.DaysLoggedInJp, userData),
            GenerateMamaAward(AwardCategory.DaysLoggedInGl, userData),
            GenerateMamaAward(AwardCategory.MaxForce, userData),
            GenerateMamaAward(AwardCategory.CostumesCollected, userData),
            GenerateMamaAward(AwardCategory.WeaponsCollected, userData),
            GenerateMamaAward(AwardCategory.AwakeningCount, userData),
            GenerateMamaAward(AwardCategory.AvgArenaRank, userData),
            GenerateMamaAward(AwardCategory.AvgSubjRank, userData),
            GenerateMamaAward(AwardCategory.SubjugationFireScore, userData),
            GenerateMamaAward(AwardCategory.SubjugationWaterScore, userData),
            GenerateMamaAward(AwardCategory.SubjugationWindScore, userData),
            GenerateMamaAward(AwardCategory.SubjugationLightScore, userData),
            GenerateMamaAward(AwardCategory.SubjugationDarkScore, userData),
            GenerateMamaAward(AwardCategory.ShootingNormalScore, userData),
            GenerateMamaAward(AwardCategory.ShootingHardScore, userData),
            GenerateMamaAward(AwardCategory.FlyingMamaNormalScore, userData),
            GenerateMamaAward(AwardCategory.FlyingMamaHardScore, userData)
        ];

        return new JsonResult(awards, new JsonSerializerOptions(JsonSerializerDefaults.Web) { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
    }

    private static List<AwardOption> GetCharacterAwardOptionsByCategory(AwardCategory awardCategory)
    {
        return GetCharacterAwardOptions()
            .Where(x => x.AwardCategories.Contains(awardCategory))
            .Select(x => new AwardOption { Name = x.Name, ImagePath = x.ImagePath })
            .ToList();
    }

    private static List<AwardOptionInternal> GetCharacterAwardOptions()
    {
        return
        [
            new AwardOptionInternal("Mama / Pod 006", "000001", [AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp, AwardCategory.StoryCompanion]),
            new AwardOptionInternal("Carrier", "000002", [AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp, AwardCategory.StoryCompanion]),
            new AwardOptionInternal("Rion - Sickly Exile", "008001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.LightMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Dimos - Departed Gunman", "007001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.LightMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Gayle - Wounded Hunter", "009001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.LightMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Akeha - Twilight Assassin", "015001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.LightMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Argo - Apex Traveler", "006001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.LightMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Levania - Dark Monster", "005001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.LightMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("063y - Stalwart Prisoner", "011001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.LightMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("F66x - Distressed Captive", "012001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.LightMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Lars - Spiteful Soldier", "013001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.LightMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Griff - Harmonious Captain", "014001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.LightMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Noelle - Hidden Weapon", "010001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.LightMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Fio - The Girl of Light", "019001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.LightMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Dark Mama & Babe", "000003", [AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp, AwardCategory.StoryCompanion]),
            new AwardOptionInternal("Papa", "000004", [AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp, AwardCategory.StoryCompanion]),
            new AwardOptionInternal("Saryu - Avowed Witch", "022001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Priyet - Verboten Werebeast", "023001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Marie - Praying Songstress", "024001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Yurie - Obsessed Ruler", "025001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Yudil - Pilfering Boor", "027001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Sarafa - Chained Belle", "026001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Hina - Dedicated Pupil", "020001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Yuzuki - Devoted Student", "021001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaEng, AwardCategory.CharacterVaJp]),
            new AwardOptionInternal("10H - Sentinel Savior", "048001", [AwardCategory.CharacterStory, AwardCategory.DarkMemoryStory, AwardCategory.HiddenStory, AwardCategory.CharacterVaJp]),
        ];
    }

    private static List<AwardOption> GetCostumeAwardOptionsByCategory(AwardCategory awardCategory)
    {
        return GetCostumeAwardOptions()
            .Where(x => x.AwardCategories.Contains(awardCategory))
            .Select(x => new AwardOption { Name = x.Name, ImagePath = x.ImagePath })
            .ToList();
    }

    private static List<AwardOptionInternal> GetCostumeAwardOptions()
    {
        return
        [
            new AwardOptionInternal("2B - Praying Battler", "001001", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("2B - Shattered Battler", "001004", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("2B - Divergent Battler", "001002", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("2P - Mock Machine", "001003", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("2B - Alternate Battler", "001005", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("9S - Isolated Scanner", "002001", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("9S - Divergent Scanner", "002002", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("A2 - Vengeful Attacker", "003001", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("A2 - Divergent Attacker", "003002", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("The World-Ender - Soulful Lad", "016001", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("The World-Ender - Divergent Lad", "016002", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("The World-Ender - Alternate Lad", "016003", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("Emil - Puzzling Oddity", "017001", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("Emil - Divergent Oddity", "017002", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("Kainé - The Aerie Warrior", "018001", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("Kainé - Divergent Warrior", "018002", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("Zero - Progenitor Sister", "031001", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("Zero - Divergent Sister", "031002", [AwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("Joker - Caged Rebel", "044001", [AwardCategory.CostumePersona]),
            new AwardOptionInternal("Queen - Virtuous Priestess", "045001", [AwardCategory.CostumePersona]),
            new AwardOptionInternal("Fox - Insightful Emperor", "046001", [AwardCategory.CostumePersona]),
            new AwardOptionInternal("Crow - Scheming Justice", "047001", [AwardCategory.CostumePersona]),
            new AwardOptionInternal("Rion - Sickly Exile", "008001", [AwardCategory.CostumeRion]),
            new AwardOptionInternal("Rion - Dissenting Exile", "008003", [AwardCategory.CostumeRion]),
            new AwardOptionInternal("Rion - Guardian Exile", "008010", [AwardCategory.CostumeRion]),
            new AwardOptionInternal("Rion - Abstract Exile", "008005", [AwardCategory.CostumeRion, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Rion - Mechanical Exile", "008002", [AwardCategory.CostumeRion, AwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Rion - Summer Exile", "008009", [AwardCategory.CostumeRion, AwardCategory.CostumeSummer]),
            new AwardOptionInternal("Rion - Yuletide Exile", "008012", [AwardCategory.CostumeRion, AwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Rion - New Year's Exile", "008006", [AwardCategory.CostumeRion, AwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Rion - Celebratory Exile", "008013", [AwardCategory.CostumeRion, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Rion - Festive Exile", "008019", [AwardCategory.CostumeRion, AwardCategory.CostumeFestive]),
            new AwardOptionInternal("Rion - Shadowbound Exile", "008014", [AwardCategory.CostumeRion, AwardCategory.CostumeShadowbound]),
            new AwardOptionInternal("Rion - Abyssal Exile", "008007", [AwardCategory.CostumeRion, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Rion - Phantasmal Exile", "008011", [AwardCategory.CostumeFinalFantasy, AwardCategory.CostumeRion]),
            new AwardOptionInternal("Rion - Oathbound Exile", "008018", [AwardCategory.CostumeDragonQuest, AwardCategory.CostumeRion]),
            new AwardOptionInternal("Rion - Reborn Revolutionary", "008004", [AwardCategory.CostumeRion, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Rion - Frozen-Heart Revolutionary", "008008", [AwardCategory.CostumeRion, AwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Dimos - Departed Gunman", "007001", [AwardCategory.CostumeDimos]),
            new AwardOptionInternal("Dimos - Dissenting Gunman", "007003", [AwardCategory.CostumeDimos]),
            new AwardOptionInternal("Dimos - Guardian Gunman", "007005", [AwardCategory.CostumeDimos]),
            new AwardOptionInternal("Dimos - False Guardian Gunman", "007009", [AwardCategory.CostumeDimos]),
            new AwardOptionInternal("Dimos - Abstract Gunman", "007002", [AwardCategory.CostumeDimos, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Dimos - Bloody Gunman", "007006", [AwardCategory.CostumeDimos, AwardCategory.CostumeBloody]),
            new AwardOptionInternal("Dimos - Bloodless Gunman", "007013", [AwardCategory.CostumeDimos, AwardCategory.CostumeBloodless]),
            new AwardOptionInternal("Dimos - Fractured Gunman", "007008", [AwardCategory.CostumeDimos, AwardCategory.CostumeFractured]),
            new AwardOptionInternal("Dimos - Summer Gunman", "007015", [AwardCategory.CostumeDimos, AwardCategory.CostumeSummer]),
            new AwardOptionInternal("Dimos - New Year's Gunman", "007016", [AwardCategory.CostumeDimos, AwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Dimos - Celebratory Gunman", "007010", [AwardCategory.CostumeDimos, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Dimos - Abyssal Gunman", "007012", [AwardCategory.CostumeDimos, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Dimos - Reborn Automaton", "007004", [AwardCategory.CostumeDimos, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Dimos - Frozen-Heart Automaton", "007007", [AwardCategory.CostumeDimos, AwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Gayle - Wounded Hunter", "009001", [AwardCategory.CostumeGayle]),
            new AwardOptionInternal("Gayle - Dissenting Hunter", "009003", [AwardCategory.CostumeGayle]),
            new AwardOptionInternal("Gayle - Guardian Hunter", "009005", [AwardCategory.CostumeGayle]),
            new AwardOptionInternal("Gayle - Abstract Hunter", "009002", [AwardCategory.CostumeGayle, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Gayle - Bloody Hunter", "009006", [AwardCategory.CostumeGayle, AwardCategory.CostumeBloody]),
            new AwardOptionInternal("Gayle - Fractured Hunter", "009010", [AwardCategory.CostumeGayle, AwardCategory.CostumeFractured]),
            new AwardOptionInternal("Gayle - Mechanical Hunter", "009016", [AwardCategory.CostumeGayle, AwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Gayle - Summer Hunter", "009011", [AwardCategory.CostumeGayle, AwardCategory.CostumeSummer]),
            new AwardOptionInternal("Gayle - Yuletide Hunter", "009013", [AwardCategory.CostumeGayle, AwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Gayle - New Year's Hunter", "009007", [AwardCategory.CostumeGayle, AwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Gayle - Celebratory Hunter", "009009", [AwardCategory.CostumeGayle, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Gayle - Festive Hunter", "009015", [AwardCategory.CostumeGayle, AwardCategory.CostumeFestive]),
            new AwardOptionInternal("Gayle - Abyssal Hunter", "009012", [AwardCategory.CostumeGayle, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Gayle - Reborn Contractor", "009004", [AwardCategory.CostumeGayle, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Gayle - Frozen-Heart Contractor", "009008", [AwardCategory.CostumeGayle, AwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Akeha - Twilight Assassian", "015001", [AwardCategory.CostumeAkeha]),
            new AwardOptionInternal("Akeha - Dissenting Assassian", "015003", [AwardCategory.CostumeAkeha]),
            new AwardOptionInternal("Akeha - Guardian Assassian", "015011", [AwardCategory.CostumeAkeha]),
            new AwardOptionInternal("Akeha - False Guardian Assassian", "015013", [AwardCategory.CostumeAkeha]),
            new AwardOptionInternal("Akeha - Abstract Assassian", "015002", [AwardCategory.CostumeAkeha, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Akeha - Bloody Assassian", "015005", [AwardCategory.CostumeAkeha, AwardCategory.CostumeBloody]),
            new AwardOptionInternal("Akeha - Bloodless Assassian", "015010", [AwardCategory.CostumeAkeha, AwardCategory.CostumeBloodless]),
            new AwardOptionInternal("Akeha - Fractured Assassian", "015014", [AwardCategory.CostumeAkeha, AwardCategory.CostumeFractured]),
            new AwardOptionInternal("Akeha - Mechanical Assassian", "015012", [AwardCategory.CostumeAkeha, AwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Akeha - Summer Assassian", "015009", [AwardCategory.CostumeAkeha, AwardCategory.CostumeSummer]),
            new AwardOptionInternal("Akeha - Yuletide Assassian", "015007", [AwardCategory.CostumeAkeha, AwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Akeha - New Year's Assassian", "015018", [AwardCategory.CostumeAkeha, AwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Akeha - Celebratory Assassian", "015015", [AwardCategory.CostumeAkeha, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Akeha - Festive Assassian", "015021", [AwardCategory.CostumeAkeha, AwardCategory.CostumeFestive]),
            new AwardOptionInternal("Akeha - Abyssal Assassian", "015016", [AwardCategory.CostumeAkeha, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Akeha - Divine Assassian", "015020", [AwardCategory.CostumeAkeha, AwardCategory.CostumeDivine]),
            new AwardOptionInternal("Akeha - Intoner Assassian", "015006", [AwardCategory.CostumeAkeha]),
            new AwardOptionInternal("Akeha - Fabled Assassian", "015017", [AwardCategory.CostumeSinoalice, AwardCategory.CostumeAkeha]),
            new AwardOptionInternal("Akeha - Reborn Swordmaster", "015004", [AwardCategory.CostumeAkeha, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Akeha - Frozen-Heart Swordmaster", "015008", [AwardCategory.CostumeAkeha, AwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Argo - Apex Traveler", "006001", [AwardCategory.CostumeArgo]),
            new AwardOptionInternal("Argo - Dissenting Traveler", "006003", [AwardCategory.CostumeArgo]),
            new AwardOptionInternal("Argo - Guardian Traveler", "006005", [AwardCategory.CostumeArgo]),
            new AwardOptionInternal("Argo - Abstract Traveler", "006006", [AwardCategory.CostumeArgo, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Argo - Bloody Traveler", "006012", [AwardCategory.CostumeArgo, AwardCategory.CostumeBloody]),
            new AwardOptionInternal("Argo - Fractured Traveler", "006010", [AwardCategory.CostumeArgo, AwardCategory.CostumeFractured]),
            new AwardOptionInternal("Argo - Summer Traveler", "006008", [AwardCategory.CostumeArgo, AwardCategory.CostumeSummer]),
            new AwardOptionInternal("Argo - Yuletide Traveler", "006013", [AwardCategory.CostumeArgo, AwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Argo - Celebratory Traveler", "006009", [AwardCategory.CostumeArgo, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Argo - Shadowbound Traveler", "006014", [AwardCategory.CostumeArgo, AwardCategory.CostumeShadowbound]),
            new AwardOptionInternal("Argo - Patriotic Traveler", "006002", [AwardCategory.CostumeArgo]),
            new AwardOptionInternal("Argo - Reborn Adventurer", "006004", [AwardCategory.CostumeArgo, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Argo - Frozen-Heart Adventurer", "006007", [AwardCategory.CostumeArgo, AwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Levania - Human Monster", "004001", [AwardCategory.CostumeLevania]),
            new AwardOptionInternal("Levania - Dark Monster", "005001", [AwardCategory.CostumeLevania]),
            new AwardOptionInternal("Levania - Guardian Monster", "005007", [AwardCategory.CostumeLevania]),
            new AwardOptionInternal("Levania - Abstract Monster", "005002", [AwardCategory.CostumeLevania, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Levania - Bloody Monster", "005008", [AwardCategory.CostumeLevania, AwardCategory.CostumeBloody]),
            new AwardOptionInternal("Levania - Bloodless Monster", "005005", [AwardCategory.CostumeLevania, AwardCategory.CostumeBloodless]),
            new AwardOptionInternal("Levania - Lacrima Monster", "005010", [AwardCategory.CostumeLevania, AwardCategory.CostumeLacrima]),
            new AwardOptionInternal("Levania - Yuletide Monster", "005006", [AwardCategory.CostumeLevania, AwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Levania - Celebratory Monster", "005011", [AwardCategory.CostumeLevania, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Levania - Festive Monster", "005013", [AwardCategory.CostumeLevania, AwardCategory.CostumeFestive]),
            new AwardOptionInternal("Levania - Abyssal Monster", "005009", [AwardCategory.CostumeLevania, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Levania - Reborn Beast", "005003", [AwardCategory.CostumeLevania, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Levania - Frozen-Heart Beast", "005004", [AwardCategory.CostumeLevania, AwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("063y - Stalwart Prisoner", "011001", [AwardCategory.Costume063y]),
            new AwardOptionInternal("063y - Dissenting Prisoner", "011003", [AwardCategory.Costume063y]),
            new AwardOptionInternal("063y - Guardian Prisoner", "011009", [AwardCategory.Costume063y]),
            new AwardOptionInternal("063y - Abstract Prisoner", "011002", [AwardCategory.Costume063y, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("063y - Fractured Prisoner", "011005", [AwardCategory.Costume063y, AwardCategory.CostumeFractured]),
            new AwardOptionInternal("063y - Summer Prisoner", "011007", [AwardCategory.Costume063y, AwardCategory.CostumeSummer]),
            new AwardOptionInternal("063y - Yuletide Prisoner", "011015", [AwardCategory.Costume063y, AwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("063y - New Year's Prisoner", "011010", [AwardCategory.Costume063y, AwardCategory.CostumeNewYears]),
            new AwardOptionInternal("063y - Celebratory Prisoner", "011012", [AwardCategory.Costume063y, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("063y - Abyssal Prisoner", "011011", [AwardCategory.Costume063y, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("063y - Divine Prisoner", "011014", [AwardCategory.Costume063y, AwardCategory.CostumeDivine]),
            new AwardOptionInternal("063y - Phantasmal Prisoner", "011008", [AwardCategory.CostumeFinalFantasy, AwardCategory.Costume063y]),
            new AwardOptionInternal("063y - Reborn Convict", "011004", [AwardCategory.Costume063y, AwardCategory.CostumeEx]),
            new AwardOptionInternal("063y - Frozen-Heart Convict", "011006", [AwardCategory.Costume063y, AwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("F66x - Distressed Captive", "012001", [AwardCategory.CostumeF66x]),
            new AwardOptionInternal("F66x - Dissenting Captive", "012003", [AwardCategory.CostumeF66x]),
            new AwardOptionInternal("F66x - Guardian Captive", "012007", [AwardCategory.CostumeF66x]),
            new AwardOptionInternal("F66x - Abstract Captive", "012002", [AwardCategory.CostumeF66x, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("F66x - Bloody Captive", "012010", [AwardCategory.CostumeF66x, AwardCategory.CostumeBloody]),
            new AwardOptionInternal("F66x - Bloodless Captive", "012011", [AwardCategory.CostumeF66x, AwardCategory.CostumeBloodless]),
            new AwardOptionInternal("F66x - Lacrima Captive", "012005", [AwardCategory.CostumeF66x, AwardCategory.CostumeLacrima]),
            new AwardOptionInternal("F66x - Summer Captive", "012008", [AwardCategory.CostumeF66x, AwardCategory.CostumeSummer]),
            new AwardOptionInternal("F66x - Celebratory Captive", "012012", [AwardCategory.CostumeF66x, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("F66x - Abyssal Captive", "012009", [AwardCategory.CostumeF66x, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("F66x - Reborn Inmate", "012004", [AwardCategory.CostumeF66x, AwardCategory.CostumeEx]),
            new AwardOptionInternal("F66x - Frozen-Heart Inmate", "012006", [AwardCategory.CostumeF66x, AwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Lars - Spiteful Solder", "013001", [AwardCategory.CostumeLars]),
            new AwardOptionInternal("Lars - Dissenting Solder", "013003", [AwardCategory.CostumeLars]),
            new AwardOptionInternal("Lars - Guardian Solder", "013008", [AwardCategory.CostumeLars]),
            new AwardOptionInternal("Lars - Abstract Solder", "013004", [AwardCategory.CostumeLars, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Lars - Bloody Solder", "013010", [AwardCategory.CostumeLars, AwardCategory.CostumeBloody]),
            new AwardOptionInternal("Lars - Lacrima Solder", "013007", [AwardCategory.CostumeLars, AwardCategory.CostumeLacrima]),
            new AwardOptionInternal("Lars - Fractured Solder", "013005", [AwardCategory.CostumeLars, AwardCategory.CostumeFractured]),
            new AwardOptionInternal("Lars - Yuletide Solder", "013012", [AwardCategory.CostumeLars, AwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Lars - Celebratory Solder", "013009", [AwardCategory.CostumeLars, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Lars - Abyssal Solder", "013011", [AwardCategory.CostumeLars, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Lars - Phantasmal Solder", "013014", [AwardCategory.CostumeFinalFantasy, AwardCategory.CostumeLars]),
            new AwardOptionInternal("Lars - Reborn Truant", "013002", [AwardCategory.CostumeLars, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Lars - Frozen-Heart Truant", "013006", [AwardCategory.CostumeLars, AwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Griff - Harmonioud Captain", "014001", [AwardCategory.CostumeGriff]),
            new AwardOptionInternal("Griff - Dissenting Captain", "014003", [AwardCategory.CostumeGriff]),
            new AwardOptionInternal("Griff - Guardian Captain", "014005", [AwardCategory.CostumeGriff]),
            new AwardOptionInternal("Griff - False Guardian Captain", "014014", [AwardCategory.CostumeGriff]),
            new AwardOptionInternal("Griff - Abstract Captain", "014004", [AwardCategory.CostumeGriff, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Griff - Bloody Captain", "014010", [AwardCategory.CostumeGriff, AwardCategory.CostumeBloody]),
            new AwardOptionInternal("Griff - Lacrima Captain", "014008", [AwardCategory.CostumeGriff, AwardCategory.CostumeLacrima]),
            new AwardOptionInternal("Griff - Fractured Captain", "014009", [AwardCategory.CostumeGriff, AwardCategory.CostumeFractured]),
            new AwardOptionInternal("Griff - Mechanical Captain", "014016", [AwardCategory.CostumeGriff, AwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Griff - Yuletide Captain", "014011", [AwardCategory.CostumeGriff, AwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Griff - New Year's Captain", "014017", [AwardCategory.CostumeGriff, AwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Griff - Celebratory Captain", "014007", [AwardCategory.CostumeGriff, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Griff - Festive Captain", "014015", [AwardCategory.CostumeGriff, AwardCategory.CostumeFestive]),
            new AwardOptionInternal("Griff - Abyssal Captain", "014013", [AwardCategory.CostumeGriff, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Griff - Reborn Has-Been", "014002", [AwardCategory.CostumeGriff, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Griff - Frozen-Heart Has-Been", "014006", [AwardCategory.CostumeGriff, AwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Noelle - Hidden Weapon", "010001", [AwardCategory.CostumeNoelle]),
            new AwardOptionInternal("Noelle - Dissenting Weapon", "010003", [AwardCategory.CostumeNoelle]),
            new AwardOptionInternal("Noelle - Guardian Weapon", "010005", [AwardCategory.CostumeNoelle]),
            new AwardOptionInternal("Noelle - Abstract Weapon", "010002", [AwardCategory.CostumeNoelle, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Noelle - Bloody Weapon", "010011", [AwardCategory.CostumeNoelle, AwardCategory.CostumeBloody]),
            new AwardOptionInternal("Noelle - Bloodless Weapon", "010009", [AwardCategory.CostumeNoelle, AwardCategory.CostumeBloodless]),
            new AwardOptionInternal("Noelle - Fractured Weapon", "010012", [AwardCategory.CostumeNoelle, AwardCategory.CostumeFractured]),
            new AwardOptionInternal("Noelle - Mechanical Weapon", "010018", [AwardCategory.CostumeNoelle, AwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Noelle - Summer Weapon", "010016", [AwardCategory.CostumeNoelle, AwardCategory.CostumeSummer]),
            new AwardOptionInternal("Noelle - Yuletide Weapon", "010019", [AwardCategory.CostumeNoelle, AwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Noelle - New Year's Weapon", "010010", [AwardCategory.CostumeNoelle, AwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Noelle - Celebratory Weapon", "010007", [AwardCategory.CostumeNoelle, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Noelle - Festive Weapon", "010017", [AwardCategory.CostumeNoelle, AwardCategory.CostumeFestive]),
            new AwardOptionInternal("Noelle - Phantasmal Weapon", "010008", [AwardCategory.CostumeFinalFantasy, AwardCategory.CostumeNoelle]),
            new AwardOptionInternal("Noelle - Fabled Weapon", "010014", [AwardCategory.CostumeSinoalice, AwardCategory.CostumeNoelle]),
            new AwardOptionInternal("Noelle - Abyssal Weapon", "010013", [AwardCategory.CostumeNoelle, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Noelle - Reborn Warlady", "010004", [AwardCategory.CostumeNoelle, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Noelle - Frozen-Heart Warlady", "010006", [AwardCategory.CostumeNoelle, AwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Fio - The Girl of Light", "019001", [AwardCategory.CostumeFio]),
            new AwardOptionInternal("Fio - Dissenting Girl", "019004", [AwardCategory.CostumeFio]),
            new AwardOptionInternal("Fio - Guardian Girl", "019006", [AwardCategory.CostumeFio]),
            new AwardOptionInternal("Fio - Abstract Girl", "019005", [AwardCategory.CostumeFio, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Fio - Lacrima Girl", "019016", [AwardCategory.CostumeFio, AwardCategory.CostumeLacrima]),
            new AwardOptionInternal("Fio - Mechanical Girl", "019003", [AwardCategory.CostumeFio, AwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Fio - Summer Girl", "019010", [AwardCategory.CostumeFio, AwardCategory.CostumeSummer]),
            new AwardOptionInternal("Fio - Yuletide Girl", "019015", [AwardCategory.CostumeFio, AwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Fio - New Year's Girl", "019011", [AwardCategory.CostumeFio, AwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Fio - Celebratory Girl", "019012", [AwardCategory.CostumeFio, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Fio - Festive Girl", "019018", [AwardCategory.CostumeFio, AwardCategory.CostumeFestive]),
            new AwardOptionInternal("Fio - Abyssal Girl", "019008", [AwardCategory.CostumeFio, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Fio - Divine Girl", "019019", [AwardCategory.CostumeFio, AwardCategory.CostumeDivine]),
            new AwardOptionInternal("Fio - Simulacrum Girl", "019013", [AwardCategory.CostumeFio]),
            new AwardOptionInternal("Fio - Intoner Girl", "019007", [AwardCategory.CostumeFio]),
            new AwardOptionInternal("Fio - Reborn Princess", "019002", [AwardCategory.CostumeFio, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Fio - Frozen-Heart Princess", "019009", [AwardCategory.CostumeFio, AwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Saryu - Avowed Witch", "022001", [AwardCategory.CostumeSaryu]),
            new AwardOptionInternal("Saryu - Guardian Witch", "022007", [AwardCategory.CostumeSaryu]),
            new AwardOptionInternal("Saryu - Abstract Witch", "022003", [AwardCategory.CostumeSaryu, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Saryu - Bloody Witch", "022005", [AwardCategory.CostumeSaryu, AwardCategory.CostumeBloody]),
            new AwardOptionInternal("Saryu - Summer Witch", "022006", [AwardCategory.CostumeSaryu, AwardCategory.CostumeSummer]),
            new AwardOptionInternal("Saryu - Yuletide Witch", "022009", [AwardCategory.CostumeSaryu, AwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Saryu - Celebratory Witch", "022004", [AwardCategory.CostumeSaryu, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Saryu - Festive Witch", "022012", [AwardCategory.CostumeSaryu, AwardCategory.CostumeFestive]),
            new AwardOptionInternal("Saryu - Abyssal Witch", "022011", [AwardCategory.CostumeSaryu, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Saryu - Fabled Witch", "022008", [AwardCategory.CostumeSinoalice, AwardCategory.CostumeSaryu]),
            new AwardOptionInternal("Saryu - Phantasmal Witch", "022010", [AwardCategory.CostumeFinalFantasy, AwardCategory.CostumeSaryu]),
            new AwardOptionInternal("Saryu - Reborn Sorceress", "022002", [AwardCategory.CostumeSaryu, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Priyet - Verboten Werebeast", "023001", [AwardCategory.CostumePriyet]),
            new AwardOptionInternal("Priyet - Guardian Werebeast", "023006", [AwardCategory.CostumePriyet]),
            new AwardOptionInternal("Priyet - Abstract Werebeast", "023003", [AwardCategory.CostumePriyet, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Priyet - Yuletide Werebeast", "023005", [AwardCategory.CostumePriyet, AwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Priyet - Celebratory Werebeast", "023004", [AwardCategory.CostumePriyet, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Priyet - Shadowbound Werebeast", "023007", [AwardCategory.CostumePriyet, AwardCategory.CostumeShadowbound]),
            new AwardOptionInternal("Priyet - Abyssal Werebeast", "023008", [AwardCategory.CostumePriyet, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Priyet - Reborn Fiend", "023002", [AwardCategory.CostumePriyet, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Marie - Praying Songstress", "024001", [AwardCategory.CostumeMarie]),
            new AwardOptionInternal("Marie - Guardian Songstress", "024007", [AwardCategory.CostumeMarie]),
            new AwardOptionInternal("Marie - Abstract Songstress", "024003", [AwardCategory.CostumeMarie, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Marie - Fractured Songstress", "024006", [AwardCategory.CostumeMarie, AwardCategory.CostumeFractured]),
            new AwardOptionInternal("Marie - Summer Songstress", "024008", [AwardCategory.CostumeMarie, AwardCategory.CostumeSummer]),
            new AwardOptionInternal("Marie - Yuletide Songstress", "024011", [AwardCategory.CostumeMarie, AwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Marie - New Year's Songstress", "024005", [AwardCategory.CostumeMarie, AwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Marie - Celebratory Songstress", "024004", [AwardCategory.CostumeMarie, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Marie - Abyssal Songstress", "024009", [AwardCategory.CostumeMarie, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Marie - Oathbound Songstress", "024010", [AwardCategory.CostumeDragonQuest, AwardCategory.CostumeMarie]),
            new AwardOptionInternal("Marie - Reborn Pillar", "024002", [AwardCategory.CostumeMarie, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Yurie - Obsessed Ruler", "025001", [AwardCategory.CostumeYurie]),
            new AwardOptionInternal("Yurie - Guardian Ruler", "025005", [AwardCategory.CostumeYurie]),
            new AwardOptionInternal("Yurie - Abstract Ruler", "025004", [AwardCategory.CostumeYurie, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Yurie - Summer Ruler", "025008", [AwardCategory.CostumeYurie, AwardCategory.CostumeSummer]),
            new AwardOptionInternal("Yurie - Yuletide Ruler", "025010", [AwardCategory.CostumeYurie, AwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Yurie - New Year's Ruler", "025006", [AwardCategory.CostumeYurie, AwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Yurie - Celebratory Ruler", "025003", [AwardCategory.CostumeYurie, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Yurie - Festive Ruler", "025011", [AwardCategory.CostumeYurie, AwardCategory.CostumeFestive]),
            new AwardOptionInternal("Yurie - Abyssal Ruler", "025007", [AwardCategory.CostumeYurie, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Yurie - Divine Ruler", "025009", [AwardCategory.CostumeYurie, AwardCategory.CostumeDivine]),
            new AwardOptionInternal("Yurie - Reborn Leader", "025002", [AwardCategory.CostumeYurie, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Yudil - Pilfering Boor", "027001", [AwardCategory.CostumeYudil]),
            new AwardOptionInternal("Yudil - Guardian Boor", "027005", [AwardCategory.CostumeYudil]),
            new AwardOptionInternal("Yudil - Abstract Boor", "027003", [AwardCategory.CostumeYudil, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Yudil - New Year's Boor", "027009", [AwardCategory.CostumeYudil, AwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Yudil - Celebratory Boor", "027004", [AwardCategory.CostumeYudil, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Yudil - Abyssal Boor", "027007", [AwardCategory.CostumeYudil, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Yudil - Divine Boor", "027008", [AwardCategory.CostumeYudil, AwardCategory.CostumeDivine]),
            new AwardOptionInternal("Yudil - Phantasmal Boor", "027006", [AwardCategory.CostumeFinalFantasy, AwardCategory.CostumeYudil]),
            new AwardOptionInternal("Yudil - Reborn Usurper", "027002", [AwardCategory.CostumeYudil, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Sarafa - Chained Belle", "026001", [AwardCategory.CostumeSarafa]),
            new AwardOptionInternal("Sarafa - Guardian Belle", "026004", [AwardCategory.CostumeSarafa]),
            new AwardOptionInternal("Sarafa - Abstract Belle", "026005", [AwardCategory.CostumeSarafa, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Sarafa - New Year's Belle", "026008", [AwardCategory.CostumeSarafa, AwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Sarafa - Celebratory Belle", "026003", [AwardCategory.CostumeSarafa, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Sarafa - Abyssal Belle", "026006", [AwardCategory.CostumeSarafa, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Sarafa - Shadowbound Belle", "026007", [AwardCategory.CostumeSarafa, AwardCategory.CostumeShadowbound]),
            new AwardOptionInternal("Sarafa - Oathbound Belle", "026009", [AwardCategory.CostumeSarafa, AwardCategory.CostumeDragonQuest]),
            new AwardOptionInternal("Sarafa - Reborn Monopolist", "026002", [AwardCategory.CostumeSarafa, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Hina - Dedicated Pupil", "020001", [AwardCategory.CostumeHina]),
            new AwardOptionInternal("Hina - Guardian Pupil", "020007", [AwardCategory.CostumeHina]),
            new AwardOptionInternal("Hina - Abstract Pupil", "020004", [AwardCategory.CostumeHina, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Hina - Mechanical Pupil", "020005", [AwardCategory.CostumeHina, AwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Hina - Celebratory Pupil", "020003", [AwardCategory.CostumeHina, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Hina - Abyssal Pupil", "020006", [AwardCategory.CostumeHina, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Hina - Reborn Prodigy", "049001", [AwardCategory.CostumeHina, AwardCategory.CostumeEx]),
            new AwardOptionInternal("Yuzuki - Devoted Student", "021001", [AwardCategory.CostumeYuzuki]),
            new AwardOptionInternal("Yuzuki - Guardian Student", "021007", [AwardCategory.CostumeYuzuki]),
            new AwardOptionInternal("Yuzuki - Abstract Student", "021005", [AwardCategory.CostumeYuzuki, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Yuzuki - Mechanical Student", "021004", [AwardCategory.CostumeYuzuki, AwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Yuzuki - Celebratory Student", "021003", [AwardCategory.CostumeYuzuki, AwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Yuzuki - Abyssal Student", "021006", [AwardCategory.CostumeYuzuki, AwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Yuzuki - Reborn Reject", "021002", [AwardCategory.CostumeYuzuki, AwardCategory.CostumeEx]),
            new AwardOptionInternal("10H - Sentinel Savior", "048001", [AwardCategory.Costume10H]),
            new AwardOptionInternal("10H - Abstract Savior", "048003", [AwardCategory.Costume10H, AwardCategory.CostumeAbstract]),
            new AwardOptionInternal("10H - Reborn Warden", "048004", [AwardCategory.Costume10H, AwardCategory.CostumeEx])
        ];
    }

    private static Award GenerateMamaAward(AwardCategory awardCategory, List<UserData> userData)
    {
        ImmutableList<MamaAwardUser> allRankings = GetAllMamaAwardRankings(awardCategory, userData);
        long[] topThree = allRankings.GroupBy(x => x.Value).Take(5).Select(x => x.Key).ToArray();
        List<AwardOption> options = allRankings.Where(x => topThree.Contains(x.Value))
            .GroupBy(x => x.Value)
            .Select(x => new AwardOption { Name = string.Join(", ", x.Select(y => y.Name)) })
            .ToList();

        return new Award
        {
            Category = awardCategory,
            OptionList = options,
            Winners = topThree
        };
    }

    private static ImmutableList<MamaAwardUser> GetAllMamaAwardRankings(AwardCategory awardCategory, List<UserData> userData)
    {
        IEnumerable<MamaAwardUser> rankings = awardCategory switch
        {
            AwardCategory.DaysLoggedInJp => userData
                .Where(x => x.Region == SystemRegion.JP && x.TotalLoginCount > 100)
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.TotalLoginCount)),
            AwardCategory.DaysLoggedInGl => userData
                .Where(x => x.Region == SystemRegion.GL && x.TotalLoginCount > 100)
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.TotalLoginCount)),
            AwardCategory.MaxForce => userData
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.MaxForce ?? 0)),
            AwardCategory.CostumesCollected => userData
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.CostumeCount)),
            AwardCategory.WeaponsCollected => userData
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.WeaponCount)),
            AwardCategory.AwakeningCount => userData
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.AwakeningCount)),
            AwardCategory.AvgArenaRank => userData
                .Where(x => x.ArenaRankings.Count > 0)
                .Select(x => new MamaAwardUser(x.UserId, x.Name, (long)Math.Round(x.ArenaRankings.Average(y => y.Rank)))),
            AwardCategory.AvgSubjRank => userData
                .Where(x => x.SubjugationRankings.Count > 0)
                .Select(x => new MamaAwardUser(x.UserId, x.Name, (long)Math.Round(x.SubjugationRankings.Average(y => y.Score)))),
            AwardCategory.SubjugationFireScore => userData
                .Where(x => x.SubjugationRankings.Any(x => x.AttributeType == AttributeType.FIRE))
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.SubjugationRankings.Where(x => x.AttributeType == AttributeType.FIRE).MaxBy(x => x.Score)!.Score)),
            AwardCategory.SubjugationWaterScore => userData
                .Where(x => x.SubjugationRankings.Any(x => x.AttributeType == AttributeType.WATER))
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.SubjugationRankings.Where(x => x.AttributeType == AttributeType.WATER).MaxBy(x => x.Score)!.Score)),
            AwardCategory.SubjugationWindScore => userData
                .Where(x => x.SubjugationRankings.Any(x => x.AttributeType == AttributeType.WIND))
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.SubjugationRankings.Where(x => x.AttributeType == AttributeType.WIND).MaxBy(x => x.Score)!.Score)),
            AwardCategory.SubjugationLightScore => userData
                .Where(x => x.SubjugationRankings.Any(x => x.AttributeType == AttributeType.LIGHT))
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.SubjugationRankings.Where(x => x.AttributeType == AttributeType.LIGHT).MaxBy(x => x.Score)!.Score)),
            AwardCategory.SubjugationDarkScore => userData
                .Where(x => x.SubjugationRankings.Any(x => x.AttributeType == AttributeType.DARK))
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.SubjugationRankings.Where(x => x.AttributeType == AttributeType.DARK).MaxBy(x => x.Score)!.Score)),
            AwardCategory.ShootingNormalScore => userData
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.ExplorationRankings.Find(y => y.ExplorationType == ExplorationType.Shooting && y.DifficultyType == ExplorationDifficultyType.Normal)?.Score ?? 0)),
            AwardCategory.ShootingHardScore => userData
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.ExplorationRankings.Find(y => y.ExplorationType == ExplorationType.Shooting && y.DifficultyType == ExplorationDifficultyType.Hard)?.Score ?? 0)),
            AwardCategory.FlyingMamaNormalScore => userData
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.ExplorationRankings.Find(y => y.ExplorationType == ExplorationType.FlyingMama && y.DifficultyType == ExplorationDifficultyType.Normal)?.Score ?? 0)),
            AwardCategory.FlyingMamaHardScore => userData
                .Select(x => new MamaAwardUser(x.UserId, x.Name, x.ExplorationRankings.Find(y => y.ExplorationType == ExplorationType.FlyingMama && y.DifficultyType == ExplorationDifficultyType.Hard)?.Score ?? 0)),
            _ => []
        };

        rankings = rankings.Where(x => x.Value > 0);

        return awardCategory switch
        {
            AwardCategory.AvgArenaRank => [.. rankings.OrderBy(x => x.Value).ThenBy(x => x.Name)],
            _ => [.. rankings.OrderByDescending(x => x.Value).ThenBy(x => x.Name)]
        };
    }

    private async Task SetWinnersAsync(List<Award> awards)
    {
        foreach (Award award in awards)
        {
            List<int> categoryVotes = await dbContext.UserSubmissions
                .SelectMany(x => x.Votes.Where(v => v.CommunityAwardCategory == award.Category).Select(v => v.Selection))
                .ToListAsync();

            var groupedCategoryVotes = categoryVotes.GroupBy(x => x).Select(x => new { Vote = x.Key, Count = x.Count() });
            int maxCount = groupedCategoryVotes.Max(x => x.Count);

            award.Winners = groupedCategoryVotes.Where(x => x.Count == maxCount).Select(x => (long)x.Vote).ToArray();
        }
    }
}

public record AwardOptionInternal(string Name, string ImagePath, List<AwardCategory> AwardCategories);

internal record MamaAwardUser(long Id, string Name, long Value);