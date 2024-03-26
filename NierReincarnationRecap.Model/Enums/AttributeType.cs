using System.ComponentModel.DataAnnotations;

namespace NierReincarnationRecap.Model.Enums;

public enum AttributeType
{
    UNKNOWN = 0,
    [Display(Name = "Dark")]
    DARK = 1,
    [Display(Name = "Fire")]
    FIRE = 2,
    [Display(Name = "Light")]
    LIGHT = 3,
    [Display(Name = "Nothing")]
    NOTHING = 4,
    [Display(Name = "Water")]
    WATER = 5,
    [Display(Name = "Wind")]
    WIND = 6
}
