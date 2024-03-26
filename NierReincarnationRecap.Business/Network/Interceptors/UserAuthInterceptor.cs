using NierReincarnationRecap.Business.Network.Api;

namespace NierReincarnationRecap.Business.Network.Interceptors;

public class UserAuthInterceptor : INetworkInterceptor
{
    public async Task<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, Task<ResponseContext>> next)
    {
        var responseContext = await next(context);

        var response = responseContext.GetCommonResponse();

        RefreshToken(response);

        return responseContext;
    }

    private static void RefreshToken(CommonResponse common)
    {
        if (common is null || string.IsNullOrEmpty(common.Token)) return;

        Variables.Token = common.Token;
    }
}
