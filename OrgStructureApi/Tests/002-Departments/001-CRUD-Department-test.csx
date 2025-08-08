tp.Test("CreateDepartment: Status code should be 201.", () =>
{
    Equal(201, tp.Responses["CreateDepartment"].StatusCode());
});

tp.Test("GetAllDepartments: Status code should be 200.", () =>
{
    Equal(200, tp.Responses["GetAllDepartments"].StatusCode());
});

tp.Test("GetAllDepartments: Response should include the created department (by name+code).", () =>
{
    var jsonArray = tp.Responses["GetAllDepartments"].GetBody<System.Text.Json.JsonElement>();

    bool found = false;

    foreach (var department in jsonArray.EnumerateArray())
    {
        var name = department.GetProperty("name").GetString();
        var code = department.GetProperty("code").GetString();

        if (name == "Department Name" && code == "DeptCode")
        {
            found = true;
            break;
        }
    }

    True(found);
});

tp.Test("UpdateDepartment: Status code should be 200 or 204.", () =>
{
    var status = tp.Responses["UpdateDepartment"].StatusCode();
    True(status == 200 || status == 204);
});

tp.Test("GetUpdatedDepartment: Status code should be 200.", () =>
{
    Equal(200, tp.Responses["GetUpdatedDepartment"].StatusCode());
});

tp.Test("GetUpdatedDepartment: Response name and code should be updated.", () =>
{
    var json = tp.Responses["GetUpdatedDepartment"].GetBody<System.Text.Json.JsonElement>();

    var name = json.GetProperty("name").GetString();
    var code = json.GetProperty("code").GetString();

    Equal("Department Name 2.0v", name);
    Equal("DeptCode 2.0v", code);
});

tp.Test("DeleteDepartment: After deletion, department should not be found (404).", () =>
{
    Equal(404, tp.Responses["GetDeletedDepartment"].StatusCode());
});