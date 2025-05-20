using System.Threading.Tasks;
using PangeaCyber.Net;
using PangeaCyber.Net.Exceptions;
using PangeaCyber.Net.Intel;
using Xunit;

namespace PangeaCyber.Tests.Integration
{
    public class ITIPIntelTest
    {
        private IPIntelClient client;
        private readonly TestEnvironment environment = Helper.LoadTestEnvironment("ip-intel", TestEnvironment.LVE);

        public ITIPIntelTest()
        {
            var config = Config.FromIntegrationEnvironment(environment);
            client = new IPIntelClient.Builder(config).Build();
        }


        [Fact]
        public async Task TestIPReputationMalicious_1()
        {
            // Default provider, not verbose by default, not raw by default;
            var response = await client.Reputation(new IPReputationRequest.Builder("93.231.182.110").Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPReputationMalicious_2()
        {
            // With provider, not verbose by default, not raw by default;
            var response = await client.Reputation(
                new IPReputationRequest.Builder("93.231.182.110").WithProvider("crowdstrike").Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPReputationMalicious_3()
        {
            // Default provider, no verbose, no raw;
            var response = await client.Reputation(
                new IPReputationRequest.Builder("93.231.182.110").WithVerbose(false).WithRaw(false).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPReputationMalicious_4()
        {
            // Default provider, verbose, no raw;
            var response = await client.Reputation(
                new IPReputationRequest.Builder("93.231.182.110").WithVerbose(true).WithRaw(false).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPReputationMalicious_5()
        {
            // Default provider, no verbose, raw;
            var response = await client.Reputation(
                new IPReputationRequest.Builder("93.231.182.110").WithVerbose(false).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPReputationMalicious_6()
        {
            // Default provider, verbose, raw;
            var response = await client.Reputation(
                new IPReputationRequest.Builder("93.231.182.110").WithVerbose(true).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPReputationMalicious_7()
        {
            // Provider, no verbose, no raw
            var response = await client.Reputation(
                new IPReputationRequest.Builder("93.231.182.110").WithProvider("crowdstrike").WithVerbose(false).WithRaw(false).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPReputationMalicious_8()
        {
            // Provider, verbose, raw
            var response = await client.Reputation(
                new IPReputationRequest.Builder("93.231.182.110").WithProvider("crowdstrike").WithVerbose(true).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("malicious", data.Verdict);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPReputationMaliciousBulk()
        {
            // Provider, verbose, raw
            var ips = new string[] { "93.231.182.110", "190.28.74.251" };

            var response = await client.ReputationBulk(
                new IPReputationBulkRequest.Builder(ips).WithProvider("crowdstrike").WithVerbose(true).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.Equal(2, data.Count);
        }

        [Fact]
        public async Task TestIPReputationMalicious_NotFound()
        {
            // Provider, verbose, raw
            var response = await client.Reputation(
                new IPReputationRequest.Builder("127.0.0.1").WithProvider("crowdstrike").WithVerbose(true).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotNull(data);
            Assert.NotEmpty(data.Verdict);
            Assert.NotNull(data.Category);
            Assert.NotNull(response.Result.Parameters);
        }

        [Fact]
        public async Task TestIPReputation_CymruProvider()
        {
            // Provider, verbose, raw
            var response = await client.Reputation(
                new IPReputationRequest.Builder("93.231.182.110").WithProvider("cymru").WithRaw(true).WithVerbose(true).Build()
            );
            Assert.True(response.IsOK);
            Assert.NotNull(response.Result.Data);
            Assert.NotNull(response.Result.Parameters);
        }

        [Fact]
        public async Task TestIPGeolocate_1()
        {
            // Default provider, not verbose by default, not raw by default;
            var response = await client.Geolocate(new IPGeolocateRequest.Builder("93.231.182.110").Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("Federal Republic Of Germany", data.Country);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPGeolocate_2()
        {
            // With provider, not verbose by default, not raw by default;
            var response = await client.Geolocate(
                new IPGeolocateRequest.Builder("93.231.182.110").WithProvider("digitalelement").Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("Federal Republic Of Germany", data.Country);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPGeolocate_3()
        {
            // Default provider, no verbose, no raw;
            var response = await client.Geolocate(
                new IPGeolocateRequest.Builder("93.231.182.110").WithVerbose(false).WithRaw(false).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("Federal Republic Of Germany", data.Country);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPGeolocate_4()
        {
            // Default provider, verbose, no raw;
            var response = await client.Geolocate(
                new IPGeolocateRequest.Builder("93.231.182.110").WithVerbose(true).WithRaw(false).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("Federal Republic Of Germany", data.Country);
            Assert.NotNull(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPGeolocate_5()
        {
            // Default provider, no verbose, raw;
            var response = await client.Geolocate(
                new IPGeolocateRequest.Builder("93.231.182.110").WithVerbose(false).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("Federal Republic Of Germany", data.Country);
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPGeolocate_6()
        {
            // Default provider, verbose, raw;
            var response = await client.Geolocate(
                new IPGeolocateRequest.Builder("93.231.182.110").WithVerbose(true).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("Federal Republic Of Germany", data.Country);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPGeolocate_7()
        {
            // Provider, no verbose, no raw
            var response = await client.Geolocate(
                new IPGeolocateRequest.Builder("93.231.182.110")
                    .WithProvider("digitalelement")
                    .WithVerbose(false)
                    .WithRaw(false)
                    .Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("Federal Republic Of Germany", data.Country);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPGeolocate_8()
        {
            // Provider, verbose, raw
            var response = await client.Geolocate(
                new IPGeolocateRequest.Builder("93.231.182.110").WithProvider("digitalelement").WithVerbose(true).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.Equal("Federal Republic Of Germany", data.Country);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPGeolocateMaliciousBulk()
        {
            // Provider, verbose, raw
            var ips = new string[] { "93.231.182.110", "190.28.74.251" };

            var response = await client.GeolocateBulk(
                new IPGeolocateBulkRequest.Builder(ips).WithVerbose(true).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.Equal(2, data.Count);
        }

        [Fact]
        public async Task TestIPDomain_1()
        {
            // Default provider, not verbose by default, not raw by default;
            var response = await client.GetDomain(new IPDomainRequest.Builder("24.235.114.61").Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.DomainFound);
            Assert.Equal("rogers.com", data.Domain);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPDomain_2()
        {
            // With provider, not verbose by default, not raw by default;
            var response = await client.GetDomain(
                new IPDomainRequest.Builder("24.235.114.61").WithProvider("digitalelement").Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.DomainFound);
            Assert.Equal("rogers.com", data.Domain);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPDomain_3()
        {
            // Default provider, no verbose, no raw;
            var response = await client.GetDomain(
                new IPDomainRequest.Builder("24.235.114.61").WithVerbose(false).WithRaw(false).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.DomainFound);
            Assert.Equal("rogers.com", data.Domain);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPDomain_4()
        {
            // Default provider, verbose, no raw;
            var response = await client.GetDomain(
                new IPDomainRequest.Builder("24.235.114.61").WithVerbose(true).WithRaw(false).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.DomainFound);
            Assert.Equal("rogers.com", data.Domain);
            Assert.NotNull(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPDomain_5()
        {
            // Default provider, no verbose, raw;
            var response = await client.GetDomain(
                new IPDomainRequest.Builder("24.235.114.61").WithProvider("digitalelement").WithVerbose(false).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.DomainFound);
            Assert.Equal("rogers.com", data.Domain);
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPDomain_6()
        {
            // Default provider, verbose, raw;
            var response = await client.GetDomain(
                new IPDomainRequest.Builder("24.235.114.61").WithVerbose(true).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.DomainFound);
            Assert.Equal("rogers.com", data.Domain);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPDomain_7()
        {
            // Provider, no verbose, no raw
            var response = await client.GetDomain(
                new IPDomainRequest.Builder("24.235.114.61").WithProvider("digitalelement").WithVerbose(false).WithRaw(false).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.DomainFound);
            Assert.Equal("rogers.com", data.Domain);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPDomain_8()
        {
            // Provider, verbose, raw
            var response = await client.GetDomain(
                new IPDomainRequest.Builder("24.235.114.61").WithProvider("digitalelement").WithVerbose(true).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.DomainFound);
            Assert.Equal("rogers.com", data.Domain);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPDomainMaliciousBulk()
        {
            // Provider, verbose, raw
            var ips = new string[] { "93.231.182.110", "190.28.74.251" };

            var response = await client.GetDomainBulk(
                new IPDomainBulkRequest.Builder(ips).WithVerbose(true).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.Equal(2, data.Count);
        }

        [Fact]
        public async Task TestIPDomain_NotFound()
        {
            // Provider, verbose, raw
            var response = await client.GetDomain(
                new IPDomainRequest.Builder("127.0.0.1").WithProvider("digitalelement").WithVerbose(true).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.False(data.DomainFound);
            Assert.Null(data.Domain);
            Assert.NotNull(response.Result.Parameters);
        }

        [Fact]
        public async Task TestIPVPN_1()
        {
            // Default provider, not verbose by default, not raw by default;
            var response = await client.IsVPN(new IPVPNRequest.Builder("2.56.189.74").Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsVPN);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPVPN_2()
        {
            // With provider, not verbose by default, not raw by default;
            var response = await client.IsVPN(
                new IPVPNRequest.Builder("2.56.189.74").WithProvider("digitalelement").Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsVPN);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPVPN_3()
        {
            // Default provider, no verbose, no raw;
            var response = await client.IsVPN(
                new IPVPNRequest.Builder("2.56.189.74").WithVerbose(false).WithRaw(false).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsVPN);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPVPN_4()
        {
            // Default provider, verbose, no raw;
            var response = await client.IsVPN(
                new IPVPNRequest.Builder("2.56.189.74").WithVerbose(true).WithRaw(false).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsVPN);
            Assert.NotNull(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPVPN_5()
        {
            // Default provider, no verbose, raw;
            var response = await client.IsVPN(new IPVPNRequest.Builder("2.56.189.74").WithVerbose(false).WithRaw(true).Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsVPN);
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPVPN_6()
        {
            // Default provider, verbose, raw;
            var response = await client.IsVPN(new IPVPNRequest.Builder("2.56.189.74").WithVerbose(true).WithRaw(true).Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsVPN);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPVPN_7()
        {
            // Provider, no verbose, no raw
            var response = await client.IsVPN(
                new IPVPNRequest.Builder("2.56.189.74")
                    .WithProvider("digitalelement")
                    .WithVerbose(false)
                    .WithRaw(false)
                    .Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsVPN);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPVPN_8()
        {
            // Provider, verbose, raw
            var response = await client.IsVPN(
                new IPVPNRequest.Builder("2.56.189.74")
                    .WithProvider("digitalelement")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsVPN);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPVPNMaliciousBulk()
        {
            // Provider, verbose, raw
            var ips = new string[] { "93.231.182.110", "190.28.74.251" };

            var response = await client.IsVPNBulk(
                new IPVPNBulkRequest.Builder(ips).WithVerbose(true).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.Equal(2, data.Count);
        }

        [Fact]
        public async Task TestIPVPN_NotFound()
        {
            // Provider, verbose, raw
            var response = await client.IsVPN(
                new IPVPNRequest.Builder("127.0.0.1")
                    .WithProvider("digitalelement")
                    .WithVerbose(true)
                    .WithRaw(true)
                    .Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotNull(data);
            Assert.False(data.IsVPN);
            Assert.NotNull(response.Result.Parameters);
        }

        [Fact]
        public async Task TestIPProxy_1()
        {
            // Default provider, not verbose by default, not raw by default;
            var response = await client.IsProxy(new IPProxyRequest.Builder("34.201.32.172").Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsProxy);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPProxy_2()
        {
            // With provider, not verbose by default, not raw by default;
            var response = await client.IsProxy(
                new IPProxyRequest.Builder("34.201.32.172").WithProvider("digitalelement").Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsProxy);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPProxy_3()
        {
            // Default provider, no verbose, no raw;
            var response = await client.IsProxy(
                new IPProxyRequest.Builder("34.201.32.172").WithVerbose(false).WithRaw(false).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsProxy);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPProxy_4()
        {
            // Default provider, verbose, no raw;
            var response = await client.IsProxy(
                new IPProxyRequest.Builder("34.201.32.172").WithVerbose(true).WithRaw(false).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsProxy);
            Assert.NotNull(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPProxy_5()
        {
            // Default provider, no verbose, raw;
            var response = await client.IsProxy(new IPProxyRequest.Builder("34.201.32.172").WithVerbose(false).WithRaw(true).Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsProxy);
            Assert.Null(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPProxy_6()
        {
            // Default provider, verbose, raw;
            var response = await client.IsProxy(new IPProxyRequest.Builder("34.201.32.172").WithVerbose(true).WithRaw(true).Build());
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsProxy);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPProxy_7()
        {
            // Provider, no verbose, no raw
            var response = await client.IsProxy(new IPProxyRequest.Builder("34.201.32.172")
                .WithProvider("digitalelement")
                .WithVerbose(false)
                .WithRaw(false)
                .Build());

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsProxy);
            Assert.Null(response.Result.Parameters);
            Assert.Null(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPProxy_8()
        {
            // Provider, verbose, raw
            var response = await client.IsProxy(new IPProxyRequest.Builder("34.201.32.172")
                .WithProvider("digitalelement")
                .WithVerbose(true)
                .WithRaw(true)
                .Build());

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.True(data.IsProxy);
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
        }

        [Fact]
        public async Task TestIPProxyMaliciousBulk()
        {
            // Provider, verbose, raw
            var ips = new string[] { "93.231.182.110", "190.28.74.251" };

            var response = await client.IsProxyBulk(
                new IPProxyBulkRequest.Builder(ips).WithVerbose(true).WithRaw(true).Build()
            );
            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotNull(response.Result.Parameters);
            Assert.NotNull(response.Result.RawData);
            Assert.Equal(2, data.Count);
        }

        [Fact]
        public async Task TestIPProxy_NotFound()
        {
            // Provider, verbose, raw
            var response = await client.IsProxy(new IPProxyRequest.Builder("127.0.0.1")
                .WithProvider("digitalelement")
                .WithVerbose(true)
                .WithRaw(true)
                .Build());

            Assert.True(response.IsOK);

            var data = response.Result.Data;
            Assert.NotNull(data);
            Assert.False(data.IsProxy);
            Assert.NotNull(response.Result.Parameters);
        }

        [Fact]
        public async Task TestEmptyIP()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await client.Reputation(new IPReputationRequest.Builder("").WithProvider("crowdstrike").WithVerbose(false).WithRaw(false).Build());
            });
        }

        [Fact]
        public async Task TestEmptyProvider()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await client.Reputation(new IPReputationRequest.Builder("93.231.182.110").WithProvider("").WithVerbose(false).WithRaw(false).Build());
            });
        }

        [Fact]
        public async Task TestEmptyNotValidProvider()
        {
            await Assert.ThrowsAsync<ValidationException>(async () =>
            {
                await client.Reputation(new IPReputationRequest.Builder("93.231.182.110").WithProvider("notavalidprovider").WithVerbose(false).WithRaw(false).Build());
            });
        }

        [Fact]
        public async Task TestUnauthorized()
        {
            var cfg = Config.FromIntegrationEnvironment(environment);
            cfg = new Config("notarealtoken") { Domain = cfg.Domain };
            var fakeClient = new IPIntelClient.Builder(cfg).Build();

            await Assert.ThrowsAsync<UnauthorizedException>(async () =>
            {
                await fakeClient.Reputation(new IPReputationRequest.Builder("93.231.182.110").WithProvider("crowdstrike").WithVerbose(false).WithRaw(false).Build());
            });
        }


    }
}
