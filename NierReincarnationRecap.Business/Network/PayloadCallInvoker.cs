using Google.Protobuf;
using Grpc.Core;
using System.Buffers;
using System.Security.Cryptography;
using System.Text;

namespace NierReincarnationRecap.Business.Network;

/// <summary>
/// Initializes a new instance of the <see cref="DefaultCallInvoker"/> class.
/// </summary>
/// <param name="channel">Channel to use.</param>
public class PayloadCallInvoker(Channel channel) : DefaultCallInvoker(channel)
{
    private static Aes Aes => CreateAes();

    public static Func<byte[], byte[]> Encrypt = EncryptInternal;
    public static Func<byte[], byte[]> Decrypt = DecryptInternal;

    private readonly Channel channel = channel;

    private static Aes CreateAes()
    {
        Aes aes = Aes.Create();
        aes.Mode = CipherMode.CBC;
        aes.Key = Encoding.UTF8.GetBytes("1234567890ABCDEF");
        aes.IV = Encoding.UTF8.GetBytes("it8bAjktKdFIBYtU");

        return aes;
    }

    private static byte[] EncryptInternal(byte[] payload)
    {
        return Aes.CreateEncryptor().TransformFinalBlock(payload, 0, payload.Length);
    }

    private static byte[] DecryptInternal(byte[] receivedMessage)
    {
        return Aes.CreateDecryptor().TransformFinalBlock(receivedMessage, 0, receivedMessage.Length);
    }

    protected override CallInvocationDetails<TRequest, TResponse> CreateCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options)
    {
        return new CallInvocationDetails<TRequest, TResponse>(channel, method.FullName, host, CreateRequestMarshaller(method.RequestMarshaller), CreateResponseMarshaller(method.ResponseMarshaller), options);
    }

    private static Marshaller<TRequest> CreateRequestMarshaller<TRequest>(Marshaller<TRequest> req) where TRequest : class
    {
        return new Marshaller<TRequest>(
            (request, context) => Serialize(request as IMessage, context),
            context => Deserialize(context, req));
    }

    private Marshaller<TResponse> CreateResponseMarshaller<TResponse>(Marshaller<TResponse> res)
    {
        return new Marshaller<TResponse>(
            (request, context) => Serialize(request as IMessage, context),
            context => Deserialize(context, res));
    }

    private static void Serialize(IMessage message, SerializationContext context)
    {
        byte[] payload = message.ToByteArray();
        payload = Encrypt?.Invoke(payload) ?? payload;

        context.Complete(payload);
    }

    private static T Deserialize<T>(DeserializationContext context, Marshaller<T> res)
    {
        byte[] payload = context.PayloadAsNewBuffer();
        payload = Decrypt?.Invoke(payload) ?? payload;

        return res.ContextualDeserializer(new PayloadDeserializationContext(payload));
    }
}

internal class PayloadDeserializationContext(byte[] payload) : DeserializationContext
{
    private readonly byte[] Payload = payload;

    public override int PayloadLength { get; } = payload.Length;

    public override byte[] PayloadAsNewBuffer() => Payload;

    public override ReadOnlySequence<byte> PayloadAsReadOnlySequence() => new(Payload);
}
