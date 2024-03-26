using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace NierReincarnationRecap.Model.Enums;

public static class EnumExtensions
{
    public static string GetDisplayName(this Enum enumValue)
    {
        Type enumType = enumValue.GetType();
        string enumName = enumValue.ToString();
        MemberInfo member = enumType.GetMember(enumName)[0];

        if (Attribute.IsDefined(member, typeof(DisplayAttribute)))
        {
            DisplayAttribute displayAttribute = (DisplayAttribute)member.GetCustomAttribute(typeof(DisplayAttribute))!;
            return displayAttribute?.Name ?? enumName;
        }

        return enumName;
    }
}
