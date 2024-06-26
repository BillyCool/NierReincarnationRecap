namespace NierReincarnationRecap.Business.Network;

public interface INetworkInterceptor
{
    public abstract Task<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, Task<ResponseContext>> next);
}
