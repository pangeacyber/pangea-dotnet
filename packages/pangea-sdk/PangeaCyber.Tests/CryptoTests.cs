using PangeaCyber.Net;

namespace PangeaCyber.Tests
{
    public sealed class CryptoTests
    {
        [Fact]
        public void GenerateRsaKeyPair()
        {
            var keyPair = Crypto.GenerateRsaKeyPair(4096);
            Assert.NotNull(keyPair);
            Assert.NotNull(keyPair.Public);
            Assert.NotNull(keyPair.Private);
        }

        [Fact]
        public void PemExport()
        {
            var keyPair = Crypto.GenerateRsaKeyPair(4096);
            var exported = Crypto.AsymmetricPemExport(keyPair.Public);
            Assert.NotNull(exported);
            Assert.DoesNotContain("\r\n", exported, StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void PemExport_PrivateKey()
        {
            var keyPair = Crypto.GenerateRsaKeyPair(4096);
            Assert.Throws<ArgumentException>(
                () => Crypto.AsymmetricPemExport(keyPair.Private)
            );
        }
    }
}
