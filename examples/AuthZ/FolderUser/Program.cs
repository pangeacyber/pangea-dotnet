using PangeaCyber.Net;
using PangeaCyber.Net.AuthZ;
using PangeaCyber.Net.AuthZ.Models;
using PangeaCyber.Net.AuthZ.Requests;
using AuthZTuple = PangeaCyber.Net.AuthZ.Models.Tuple;

var token = Config.LoadEnvironmentVariable("PANGEA_AUTHZ_TOKEN");
var domain = Config.LoadEnvironmentVariable("PANGEA_DOMAIN");

var config = new Config(token, domain);
var client = new AuthZClient.Builder(config).Build();

// Mock data.
var time = DateTimeOffset.UtcNow.ToString("yyyyMMdd_HHmmss");
var folderId = $"folder_{time}";
var userId = $"user_{time}";

// Set up resources, subjects, and tuples.
var folder = new Resource("folder") { ID = folderId };
var user = new Subject("user") { ID = userId };
var tuple = new AuthZTuple(folder, "reader", user);

// Create a tuple.
await client.TupleCreate(new TupleCreateRequest(new[] { tuple }));

// Find the tuple that was just created.
var filter = new FilterTupleList();
filter.ResourceNamespace.Set("folder");
filter.ResourceID.Set(folderId);
var listResponse = await client.TupleList(new TupleListRequest() { Filter = filter });
_ = listResponse.Result.Tuples;
// ⇒ Tuple[1]

// Check if the user is an editor of the folder.
var checkResponse = await client.Check(new CheckRequest(folder, "editor", user));
Console.WriteLine($"Is editor? {checkResponse.Result.Allowed}");
// ⇒ false

// They're not an editor, but they are a reader.
checkResponse = await client.Check(new CheckRequest(folder, "reader", user));
Console.WriteLine($"Is reader? {checkResponse.Result.Allowed}");
// ⇒ true

// Delete the tuple.
await client.TupleDelete(new TupleDeleteRequest(new[] { tuple }));
