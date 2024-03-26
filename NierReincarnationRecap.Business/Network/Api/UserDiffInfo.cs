using Google.Protobuf.Collections;
using NierReincarnationRecap.Business.Proto;

namespace NierReincarnationRecap.Business.Network.Api;

public static class UserDiffInfo
{
    public static MapField<string, DiffData> GetUserDiff(ResponseContext responseContext)
    {
        return responseContext.ResponseType.FullName switch
        {
            //"Art.Framework.ApiNetwork.Grpc.Api.User.GetAndroidArgsResponse" => responseContext.GetResponseAs<GetAndroidArgsResponse>().Result?.DiffUserData,
            _ => []
        };
    }
}
