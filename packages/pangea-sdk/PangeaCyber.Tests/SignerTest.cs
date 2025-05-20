using PangeaCyber.Net.Audit;
using Xunit;

namespace PangeaCyber.Tests;

public class SignerTest
{
    private const string PRIVATE_KEY_FILE = "./data/privkey";

    LogSigner signer;

    public SignerTest()
    {
        signer = new LogSigner(PRIVATE_KEY_FILE);
    }

    [Fact]
    public void TestSigner()
    {
        string pubKey = signer.GetPublicKey();
        Assert.Equal("-----BEGIN PUBLIC KEY-----\nMCowBQYDK2VwAyEAlvOyDMpK2DQ16NI8G41yINl01wMHzINBahtDPoh4+mE=\n-----END PUBLIC KEY-----\n", pubKey);
    }
}
