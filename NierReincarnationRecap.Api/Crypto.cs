using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace NierReincarnationRecap.Api;

public static class Crypto
{
    private static readonly byte[] Key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("CryptoKey")!);
    private static readonly byte[] IV = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("CryptoIV")!);

    public static string Encrypt(long userId, string salt)
    {
        using Aes aesAlg = Aes.Create();
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
        byte[] dataToEncrypt = Encoding.UTF8.GetBytes(userId.ToString() + salt);

        using MemoryStream msEncrypt = new();
        using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
        {
            csEncrypt.Write(dataToEncrypt);
        }
        return Base64UrlEncoder.Encode(msEncrypt.ToArray());
    }

    public static long Decrypt(string encryptedUserId)
    {
        byte[] cipherText = Base64UrlEncoder.DecodeBytes(encryptedUserId);

        using Aes aesAlg = Aes.Create();
        aesAlg.Key = Key;
        aesAlg.IV = IV;

        ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        using MemoryStream msDecrypt = new(cipherText);
        using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
        using StreamReader srDecrypt = new(csDecrypt);
        return long.Parse(srDecrypt.ReadToEnd()[..^2]);
    }
}
