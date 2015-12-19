namespace MobileCarMarket.Helpers
{
    using System.Text;

    using PCLCrypto;
    using static PCLCrypto.WinRTCrypto;

    public static class CryptoUtils
    {
        public static string GenerateHash(string input, string key)
        {
            var mac = MacAlgorithmProvider.OpenAlgorithm(MacAlgorithm.HmacSha1);
            var keyMaterial = CryptographicBuffer.ConvertStringToBinary(key, Encoding.UTF8);
            var cryptoKey = mac.CreateKey(keyMaterial);
            var hash = CryptographicEngine.Sign(cryptoKey, CryptographicBuffer.ConvertStringToBinary(input, Encoding.UTF8));
            return CryptographicBuffer.EncodeToBase64String(hash);
        }
    }
}
