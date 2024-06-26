using Grpc.Core;

namespace NierReincarnationRecap.Business.Network;

public class RequestContext
{
    private readonly DarkClient _client;

    public string MethodPath { get; }

    public object Request { get; }

    public Channel Channel { get; set; }

    public Metadata Headers { get; }

    public DateTime? Deadline => DateTime.UtcNow.Add(TimeOut);

    public TimeSpan TimeOut { get; }

    public CancellationToken CancellationToken { get; }

    public int RequestNo { get; set; }

    internal INetworkInterceptor[] Interceptors { get; }

    internal Func<RequestContext, ResponseContext> RequestMethod { get; }

    internal RequestContext(DarkClient client, string path, object request, Channel channel, Metadata headers,
        TimeSpan timeOut, CancellationToken cancellationToken, INetworkInterceptor[] interceptors,
        Func<RequestContext, ResponseContext> requestMethod, Type responseContextType)
    {
        _client = client;
        MethodPath = path;
        Request = request;
        Channel = channel;
        Headers = headers;
        TimeOut = timeOut;
        CancellationToken = cancellationToken;
        Interceptors = interceptors;
        RequestMethod = requestMethod;
        RequestNo = 0;
    }

    public void UpdateChannel(Channel channel) => Channel = channel;
}
