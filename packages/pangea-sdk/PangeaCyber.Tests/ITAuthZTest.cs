using PangeaCyber.Net;
using PangeaCyber.Net.AuthZ;
using PangeaCyber.Net.AuthZ.Models;
using PangeaCyber.Net.AuthZ.Requests;

namespace PangeaCyber.Tests;

public class ITAuthZTest
{
    private readonly AuthZClient client;
    private readonly TestEnvironment environment = Helper.LoadTestEnvironment("authz", TestEnvironment.LVE);

    readonly string time;

    readonly string folder1;
    readonly string folder2;
    readonly string user1;
    readonly string user2;

    readonly string namespace_folder;
    readonly string namespace_user;
    readonly string relation_owner;
    readonly string relation_editor;
    readonly string relation_reader;

    public ITAuthZTest()
    {
        var config = Config.FromIntegrationEnvironment(environment);
        this.client = new AuthZClient.Builder(config).Build();
        time = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        folder1 = "folder_1_" + time;
        folder2 = "folder_2_" + time;
        user1 = "user_1_" + time;
        user2 = "user_2_" + time;

        namespace_folder = "folder";
        namespace_user = "user";
        relation_owner = "owner";
        relation_editor = "editor";
        relation_reader = "reader";
    }

    [Fact]
    public async Task TestIntegration()
    {
        var resource1 = new Resource(namespace_folder)
        {
            ID = folder1
        };
        var resource2 = new Resource(namespace_folder)
        {
            ID = folder2
        };
        var subject1 = new Subject(namespace_user)
        {
            ID = user1
        };
        var subject2 = new Subject(namespace_user)
        {
            ID = user2
        };

        var tuple1 = new Net.AuthZ.Models.Tuple(resource1, relation_reader, subject1);
        var tuple2 = new Net.AuthZ.Models.Tuple(resource1, relation_editor, subject2);
        var tuple3 = new Net.AuthZ.Models.Tuple(resource2, relation_editor, subject1);
        var tuple4 = new Net.AuthZ.Models.Tuple(resource2, relation_owner, subject2);

        // Tuple Create
        var createResp = await client.TupleCreate(new TupleCreateRequest(
            new Net.AuthZ.Models.Tuple[] { tuple1, tuple2, tuple3, tuple4 }
        ));

        Assert.Null(createResp.Result);

        // Tuple list with resource
        var filter = new FilterTupleList();
        filter.ResourceNamespace.Set(namespace_folder);
        filter.ResourceID.Set(folder1);

        var listResp = await client.TupleList(
            new TupleListRequest()
            {
                Filter = filter
            }
        );

        Assert.NotNull(listResp.Result);
        Assert.Equal(2, listResp.Result.Count);
        Assert.Equal(2, listResp.Result.Tuples.Length);

        // Tuple list with subject
        filter = new FilterTupleList();
        filter.SubjectNamespace.Set(namespace_user);
        filter.SubjectID.Set(user1);

        listResp = await client.TupleList(
            new TupleListRequest()
            {
                Filter = filter,
            }
        );
        Assert.NotNull(listResp.Result);
        Assert.Equal(2, listResp.Result.Count);
        Assert.Equal(2, listResp.Result.Tuples.Length);

        // Tuple delete
        var deleteResp = await client.TupleDelete(
            new TupleDeleteRequest(
                new Net.AuthZ.Models.Tuple[] { tuple1 }
            )
        );
        Assert.Null(deleteResp.Result);

        // Check no debug
        var checkResp = await client.Check(
            new CheckRequest(resource1, relation_editor, subject2)
        );

        Assert.NotNull(checkResp.Result);
        Assert.True(checkResp.Result.Allowed);
        Assert.Null(checkResp.Result.Debug);
        Assert.NotNull(checkResp.Result.SchemaID);

        // Check debug
        checkResp = await client.Check(
            new CheckRequest(resource1, relation_editor, subject2)
            {
                Debug = true
            }
        );

        Assert.NotNull(checkResp.Result);
        Assert.True(checkResp.Result.Allowed);
        Assert.NotNull(checkResp.Result.Debug);
        Assert.NotNull(checkResp.Result.SchemaID);

        // List resources
        var listResourcesResp = await client.ListResources(
            new ListResourcesRequest(namespace_folder, relation_editor, subject2)
        );

        Assert.Single(listResourcesResp.Result.IDs);

        // List subjects
        var listSubjectsResp = await client.ListSubjects(
            new ListSubjectsRequest(resource2, relation_editor)
        );

        Assert.Single(listSubjectsResp.Result.Subjects);
    }
}
