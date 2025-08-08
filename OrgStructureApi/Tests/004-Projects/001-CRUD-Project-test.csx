// CreateProject tests
tp.Test("CreateProject: Status code should be 201.", () =>
{
    var createResponse = tp.Responses["CreateProject"];
    Equal(201, createResponse.StatusCode());
});

// GetAllProjects tests
tp.Test("GetAllProjects: Status code should be 200.", () =>
{
    var getAllResponse = tp.Responses["GetAllProjects"];
    Equal(200, getAllResponse.StatusCode());
});

tp.Test("GetAllProjects: Response should include the created project.", () =>
{
    var jsonArray = tp.Responses["GetAllProjects"].GetBody<System.Text.Json.JsonElement>();

    bool found = false;

    foreach (var project in jsonArray.EnumerateArray())
    {
        var name = project.GetProperty("name").GetString();
        var code = project.GetProperty("code").GetString();

        if (name == "Project Phoenix" && code == "PROJ001")
        {
            found = true;
            break;
        }
    }

    True(found);
});

// UpdateProject tests
tp.Test("UpdateProject: Status code should be 204.", () =>
{
    var statusCode = tp.Responses["UpdateProject"].StatusCode();
    Equal(204, statusCode);
});

// GetUpdateProject tests
tp.Test("GetUpdateProject: Status code should be 200.", () =>
{
    Equal(200, tp.Responses["GetUpdateProject"].StatusCode());
});

tp.Test("GetUpdateProject: Response name should be updated.", () =>
{
    var json = tp.Responses["GetUpdateProject"].GetBody<System.Text.Json.JsonElement>();
    var name = json.GetProperty("name").GetString();
    Equal("Project Phoenix 0.1V", name);
});

tp.Test("GetUpdateProject: Response code should remain the same.", () =>
{
    var json = tp.Responses["GetUpdateProject"].GetBody<System.Text.Json.JsonElement>();
    var code = json.GetProperty("code").GetString();
    Equal("PROJ001", code);
});

// DeleteProject tests
tp.Test("DeleteProject: After deletion, project should not be found.", () =>
{
    var response = tp.Responses["GetDeletedProject"];
    var statusCode = response.StatusCode;
    True(statusCode == System.Net.HttpStatusCode.NotFound);
});