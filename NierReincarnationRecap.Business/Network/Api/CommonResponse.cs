namespace NierReincarnationRecap.Business.Network.Api;

public class CommonResponse
{
    public int ScreenTransitionType;
    public string MessageCode;
    public string MessageText;
    public string MessageTextId;
    public long ResponseDatetime;
    public long OriginalResponseDatetime;
    public long MaintenanceDateTime;
    public string Token;
    public int AppVersionStatusType;
    public string DebugStackTrace;
    public string[] UpdateUserDataNames;
    public int[] AchievementIdList;
    public UpdatedUserData UpdatedUserData;

    public CommonResponse() => UpdatedUserData = new UpdatedUserData();
}
