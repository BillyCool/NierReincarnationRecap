using Grpc.Core;
using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Business.Network;

public static class ChannelProvider
{
    private const int GRPC_KEEPALIVE_TIME_MS = 2000;

    private const int GRPC_KEEPALIVE_TIMEOUT_MS = 3000;

    private const int GRPC_HTTP2_MIN_TIME_BETWEEEN_PINGS_MS = 5000;

    private static Channel _channel;

    public static Channel Channel => _channel ?? Initialize();

    private static Channel Initialize()
    {
        List<ChannelOption> channelOptions =
        [
            new ChannelOption("grpc.keepalive_time_ms", GRPC_KEEPALIVE_TIME_MS),
            new ChannelOption("grpc.keepalive_timeout_ms", GRPC_KEEPALIVE_TIMEOUT_MS),
            new ChannelOption("grpc.http2.min_time_between_pings_ms", GRPC_HTTP2_MIN_TIME_BETWEEEN_PINGS_MS),
            new ChannelOption("grpc.max_receive_message_length", 100 * 1024 * 1024)
        ];

        _channel = new Channel(Variables.Region == SystemRegion.GL
            ? "api.app.nierreincarnation.com:443"
            : "api.app.nierreincarnation.jp:443",
            new SslCredentials(), channelOptions);
        return _channel;
    }
}
