// using Newtonsoft.Json;
// using PangeaCyber.Net;
// using PangeaCyber.Net.Redact;
// using PangeaCyber.Net.Exceptions;

// namespace PangeaCyber.Tests;

// ///
// public class RedactClientTests
// {
//     private RedactClient client;
//     TestEnvironment environment = TestEnvironment.LVE;

//     ///
//     public RedactClientTests()
//     {
//         // var cfg = Config.FromIntegrationEnvironment(environment);
//         var config = Config.FromIntegrationEnvironment(TestEnvironment.LVE);
//         this.client = new RedactClient(config);
//     }

//     [Fact]
//     public async Task TestRedactText()
//     {
//         var response = await client.RedactText(new RedactTextRequest.RedactTextRequestBuilder("Jenny Jenny... 415-867-5309").SetReturnResult(true).Build());

//         Assert.True(response.IsOK);
//         Assert.Equal("<PERSON>... <PHONE_NUMBER>", response.Result.RedactedText);
//         Assert.Equal(2, response.Result.Count);
//         Assert.Null(response.Result.Report);
//     }

//     [Fact]
//     public async Task TestRedactText_2()
//     {
//         var response = await client.RedactText(new RedactTextRequest.RedactTextRequestBuilder("Jenny Jenny... 415-867-5309").SetReturnResult(true).SetDebug(true).Build());

//         Assert.True(response.IsOK);
//         Assert.Equal("<PERSON>... <PHONE_NUMBER>", response.Result.RedactedText);
//         Assert.Equal(2, response.Result.Count);
//         Assert.NotNull(response.Result.Report);
//     }

//     [Fact]
//     public async Task TestRedactStructured()
//     {
//         var data = new Dictionary<string, object>
//         {
//             { "Name", "Jenny Jenny" },
//             { "Phone", "This is its number: 415-867-5309" }
//         };

//         var response = await client.RedactStructured(new RedactStructuredRequest.RedactStructuredRequestBuilder(data).SetReturnResult(true).Build());
//         var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

//         var expected = new Dictionary<string, object>
//         {
//             { "Name", "<PERSON>" },
//             { "Phone", "This is its number: <PHONE_NUMBER>" }
//         };

//         Assert.True(response.IsOK);
//         Assert.Equal(expected, converted);
//         Assert.Equal(2, response.Result.Count);
//         Assert.Null(response.Result.Report);
//     }

//     [Fact]
//     public async Task TestRedactStructured_2()
//     {
//         var data = new Dictionary<string, object>
//         {
//             { "Name", "Jenny Jenny" },
//             { "Phone", "This is its number: 415-867-5309" }
//         };

//         var response = await client.RedactStructured(new RedactStructuredRequest.RedactStructuredRequestBuilder(data).SetFormat("json").SetReturnResult(true).Build());
//         var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

//         var expected = new Dictionary<string, object>
//         {
//             { "Name", "<PERSON>" },
//             { "Phone", "This is its number: <PHONE_NUMBER>" }
//         };

//         Assert.True(response.IsOK);
//         Assert.Equal(expected, converted);
//         Assert.Null(response.Result.Report);
//     }

//     [Fact]
//     public async Task TestRedactStructured_3()
//     {
//         var data = new Dictionary<string, object>
//         {
//             { "Name", "Jenny Jenny" },
//             { "Phone", "This is its number: 415-867-5309" }
//         };

//         var response = await client.RedactStructured(new RedactStructuredRequest.RedactStructuredRequestBuilder(data).SetFormat("json").SetDebug(true).SetReturnResult(true).Build());
//         var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

//         var expected = new Dictionary<string, object>
//         {
//             { "Name", "<PERSON>" },
//             { "Phone", "This is its number: <PHONE_NUMBER>" }
//         };

//         Assert.True(response.IsOK);
//         Assert.Equal(expected, converted);
//         Assert.NotNull(response.Result.Report);
//     }


//     [Fact]
//     public async Task TestRedactStructured_4()
//     {
//         var data = new Dictionary<string, object>
//         {
//             { "Name", "Jenny Jenny" },
//             { "Phone", "This is its number: 415-867-5309" }
//         };

//         var response = await client.RedactStructured(new RedactStructuredRequest.RedactStructuredRequestBuilder(data).SetFormat("json").SetJsonp(new String[] { "Phone" }).SetReturnResult(true).Build());
//         var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

//         var expected = new Dictionary<string, object>
//         {
//             { "Name", "Jenny Jenny" },
//             { "Phone", "This is its number: <PHONE_NUMBER>" }
//         };

//         Assert.True(response.IsOK);
//         Assert.Equal(converted, expected);
//         Assert.Equal(1, response.Result.Count);
//         Assert.Null(response.Result.Report);
//     }

//     [Fact]
//     public async Task TestRedactStructured_5()
//     {
//         var data = new Dictionary<string, object>
//         {
//             { "Name", "Jenny Jenny" },
//             { "Phone", "This is its number: 415-867-5309" }
//         };


//         var response = await client.RedactStructured(new RedactStructuredRequest.RedactStructuredRequestBuilder(data).SetFormat("json").SetJsonp(new String[] { "Name", "Phone" }).SetRules(new String[] { "PHONE_NUMBER" }).SetReturnResult(true).Build());
//         var converted = ((Newtonsoft.Json.Linq.JObject)response.Result.RedactedData).ToObject<Dictionary<string, object>>();

//         var expected = new Dictionary<string, object>
//         {
//             { "Name", "Jenny Jenny" },
//             { "Phone", "This is its number: <PHONE_NUMBER>" }
//         };

//         Assert.True(response.IsOK);
//         Assert.Equal(converted, expected);
//         Assert.Equal(1, response.Result.Count);
//         Assert.Null(response.Result.Report);
//     }

//      [Fact]
//     public async Task testRedactTextUnauthorized()
//     {
//         Config cfg = Config.FromIntegrationEnvironment(environment);
// 		cfg.Token = "notarealtoken";
//         var fakeClient = new RedactClient(cfg);
//         await Assert.ThrowsAsync<UnauthorizedException>(async () => await fakeClient.RedactText(new RedactTextRequest.RedactTextRequestBuilder("Jenny Jenny... 415-867-5309").SetReturnResult(true).Build()));
//     }

//      [Fact]
//     public async Task TestRedactStructuredUnauthorized()
//     {
//         var data = new Dictionary<string, object>
//         {
//             { "Name", "Jenny Jenny" },
//             { "Phone", "This is its number: 415-867-5309" }
//         };

//         Config cfg = Config.FromIntegrationEnvironment(environment);
// 		cfg.Token = "notarealtoken";
//         var fakeClient = new RedactClient(cfg);
//         await Assert.ThrowsAsync<UnauthorizedException>(async () => await fakeClient.RedactStructured(new RedactStructuredRequest.RedactStructuredRequestBuilder(data).SetReturnResult(true).Build()));
//     }
// }