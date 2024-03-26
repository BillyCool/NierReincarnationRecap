using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using NierReincarnationRecap.Business.Network.Interceptors;
using NierReincarnationRecap.Business.Proto;

namespace NierReincarnationRecap.Business.Network;

public class DarkClient
{
    private readonly Channel Channel = ChannelProvider.Channel;

    private readonly CancellationToken CancellationToken;

    private readonly TimeSpan Deadline = TimeSpan.FromMilliseconds(10000);

    private readonly INetworkInterceptor[] Interceptors = [
        new SetCommonHeaderInterceptor(),
        new UserAuthInterceptor()
    ];

    public Task<GetBackupTokenResponse?> GetBackupTokenAsync(GetBackupTokenRequest request)
    {
        return InvokeAsync<GetBackupTokenResponse, GetBackupTokenRequest>("UserService/GetBackupTokenAsync", request,
            ctx => new ResponseContext<GetBackupTokenResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GetBackupTokenAsync((GetBackupTokenRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<TransferUserResponse?> TransferUserAsync(TransferUserRequest request)
    {
        return InvokeAsync<TransferUserResponse, TransferUserRequest>("UserService/TransferUserAsync", request,
            ctx => new ResponseContext<TransferUserResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).TransferUserAsync((TransferUserRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<GetAndroidArgsResponse?> GetAndroidArgsAsync(GetAndroidArgsRequest request)
    {
        return InvokeAsync<GetAndroidArgsResponse, GetAndroidArgsRequest>("UserService/GetAndroidArgsAsync", request,
            ctx => new ResponseContext<GetAndroidArgsResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GetAndroidArgsAsync((GetAndroidArgsRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<AuthUserResponse?> AuthAsync(AuthUserRequest request)
    {
        return InvokeAsync<AuthUserResponse, AuthUserRequest>("UserService/AuthAsync", request,
            ctx => new ResponseContext<AuthUserResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).AuthAsync((AuthUserRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<UserDataGetNameResponseV2?> GetUserDataNameV2Async(Empty request)
    {
        return InvokeAsync<UserDataGetNameResponseV2, Empty>("DataService/GetUserDataNameV2Async", request,
            ctx =>
                new ResponseContext<UserDataGetNameResponseV2>(new DataService.DataServiceClient(GetCallInvoker(ctx.Channel)).GetUserDataNameV2Async((Empty)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<UserDataGetResponse?> GetUserDataAsync(UserDataGetRequest request)
    {
        return InvokeAsync<UserDataGetResponse, UserDataGetRequest>("DataService/GetUserDataAsync", request,
            ctx =>
                new ResponseContext<UserDataGetResponse>(new DataService.DataServiceClient(GetCallInvoker(ctx.Channel)).GetUserDataAsync((UserDataGetRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    #region Invokation methods

    private async Task<TResponse?> InvokeAsync<TResponse, TRequest>(string path, TRequest request, Func<RequestContext, ResponseContext> requestMethod)
    {
        var reqContext = new RequestContext(this, path, request!, Channel, [], Deadline, CancellationToken, Interceptors, requestMethod, typeof(TResponse));
        var resContext = await InvokeWithInterceptor(reqContext);
        return resContext != null ? await resContext.GetResponseAs<TResponse>() : default;
    }

    private static Task<ResponseContext> InvokeWithInterceptor(RequestContext context) => InvokeRecursive(context);

    private static Task<ResponseContext> InvokeRecursive(RequestContext context, int index = -1)
    {
        if (context.Interceptors.Length - 1 == index)
        {
            return context.RequestMethod?.Invoke(context).WaitResponseAsync()!;
        }

        if (context.Interceptors.Length <= index + 1)
        {
            throw new IndexOutOfRangeException();
        }

        var interceptor = context.Interceptors[index + 1];
        return interceptor.SendAsync(context, _ => InvokeRecursive(context, index + 1));
    }

    private static PayloadCallInvoker GetCallInvoker(Channel channel) => new(channel);

    #endregion Invokation methods
}
