using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Business;

public static class Variables
{
    public static SystemRegion Region { get; set; } = SystemRegion.GL;

    public static string? Token { get; set; }

    public static string? SessionKey { get; set; }

    public static long? SessionExpire { get; set; }

    public static string? MasterDataHash { get; set; } = "prd-us/20240215173418";

    public static long? UserId { get; set; }

    public static string? AdvertisingId { get; set; } = Guid.NewGuid().ToString("N");
}
