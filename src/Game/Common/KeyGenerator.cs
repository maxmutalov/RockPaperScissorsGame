using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System.Security.Cryptography;
using System.Text;

namespace Game.Common;

#pragma warning disable CS8602, CS8604, CS8618, CS8600
public static class KeyGenerator
{
    private static byte[] _randomNumber = new byte[32];
    private static String _key;

    public static String GeneratedKey => _key;

    public static void GenerateKey()
    {
        using var randomNumberGenerator = RandomNumberGenerator.Create();

        randomNumberGenerator.GetBytes(_randomNumber);

        _key = Convert.ToHexString(_randomNumber).Replace("-", "");
    }

    public static String GenerateHMAC(String computersMove)
    {
        byte[] bytesOfKey = Encoding.UTF8.GetBytes(GeneratedKey);

        string message = computersMove;
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);

        HMac hmac = new HMac(new Sha3Digest(256));
        hmac.Init(new KeyParameter(bytesOfKey));

        byte[] result = new byte[hmac.GetMacSize()];
        hmac.BlockUpdate(messageBytes, 0, messageBytes.Length);
        hmac.DoFinal(result, 0);

        return Convert.ToHexString(result).Replace("-", "");
    }
}
