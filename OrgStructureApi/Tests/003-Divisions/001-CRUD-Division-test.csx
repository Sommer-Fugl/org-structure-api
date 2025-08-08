tp.Test("CreateDivision: Status code should be 201.", () =>
{
    Equal(201, tp.Responses["CreateDivision"].StatusCode());
});

tp.Test("GetAllDivisions: Status code should be 200.", () =>
{
    Equal(200, tp.Responses["GetAllDivisions"].StatusCode());
});

tp.Test("GetAllDivisions: Response should include the created division (by name+code).", () =>
{
    var jsonArray = tp.Responses["GetAllDivisions"].GetBody<System.Text.Json.JsonElement>();

    bool found = false;

    foreach (var division in jsonArray.EnumerateArray())
    {
        var name = division.GetProperty("name").GetString();
        var code = division.GetProperty("code").GetString();

        if (name == "Technology Division" && code == "TECH001")
        {
            found = true;
            break;
        }
    }

    True(found);
});

tp.Test("UpdateDivision: Status code should be 200 or 204.", () =>
{
    var status = tp.Responses["UpdateDivision"].StatusCode();
    True(status == 200 || status == 204);
});

tp.Test("GetUpdatedDivision: Status code should be 200.", () =>
{
    Equal(200, tp.Responses["GetUpdatedDivision"].StatusCode());
});

tp.Test("GetUpdatedDivision: Response name and code should be updated.", () =>
{
    var json = tp.Responses["GetUpdatedDivision"].GetBody<System.Text.Json.JsonElement>();

    var name = json.GetProperty("name").GetString();
    var code = json.GetProperty("code").GetString();

    Equal("Software Development 0.2v", name);
    Equal("DEPT001 0.2v", code);
});

tp.Test("DeleteDivision: After deletion, division should not be found (404).", () =>
{
    var status = tp.Responses["GetDeletedDivision"].StatusCode();
    True(status == 404 || status == 204);
});
