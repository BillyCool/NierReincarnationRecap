using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using NierReincarnationRecap.Model.Enums;
using NierReincarnationRecap.Model.ViewModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NierReincarnationRecap.Api;

public class AwardGenerationFunctions
{
    [Function("story-awards-json")]
    public async Task<IActionResult> StoryAwardsJson([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
    {
        List<Award> awards =
        [
            new Award()
            {
                Category = CommunityAwardCategory.StoryArc,
                OptionList =
                [
                    new() { Name = "The Girl and the Monster" },
                    new() { Name = "The Sun and the Moon" },
                    new() { Name = "The People and the World" }
                ]
            },
            new Award()
            {
                Category = CommunityAwardCategory.OstArc,
                OptionList =
                [
                    new() { Name = "The Girl and the Monster" },
                    new() { Name = "The Sun and the Moon" },
                    new() { Name = "The People and the World" }
                ]
            },
            new Award()
            {
                Category = CommunityAwardCategory.CharacterStory,
                OptionList = GetCharacterAwardOptionsByCategory(CommunityAwardCategory.CharacterStory)
            },
            new Award()
            {
                Category = CommunityAwardCategory.DarkMemoryStory,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeEx)
            },
            new Award()
            {
                Category = CommunityAwardCategory.LightMemoryStory,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeFrozenHeart)
            },
            new Award()
            {
                Category = CommunityAwardCategory.HiddenStory,
                OptionList = GetCharacterAwardOptionsByCategory(CommunityAwardCategory.HiddenStory)
            },
            new Award()
            {
                Category = CommunityAwardCategory.RecordStory,
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

        return new JsonResult(awards, new JsonSerializerOptions(JsonSerializerDefaults.Web) { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
    }

    [Function("character-awards-json")]
    public async Task<IActionResult> CharacterAwardsJson([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
    {
        List<Award> awards =
        [
            new Award()
            {
                Category = CommunityAwardCategory.CharacterVaEng,
                OptionList = GetCharacterAwardOptionsByCategory(CommunityAwardCategory.CharacterVaEng)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CharacterVaJp,
                OptionList = GetCharacterAwardOptionsByCategory(CommunityAwardCategory.CharacterVaJp)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeRion,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeRion)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeDimos,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeDimos)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeGayle,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeGayle)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeAkeha,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeAkeha)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeArgo,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeArgo)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeLevania,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeLevania)
            },
            new Award()
            {
                Category = CommunityAwardCategory.Costume063y,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.Costume063y)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeF66x,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeF66x)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeLars,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeLars)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeGriff,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeGriff)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeNoelle,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeNoelle)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeFio,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeFio)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeSaryu,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeSaryu)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumePriyet,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumePriyet)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeMarie,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeMarie)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeYurie,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeYurie)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeYudil,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeYudil)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeSarafa,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeSarafa)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeHina,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeHina)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeYuzuki,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeYuzuki)
            },
            new Award()
            {
                Category = CommunityAwardCategory.Costume10H,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.Costume10H)
            },
        ];

        return new JsonResult(awards, new JsonSerializerOptions(JsonSerializerDefaults.Web) { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
    }

    [Function("costume-series-awards-json")]
    public async Task<IActionResult> CostumeSeriesAwardsJson([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
    {
        List<Award> awards =
        [
            new Award()
            {
                Category = CommunityAwardCategory.CostumeAbstract,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeAbstract)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeBloody,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeBloody)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeBloodless,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeBloodless)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeLacrima,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeLacrima)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeFractured,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeFractured)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeMechanical,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeMechanical)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeSummer,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeSummer)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeHolyNight,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeHolyNight)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeNewYears,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeNewYears)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeCelebratory,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeCelebratory)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeFestive,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeFestive)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeShadowbound,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeShadowbound)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeAbyssal,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeAbyssal)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeDivine,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeDivine)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeEx,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeEx)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeFrozenHeart,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeFrozenHeart)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeDrakeNier,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeDrakeNier)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeSinoalice,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeSinoalice)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeFinalFantasy,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeFinalFantasy)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumePersona,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumePersona)
            },
            new Award()
            {
                Category = CommunityAwardCategory.CostumeDragonQuest,
                OptionList = GetCostumeAwardOptionsByCategory(CommunityAwardCategory.CostumeDragonQuest)
            }
        ];

        return new JsonResult(awards, new JsonSerializerOptions(JsonSerializerDefaults.Web) { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
    }

    private static List<AwardOption> GetCharacterAwardOptionsByCategory(CommunityAwardCategory awardCategory)
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
            new AwardOptionInternal("Mama / Pod 006", "000001", [CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp, CommunityAwardCategory.StoryCompanion]),
            new AwardOptionInternal("Carrier", "000002", [CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp, CommunityAwardCategory.StoryCompanion]),
            new AwardOptionInternal("Rion - Sickly Exile", "008001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.LightMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Dimos - Departed Gunman", "007001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.LightMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Gayle - Wounded Hunter", "009001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.LightMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Akeha - Twilight Assassin", "015001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.LightMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Argo - Apex Traveler", "006001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.LightMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Levania - Dark Monster", "005001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.LightMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("063y - Stalwart Prisoner", "011001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.LightMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("F66x - Distressed Captive", "012001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.LightMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Lars - Spiteful Soldier", "013001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.LightMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Griff - Harmonious Captain", "014001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.LightMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Noelle - Hidden Weapon", "010001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.LightMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Fio - The Girl of Light", "019001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.LightMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Dark Mama & Babe", "000003", [CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp, CommunityAwardCategory.StoryCompanion]),
            new AwardOptionInternal("Papa", "000004", [CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp, CommunityAwardCategory.StoryCompanion]),
            new AwardOptionInternal("Saryu - Avowed Witch", "022001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Priyet - Verboten Werebeast", "023001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Marie - Praying Songstress", "024001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Yurie - Obsessed Ruler", "025001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Yudil - Pilfering Boor", "027001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Sarafa - Chained Belle", "026001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Hina - Dedicated Pupil", "020001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("Yuzuki - Devoted Student", "021001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaEng, CommunityAwardCategory.CharacterVaJp]),
            new AwardOptionInternal("10H - Sentinel Savior", "048001", [CommunityAwardCategory.CharacterStory, CommunityAwardCategory.DarkMemoryStory, CommunityAwardCategory.HiddenStory, CommunityAwardCategory.CharacterVaJp]),
        ];
    }

    private static List<AwardOption> GetCostumeAwardOptionsByCategory(CommunityAwardCategory awardCategory)
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
            new AwardOptionInternal("2B - Praying Battler", "001001", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("2B - Shattered Battler", "001004", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("2B - Divergent Battler", "001002", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("2P - Mock Machine", "001003", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("2B - Alternate Battler", "001005", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("9S - Isolated Scanner", "002001", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("9S - Divergent Scanner", "002002", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("A2 - Vengeful Attacker", "003001", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("A2 - Divergent Attacker", "003002", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("The World-Ender - Soulful Lad", "016001", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("The World-Ender - Divergent Lad", "016002", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("The World-Ender - Alternate Lad", "016003", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("Emil - Puzzling Oddity", "017001", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("Emil - Divergent Oddity", "017002", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("Kainé - The Aerie Warrior", "018001", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("Kainé - Divergent Warrior", "018002", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("Zero - Progenitor Sister", "031001", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("Zero - Divergent Sister", "031002", [CommunityAwardCategory.CostumeDrakeNier]),
            new AwardOptionInternal("Joker - Caged Rebel", "044001", [CommunityAwardCategory.CostumePersona]),
            new AwardOptionInternal("Queen - Virtuous Priestess", "045001", [CommunityAwardCategory.CostumePersona]),
            new AwardOptionInternal("Fox - Insightful Emperor", "046001", [CommunityAwardCategory.CostumePersona]),
            new AwardOptionInternal("Crow - Scheming Justice", "047001", [CommunityAwardCategory.CostumePersona]),
            new AwardOptionInternal("Rion - Sickly Exile", "008001", [CommunityAwardCategory.CostumeRion]),
            new AwardOptionInternal("Rion - Dissenting Exile", "008003", [CommunityAwardCategory.CostumeRion]),
            new AwardOptionInternal("Rion - Guardian Exile", "008010", [CommunityAwardCategory.CostumeRion]),
            new AwardOptionInternal("Rion - Abstract Exile", "008005", [CommunityAwardCategory.CostumeRion, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Rion - Mechanical Exile", "008002", [CommunityAwardCategory.CostumeRion, CommunityAwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Rion - Summer Exile", "008009", [CommunityAwardCategory.CostumeRion, CommunityAwardCategory.CostumeSummer]),
            new AwardOptionInternal("Rion - Yuletide Exile", "008012", [CommunityAwardCategory.CostumeRion, CommunityAwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Rion - New Year's Exile", "008006", [CommunityAwardCategory.CostumeRion, CommunityAwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Rion - Celebratory Exile", "008013", [CommunityAwardCategory.CostumeRion, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Rion - Festive Exile", "008019", [CommunityAwardCategory.CostumeRion, CommunityAwardCategory.CostumeFestive]),
            new AwardOptionInternal("Rion - Shadowbound Exile", "008014", [CommunityAwardCategory.CostumeRion, CommunityAwardCategory.CostumeShadowbound]),
            new AwardOptionInternal("Rion - Abyssal Exile", "008007", [CommunityAwardCategory.CostumeRion, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Rion - Phantasmal Exile", "008011", [CommunityAwardCategory.CostumeFinalFantasy, CommunityAwardCategory.CostumeRion]),
            new AwardOptionInternal("Rion - Oathbound Exile", "008018", [CommunityAwardCategory.CostumeDragonQuest, CommunityAwardCategory.CostumeRion]),
            new AwardOptionInternal("Rion - Reborn Revolutionary", "008004", [CommunityAwardCategory.CostumeRion, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Rion - Frozen-Heart Revolutionary", "008008", [CommunityAwardCategory.CostumeRion, CommunityAwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Dimos - Departed Gunman", "007001", [CommunityAwardCategory.CostumeDimos]),
            new AwardOptionInternal("Dimos - Dissenting Gunman", "007003", [CommunityAwardCategory.CostumeDimos]),
            new AwardOptionInternal("Dimos - Guardian Gunman", "007005", [CommunityAwardCategory.CostumeDimos]),
            new AwardOptionInternal("Dimos - False Guardian Gunman", "007009", [CommunityAwardCategory.CostumeDimos]),
            new AwardOptionInternal("Dimos - Abstract Gunman", "007002", [CommunityAwardCategory.CostumeDimos, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Dimos - Bloody Gunman", "007006", [CommunityAwardCategory.CostumeDimos, CommunityAwardCategory.CostumeBloody]),
            new AwardOptionInternal("Dimos - Bloodless Gunman", "007013", [CommunityAwardCategory.CostumeDimos, CommunityAwardCategory.CostumeBloodless]),
            new AwardOptionInternal("Dimos - Fractured Gunman", "007008", [CommunityAwardCategory.CostumeDimos, CommunityAwardCategory.CostumeFractured]),
            new AwardOptionInternal("Dimos - Summer Gunman", "007015", [CommunityAwardCategory.CostumeDimos, CommunityAwardCategory.CostumeSummer]),
            new AwardOptionInternal("Dimos - New Year's Gunman", "007016", [CommunityAwardCategory.CostumeDimos, CommunityAwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Dimos - Celebratory Gunman", "007010", [CommunityAwardCategory.CostumeDimos, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Dimos - Abyssal Gunman", "007012", [CommunityAwardCategory.CostumeDimos, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Dimos - Reborn Automaton", "007004", [CommunityAwardCategory.CostumeDimos, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Dimos - Frozen-Heart Automaton", "007007", [CommunityAwardCategory.CostumeDimos, CommunityAwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Gayle - Wounded Hunter", "009001", [CommunityAwardCategory.CostumeGayle]),
            new AwardOptionInternal("Gayle - Dissenting Hunter", "009003", [CommunityAwardCategory.CostumeGayle]),
            new AwardOptionInternal("Gayle - Guardian Hunter", "009005", [CommunityAwardCategory.CostumeGayle]),
            new AwardOptionInternal("Gayle - Abstract Hunter", "009002", [CommunityAwardCategory.CostumeGayle, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Gayle - Bloody Hunter", "009006", [CommunityAwardCategory.CostumeGayle, CommunityAwardCategory.CostumeBloody]),
            new AwardOptionInternal("Gayle - Fractured Hunter", "009010", [CommunityAwardCategory.CostumeGayle, CommunityAwardCategory.CostumeFractured]),
            new AwardOptionInternal("Gayle - Mechanical Hunter", "009016", [CommunityAwardCategory.CostumeGayle, CommunityAwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Gayle - Summer Hunter", "009011", [CommunityAwardCategory.CostumeGayle, CommunityAwardCategory.CostumeSummer]),
            new AwardOptionInternal("Gayle - Yuletide Hunter", "009013", [CommunityAwardCategory.CostumeGayle, CommunityAwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Gayle - New Year's Hunter", "009007", [CommunityAwardCategory.CostumeGayle, CommunityAwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Gayle - Celebratory Hunter", "009009", [CommunityAwardCategory.CostumeGayle, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Gayle - Festive Hunter", "009015", [CommunityAwardCategory.CostumeGayle, CommunityAwardCategory.CostumeFestive]),
            new AwardOptionInternal("Gayle - Abyssal Hunter", "009012", [CommunityAwardCategory.CostumeGayle, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Gayle - Reborn Contractor", "009004", [CommunityAwardCategory.CostumeGayle, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Gayle - Frozen-Heart Contractor", "009008", [CommunityAwardCategory.CostumeGayle, CommunityAwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Akeha - Twilight Assassian", "015001", [CommunityAwardCategory.CostumeAkeha]),
            new AwardOptionInternal("Akeha - Dissenting Assassian", "015003", [CommunityAwardCategory.CostumeAkeha]),
            new AwardOptionInternal("Akeha - Guardian Assassian", "015011", [CommunityAwardCategory.CostumeAkeha]),
            new AwardOptionInternal("Akeha - False Guardian Assassian", "015013", [CommunityAwardCategory.CostumeAkeha]),
            new AwardOptionInternal("Akeha - Abstract Assassian", "015002", [CommunityAwardCategory.CostumeAkeha, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Akeha - Bloody Assassian", "015005", [CommunityAwardCategory.CostumeAkeha, CommunityAwardCategory.CostumeBloody]),
            new AwardOptionInternal("Akeha - Bloodless Assassian", "015010", [CommunityAwardCategory.CostumeAkeha, CommunityAwardCategory.CostumeBloodless]),
            new AwardOptionInternal("Akeha - Fractured Assassian", "015014", [CommunityAwardCategory.CostumeAkeha, CommunityAwardCategory.CostumeFractured]),
            new AwardOptionInternal("Akeha - Mechanical Assassian", "015012", [CommunityAwardCategory.CostumeAkeha, CommunityAwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Akeha - Summer Assassian", "015009", [CommunityAwardCategory.CostumeAkeha, CommunityAwardCategory.CostumeSummer]),
            new AwardOptionInternal("Akeha - Yuletide Assassian", "015007", [CommunityAwardCategory.CostumeAkeha, CommunityAwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Akeha - New Year's Assassian", "015018", [CommunityAwardCategory.CostumeAkeha, CommunityAwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Akeha - Celebratory Assassian", "015015", [CommunityAwardCategory.CostumeAkeha, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Akeha - Festive Assassian", "015021", [CommunityAwardCategory.CostumeAkeha, CommunityAwardCategory.CostumeFestive]),
            new AwardOptionInternal("Akeha - Abyssal Assassian", "015016", [CommunityAwardCategory.CostumeAkeha, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Akeha - Divine Assassian", "015020", [CommunityAwardCategory.CostumeAkeha, CommunityAwardCategory.CostumeDivine]),
            new AwardOptionInternal("Akeha - Intoner Assassian", "015006", [CommunityAwardCategory.CostumeAkeha]),
            new AwardOptionInternal("Akeha - Fabled Assassian", "015017", [CommunityAwardCategory.CostumeSinoalice, CommunityAwardCategory.CostumeAkeha]),
            new AwardOptionInternal("Akeha - Reborn Swordmaster", "015004", [CommunityAwardCategory.CostumeAkeha, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Akeha - Frozen-Heart Swordmaster", "015008", [CommunityAwardCategory.CostumeAkeha, CommunityAwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Argo - Apex Traveler", "006001", [CommunityAwardCategory.CostumeArgo]),
            new AwardOptionInternal("Argo - Dissenting Traveler", "006003", [CommunityAwardCategory.CostumeArgo]),
            new AwardOptionInternal("Argo - Guardian Traveler", "006005", [CommunityAwardCategory.CostumeArgo]),
            new AwardOptionInternal("Argo - Abstract Traveler", "006006", [CommunityAwardCategory.CostumeArgo, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Argo - Bloody Traveler", "006012", [CommunityAwardCategory.CostumeArgo, CommunityAwardCategory.CostumeBloody]),
            new AwardOptionInternal("Argo - Fractured Traveler", "006010", [CommunityAwardCategory.CostumeArgo, CommunityAwardCategory.CostumeFractured]),
            new AwardOptionInternal("Argo - Summer Traveler", "006008", [CommunityAwardCategory.CostumeArgo, CommunityAwardCategory.CostumeSummer]),
            new AwardOptionInternal("Argo - Yuletide Traveler", "006013", [CommunityAwardCategory.CostumeArgo, CommunityAwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Argo - Celebratory Traveler", "006009", [CommunityAwardCategory.CostumeArgo, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Argo - Shadowbound Traveler", "006014", [CommunityAwardCategory.CostumeArgo, CommunityAwardCategory.CostumeShadowbound]),
            new AwardOptionInternal("Argo - Patriotic Traveler", "006002", [CommunityAwardCategory.CostumeArgo]),
            new AwardOptionInternal("Argo - Reborn Adventurer", "006004", [CommunityAwardCategory.CostumeArgo, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Argo - Frozen-Heart Adventurer", "006007", [CommunityAwardCategory.CostumeArgo, CommunityAwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Levania - Human Monster", "004001", [CommunityAwardCategory.CostumeLevania]),
            new AwardOptionInternal("Levania - Dark Monster", "005001", [CommunityAwardCategory.CostumeLevania]),
            new AwardOptionInternal("Levania - Guardian Monster", "005007", [CommunityAwardCategory.CostumeLevania]),
            new AwardOptionInternal("Levania - Abstract Monster", "005002", [CommunityAwardCategory.CostumeLevania, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Levania - Bloody Monster", "005008", [CommunityAwardCategory.CostumeLevania, CommunityAwardCategory.CostumeBloody]),
            new AwardOptionInternal("Levania - Bloodless Monster", "005005", [CommunityAwardCategory.CostumeLevania, CommunityAwardCategory.CostumeBloodless]),
            new AwardOptionInternal("Levania - Lacrima Monster", "005010", [CommunityAwardCategory.CostumeLevania, CommunityAwardCategory.CostumeLacrima]),
            new AwardOptionInternal("Levania - Yuletide Monster", "005006", [CommunityAwardCategory.CostumeLevania, CommunityAwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Levania - Celebratory Monster", "005011", [CommunityAwardCategory.CostumeLevania, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Levania - Festive Monster", "005013", [CommunityAwardCategory.CostumeLevania, CommunityAwardCategory.CostumeFestive]),
            new AwardOptionInternal("Levania - Abyssal Monster", "005009", [CommunityAwardCategory.CostumeLevania, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Levania - Reborn Beast", "005003", [CommunityAwardCategory.CostumeLevania, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Levania - Frozen-Heart Beast", "005004", [CommunityAwardCategory.CostumeLevania, CommunityAwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("063y - Stalwart Prisoner", "011001", [CommunityAwardCategory.Costume063y]),
            new AwardOptionInternal("063y - Dissenting Prisoner", "011003", [CommunityAwardCategory.Costume063y]),
            new AwardOptionInternal("063y - Guardian Prisoner", "011009", [CommunityAwardCategory.Costume063y]),
            new AwardOptionInternal("063y - Abstract Prisoner", "011002", [CommunityAwardCategory.Costume063y, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("063y - Fractured Prisoner", "011005", [CommunityAwardCategory.Costume063y, CommunityAwardCategory.CostumeFractured]),
            new AwardOptionInternal("063y - Summer Prisoner", "011007", [CommunityAwardCategory.Costume063y, CommunityAwardCategory.CostumeSummer]),
            new AwardOptionInternal("063y - Yuletide Prisoner", "011015", [CommunityAwardCategory.Costume063y, CommunityAwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("063y - New Year's Prisoner", "011010", [CommunityAwardCategory.Costume063y, CommunityAwardCategory.CostumeNewYears]),
            new AwardOptionInternal("063y - Celebratory Prisoner", "011012", [CommunityAwardCategory.Costume063y, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("063y - Abyssal Prisoner", "011011", [CommunityAwardCategory.Costume063y, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("063y - Divine Prisoner", "011014", [CommunityAwardCategory.Costume063y, CommunityAwardCategory.CostumeDivine]),
            new AwardOptionInternal("063y - Phantasmal Prisoner", "011008", [CommunityAwardCategory.CostumeFinalFantasy, CommunityAwardCategory.Costume063y]),
            new AwardOptionInternal("063y - Reborn Convict", "011004", [CommunityAwardCategory.Costume063y, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("063y - Frozen-Heart Convict", "011006", [CommunityAwardCategory.Costume063y, CommunityAwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("F66x - Distressed Captive", "012001", [CommunityAwardCategory.CostumeF66x]),
            new AwardOptionInternal("F66x - Dissenting Captive", "012003", [CommunityAwardCategory.CostumeF66x]),
            new AwardOptionInternal("F66x - Guardian Captive", "012007", [CommunityAwardCategory.CostumeF66x]),
            new AwardOptionInternal("F66x - Abstract Captive", "012002", [CommunityAwardCategory.CostumeF66x, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("F66x - Bloody Captive", "012010", [CommunityAwardCategory.CostumeF66x, CommunityAwardCategory.CostumeBloody]),
            new AwardOptionInternal("F66x - Bloodless Captive", "012011", [CommunityAwardCategory.CostumeF66x, CommunityAwardCategory.CostumeBloodless]),
            new AwardOptionInternal("F66x - Lacrima Captive", "012005", [CommunityAwardCategory.CostumeF66x, CommunityAwardCategory.CostumeLacrima]),
            new AwardOptionInternal("F66x - Summer Captive", "012008", [CommunityAwardCategory.CostumeF66x, CommunityAwardCategory.CostumeSummer]),
            new AwardOptionInternal("F66x - Celebratory Captive", "012012", [CommunityAwardCategory.CostumeF66x, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("F66x - Abyssal Captive", "012009", [CommunityAwardCategory.CostumeF66x, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("F66x - Reborn Inmate", "012004", [CommunityAwardCategory.CostumeF66x, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("F66x - Frozen-Heart Inmate", "012006", [CommunityAwardCategory.CostumeF66x, CommunityAwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Lars - Spiteful Solder", "013001", [CommunityAwardCategory.CostumeLars]),
            new AwardOptionInternal("Lars - Dissenting Solder", "013003", [CommunityAwardCategory.CostumeLars]),
            new AwardOptionInternal("Lars - Guardian Solder", "013008", [CommunityAwardCategory.CostumeLars]),
            new AwardOptionInternal("Lars - Abstract Solder", "013004", [CommunityAwardCategory.CostumeLars, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Lars - Bloody Solder", "013010", [CommunityAwardCategory.CostumeLars, CommunityAwardCategory.CostumeBloody]),
            new AwardOptionInternal("Lars - Lacrima Solder", "013007", [CommunityAwardCategory.CostumeLars, CommunityAwardCategory.CostumeLacrima]),
            new AwardOptionInternal("Lars - Fractured Solder", "013005", [CommunityAwardCategory.CostumeLars, CommunityAwardCategory.CostumeFractured]),
            new AwardOptionInternal("Lars - Yuletide Solder", "013012", [CommunityAwardCategory.CostumeLars, CommunityAwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Lars - Celebratory Solder", "013009", [CommunityAwardCategory.CostumeLars, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Lars - Abyssal Solder", "013011", [CommunityAwardCategory.CostumeLars, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Lars - Phantasmal Solder", "013014", [CommunityAwardCategory.CostumeFinalFantasy, CommunityAwardCategory.CostumeLars]),
            new AwardOptionInternal("Lars - Reborn Truant", "013002", [CommunityAwardCategory.CostumeLars, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Lars - Frozen-Heart Truant", "013006", [CommunityAwardCategory.CostumeLars, CommunityAwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Griff - Harmonioud Captain", "014001", [CommunityAwardCategory.CostumeGriff]),
            new AwardOptionInternal("Griff - Dissenting Captain", "014003", [CommunityAwardCategory.CostumeGriff]),
            new AwardOptionInternal("Griff - Guardian Captain", "014005", [CommunityAwardCategory.CostumeGriff]),
            new AwardOptionInternal("Griff - False Guardian Captain", "014014", [CommunityAwardCategory.CostumeGriff]),
            new AwardOptionInternal("Griff - Abstract Captain", "014004", [CommunityAwardCategory.CostumeGriff, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Griff - Bloody Captain", "014010", [CommunityAwardCategory.CostumeGriff, CommunityAwardCategory.CostumeBloody]),
            new AwardOptionInternal("Griff - Lacrima Captain", "014008", [CommunityAwardCategory.CostumeGriff, CommunityAwardCategory.CostumeLacrima]),
            new AwardOptionInternal("Griff - Fractured Captain", "014009", [CommunityAwardCategory.CostumeGriff, CommunityAwardCategory.CostumeFractured]),
            new AwardOptionInternal("Griff - Mechanical Captain", "014016", [CommunityAwardCategory.CostumeGriff, CommunityAwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Griff - Yuletide Captain", "014011", [CommunityAwardCategory.CostumeGriff, CommunityAwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Griff - New Year's Captain", "014017", [CommunityAwardCategory.CostumeGriff, CommunityAwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Griff - Celebratory Captain", "014007", [CommunityAwardCategory.CostumeGriff, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Griff - Festive Captain", "014015", [CommunityAwardCategory.CostumeGriff, CommunityAwardCategory.CostumeFestive]),
            new AwardOptionInternal("Griff - Abyssal Captain", "014013", [CommunityAwardCategory.CostumeGriff, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Griff - Reborn Has-Been", "014002", [CommunityAwardCategory.CostumeGriff, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Griff - Frozen-Heart Has-Been", "014006", [CommunityAwardCategory.CostumeGriff, CommunityAwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Noelle - Hidden Weapon", "010001", [CommunityAwardCategory.CostumeNoelle]),
            new AwardOptionInternal("Noelle - Dissenting Weapon", "010003", [CommunityAwardCategory.CostumeNoelle]),
            new AwardOptionInternal("Noelle - Guardian Weapon", "010005", [CommunityAwardCategory.CostumeNoelle]),
            new AwardOptionInternal("Noelle - Abstract Weapon", "010002", [CommunityAwardCategory.CostumeNoelle, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Noelle - Bloody Weapon", "010011", [CommunityAwardCategory.CostumeNoelle, CommunityAwardCategory.CostumeBloody]),
            new AwardOptionInternal("Noelle - Bloodless Weapon", "010009", [CommunityAwardCategory.CostumeNoelle, CommunityAwardCategory.CostumeBloodless]),
            new AwardOptionInternal("Noelle - Fractured Weapon", "010012", [CommunityAwardCategory.CostumeNoelle, CommunityAwardCategory.CostumeFractured]),
            new AwardOptionInternal("Noelle - Mechanical Weapon", "010018", [CommunityAwardCategory.CostumeNoelle, CommunityAwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Noelle - Summer Weapon", "010016", [CommunityAwardCategory.CostumeNoelle, CommunityAwardCategory.CostumeSummer]),
            new AwardOptionInternal("Noelle - Yuletide Weapon", "010019", [CommunityAwardCategory.CostumeNoelle, CommunityAwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Noelle - New Year's Weapon", "010010", [CommunityAwardCategory.CostumeNoelle, CommunityAwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Noelle - Celebratory Weapon", "010007", [CommunityAwardCategory.CostumeNoelle, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Noelle - Festive Weapon", "010017", [CommunityAwardCategory.CostumeNoelle, CommunityAwardCategory.CostumeFestive]),
            new AwardOptionInternal("Noelle - Phantasmal Weapon", "010008", [CommunityAwardCategory.CostumeFinalFantasy, CommunityAwardCategory.CostumeNoelle]),
            new AwardOptionInternal("Noelle - Fabled Weapon", "010014", [CommunityAwardCategory.CostumeSinoalice, CommunityAwardCategory.CostumeNoelle]),
            new AwardOptionInternal("Noelle - Abyssal Weapon", "010013", [CommunityAwardCategory.CostumeNoelle, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Noelle - Reborn Warlady", "010004", [CommunityAwardCategory.CostumeNoelle, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Noelle - Frozen-Heart Warlady", "010006", [CommunityAwardCategory.CostumeNoelle, CommunityAwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Fio - The Girl of Light", "019001", [CommunityAwardCategory.CostumeFio]),
            new AwardOptionInternal("Fio - Dissenting Girl", "019004", [CommunityAwardCategory.CostumeFio]),
            new AwardOptionInternal("Fio - Guardian Girl", "019006", [CommunityAwardCategory.CostumeFio]),
            new AwardOptionInternal("Fio - Abstract Girl", "019005", [CommunityAwardCategory.CostumeFio, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Fio - Lacrima Girl", "019016", [CommunityAwardCategory.CostumeFio, CommunityAwardCategory.CostumeLacrima]),
            new AwardOptionInternal("Fio - Mechanical Girl", "019003", [CommunityAwardCategory.CostumeFio, CommunityAwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Fio - Summer Girl", "019010", [CommunityAwardCategory.CostumeFio, CommunityAwardCategory.CostumeSummer]),
            new AwardOptionInternal("Fio - Yuletide Girl", "019015", [CommunityAwardCategory.CostumeFio, CommunityAwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Fio - New Year's Girl", "019011", [CommunityAwardCategory.CostumeFio, CommunityAwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Fio - Celebratory Girl", "019012", [CommunityAwardCategory.CostumeFio, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Fio - Festive Girl", "019018", [CommunityAwardCategory.CostumeFio, CommunityAwardCategory.CostumeFestive]),
            new AwardOptionInternal("Fio - Abyssal Girl", "019008", [CommunityAwardCategory.CostumeFio, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Fio - Divine Girl", "019019", [CommunityAwardCategory.CostumeFio, CommunityAwardCategory.CostumeDivine]),
            new AwardOptionInternal("Fio - Simulacrum Girl", "019013", [CommunityAwardCategory.CostumeFio]),
            new AwardOptionInternal("Fio - Intoner Girl", "019007", [CommunityAwardCategory.CostumeFio]),
            new AwardOptionInternal("Fio - Reborn Princess", "019002", [CommunityAwardCategory.CostumeFio, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Fio - Frozen-Heart Princess", "019009", [CommunityAwardCategory.CostumeFio, CommunityAwardCategory.CostumeFrozenHeart]),
            new AwardOptionInternal("Saryu - Avowed Witch", "022001", [CommunityAwardCategory.CostumeSaryu]),
            new AwardOptionInternal("Saryu - Guardian Witch", "022007", [CommunityAwardCategory.CostumeSaryu]),
            new AwardOptionInternal("Saryu - Abstract Witch", "022003", [CommunityAwardCategory.CostumeSaryu, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Saryu - Bloody Witch", "022005", [CommunityAwardCategory.CostumeSaryu, CommunityAwardCategory.CostumeBloody]),
            new AwardOptionInternal("Saryu - Summer Witch", "022006", [CommunityAwardCategory.CostumeSaryu, CommunityAwardCategory.CostumeSummer]),
            new AwardOptionInternal("Saryu - Yuletide Witch", "022009", [CommunityAwardCategory.CostumeSaryu, CommunityAwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Saryu - Celebratory Witch", "022004", [CommunityAwardCategory.CostumeSaryu, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Saryu - Festive Witch", "022012", [CommunityAwardCategory.CostumeSaryu, CommunityAwardCategory.CostumeFestive]),
            new AwardOptionInternal("Saryu - Abyssal Witch", "022011", [CommunityAwardCategory.CostumeSaryu, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Saryu - Fabled Witch", "022008", [CommunityAwardCategory.CostumeSinoalice, CommunityAwardCategory.CostumeSaryu]),
            new AwardOptionInternal("Saryu - Phantasmal Witch", "022010", [CommunityAwardCategory.CostumeFinalFantasy, CommunityAwardCategory.CostumeSaryu]),
            new AwardOptionInternal("Saryu - Reborn Sorceress", "022002", [CommunityAwardCategory.CostumeSaryu, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Priyet - Verboten Werebeast", "023001", [CommunityAwardCategory.CostumePriyet]),
            new AwardOptionInternal("Priyet - Guardian Werebeast", "023006", [CommunityAwardCategory.CostumePriyet]),
            new AwardOptionInternal("Priyet - Abstract Werebeast", "023003", [CommunityAwardCategory.CostumePriyet, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Priyet - Yuletide Werebeast", "023005", [CommunityAwardCategory.CostumePriyet, CommunityAwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Priyet - Celebratory Werebeast", "023004", [CommunityAwardCategory.CostumePriyet, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Priyet - Shadowbound Werebeast", "023007", [CommunityAwardCategory.CostumePriyet, CommunityAwardCategory.CostumeShadowbound]),
            new AwardOptionInternal("Priyet - Abyssal Werebeast", "023008", [CommunityAwardCategory.CostumePriyet, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Priyet - Reborn Fiend", "023002", [CommunityAwardCategory.CostumePriyet, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Marie - Praying Songstress", "024001", [CommunityAwardCategory.CostumeMarie]),
            new AwardOptionInternal("Marie - Guardian Songstress", "024007", [CommunityAwardCategory.CostumeMarie]),
            new AwardOptionInternal("Marie - Abstract Songstress", "024003", [CommunityAwardCategory.CostumeMarie, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Marie - Fractured Songstress", "024006", [CommunityAwardCategory.CostumeMarie, CommunityAwardCategory.CostumeFractured]),
            new AwardOptionInternal("Marie - Summer Songstress", "024008", [CommunityAwardCategory.CostumeMarie, CommunityAwardCategory.CostumeSummer]),
            new AwardOptionInternal("Marie - Yuletide Songstress", "024011", [CommunityAwardCategory.CostumeMarie, CommunityAwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Marie - New Year's Songstress", "024005", [CommunityAwardCategory.CostumeMarie, CommunityAwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Marie - Celebratory Songstress", "024004", [CommunityAwardCategory.CostumeMarie, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Marie - Abyssal Songstress", "024009", [CommunityAwardCategory.CostumeMarie, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Marie - Oathbound Songstress", "024010", [CommunityAwardCategory.CostumeDragonQuest, CommunityAwardCategory.CostumeMarie]),
            new AwardOptionInternal("Marie - Reborn Pillar", "024002", [CommunityAwardCategory.CostumeMarie, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Yurie - Obsessed Ruler", "025001", [CommunityAwardCategory.CostumeYurie]),
            new AwardOptionInternal("Yurie - Guardian Ruler", "025005", [CommunityAwardCategory.CostumeYurie]),
            new AwardOptionInternal("Yurie - Abstract Ruler", "025004", [CommunityAwardCategory.CostumeYurie, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Yurie - Summer Ruler", "025008", [CommunityAwardCategory.CostumeYurie, CommunityAwardCategory.CostumeSummer]),
            new AwardOptionInternal("Yurie - Yuletide Ruler", "025010", [CommunityAwardCategory.CostumeYurie, CommunityAwardCategory.CostumeHolyNight]),
            new AwardOptionInternal("Yurie - New Year's Ruler", "025006", [CommunityAwardCategory.CostumeYurie, CommunityAwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Yurie - Celebratory Ruler", "025003", [CommunityAwardCategory.CostumeYurie, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Yurie - Festive Ruler", "025011", [CommunityAwardCategory.CostumeYurie, CommunityAwardCategory.CostumeFestive]),
            new AwardOptionInternal("Yurie - Abyssal Ruler", "025007", [CommunityAwardCategory.CostumeYurie, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Yurie - Divine Ruler", "025009", [CommunityAwardCategory.CostumeYurie, CommunityAwardCategory.CostumeDivine]),
            new AwardOptionInternal("Yurie - Reborn Leader", "025002", [CommunityAwardCategory.CostumeYurie, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Yudil - Pilfering Boor", "027001", [CommunityAwardCategory.CostumeYudil]),
            new AwardOptionInternal("Yudil - Guardian Boor", "027005", [CommunityAwardCategory.CostumeYudil]),
            new AwardOptionInternal("Yudil - Abstract Boor", "027003", [CommunityAwardCategory.CostumeYudil, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Yudil - New Year's Boor", "027009", [CommunityAwardCategory.CostumeYudil, CommunityAwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Yudil - Celebratory Boor", "027004", [CommunityAwardCategory.CostumeYudil, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Yudil - Abyssal Boor", "027007", [CommunityAwardCategory.CostumeYudil, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Yudil - Divine Boor", "027008", [CommunityAwardCategory.CostumeYudil, CommunityAwardCategory.CostumeDivine]),
            new AwardOptionInternal("Yudil - Phantasmal Boor", "027006", [CommunityAwardCategory.CostumeFinalFantasy, CommunityAwardCategory.CostumeYudil]),
            new AwardOptionInternal("Yudil - Reborn Usurper", "027002", [CommunityAwardCategory.CostumeYudil, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Sarafa - Chained Belle", "026001", [CommunityAwardCategory.CostumeSarafa]),
            new AwardOptionInternal("Sarafa - Guardian Belle", "026004", [CommunityAwardCategory.CostumeSarafa]),
            new AwardOptionInternal("Sarafa - Abstract Belle", "026005", [CommunityAwardCategory.CostumeSarafa, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Sarafa - New Year's Belle", "026008", [CommunityAwardCategory.CostumeSarafa, CommunityAwardCategory.CostumeNewYears]),
            new AwardOptionInternal("Sarafa - Celebratory Belle", "026003", [CommunityAwardCategory.CostumeSarafa, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Sarafa - Abyssal Belle", "026006", [CommunityAwardCategory.CostumeSarafa, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Sarafa - Shadowbound Belle", "026007", [CommunityAwardCategory.CostumeSarafa, CommunityAwardCategory.CostumeShadowbound]),
            new AwardOptionInternal("Sarafa - Oathbound Belle", "026009", [CommunityAwardCategory.CostumeSarafa, CommunityAwardCategory.CostumeDragonQuest]),
            new AwardOptionInternal("Sarafa - Reborn Monopolist", "026002", [CommunityAwardCategory.CostumeSarafa, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Hina - Dedicated Pupil", "020001", [CommunityAwardCategory.CostumeHina]),
            new AwardOptionInternal("Hina - Guardian Pupil", "020007", [CommunityAwardCategory.CostumeHina]),
            new AwardOptionInternal("Hina - Abstract Pupil", "020004", [CommunityAwardCategory.CostumeHina, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Hina - Mechanical Pupil", "020005", [CommunityAwardCategory.CostumeHina, CommunityAwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Hina - Celebratory Pupil", "020003", [CommunityAwardCategory.CostumeHina, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Hina - Abyssal Pupil", "020006", [CommunityAwardCategory.CostumeHina, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Hina - Reborn Prodigy", "049001", [CommunityAwardCategory.CostumeHina, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("Yuzuki - Devoted Student", "021001", [CommunityAwardCategory.CostumeYuzuki]),
            new AwardOptionInternal("Yuzuki - Guardian Student", "021007", [CommunityAwardCategory.CostumeYuzuki]),
            new AwardOptionInternal("Yuzuki - Abstract Student", "021005", [CommunityAwardCategory.CostumeYuzuki, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("Yuzuki - Mechanical Student", "021004", [CommunityAwardCategory.CostumeYuzuki, CommunityAwardCategory.CostumeMechanical]),
            new AwardOptionInternal("Yuzuki - Celebratory Student", "021003", [CommunityAwardCategory.CostumeYuzuki, CommunityAwardCategory.CostumeCelebratory]),
            new AwardOptionInternal("Yuzuki - Abyssal Student", "021006", [CommunityAwardCategory.CostumeYuzuki, CommunityAwardCategory.CostumeAbyssal]),
            new AwardOptionInternal("Yuzuki - Reborn Reject", "021002", [CommunityAwardCategory.CostumeYuzuki, CommunityAwardCategory.CostumeEx]),
            new AwardOptionInternal("10H - Sentinel Savior", "048001", [CommunityAwardCategory.Costume10H]),
            new AwardOptionInternal("10H - Abstract Savior", "048003", [CommunityAwardCategory.Costume10H, CommunityAwardCategory.CostumeAbstract]),
            new AwardOptionInternal("10H - Reborn Warden", "048004", [CommunityAwardCategory.Costume10H, CommunityAwardCategory.CostumeEx])
        ];
    }
}

public record AwardOptionInternal(string Name, string ImagePath, List<CommunityAwardCategory> AwardCategories);
