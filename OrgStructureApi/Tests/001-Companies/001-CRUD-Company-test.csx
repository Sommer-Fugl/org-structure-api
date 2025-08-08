tp.Test("CreateCompany: Status code should be 201.", () =>
{
    var createResponse = tp.Responses["CreateCompany"];
    Equal(201, createResponse.StatusCode());
});

tp.Test("GetAllCompanies: Status code should be 200.", () =>
{
    var getAllResponse = tp.Responses["GetAllCompanies"];
    Equal(200, getAllResponse.StatusCode());
});

tp.Test("GetAllCompanies: Response should include the created company.", () =>
{
    var jsonArray = tp.Responses["GetAllCompanies"].GetBody<System.Text.Json.JsonElement>();

    bool found = false;

    foreach (var company in jsonArray.EnumerateArray())
    {
        var name = company.GetProperty("name").GetString();
        var code = company.GetProperty("code").GetString();

        if (name == "Acme Corporation" && code == "ACME001")
        {
            found = true;
            break;
        }
    }

    True(found);
});

tp.Test("UpdateCompany: Status code should be 204.", () =>
{
    var statusCode = tp.Responses["UpdateCompany"].StatusCode();
    Equal(204, statusCode);
});

tp.Test("GetUpdatedCompany: Status code should be 200.", () =>
{
    Equal(200, tp.Responses["GetUpdatedCompany"].StatusCode());
});

tp.Test("GetUpdatedCompany: Response name should be updated.", () =>
{
    var json = tp.Responses["GetUpdatedCompany"].GetBody<System.Text.Json.JsonElement>();
    var name = json.GetProperty("name").GetString();
    Equal("Acmere Corporation", name);
});

tp.Test("GetUpdatedCompany: Response code should be updated.", () =>
{
    var json = tp.Responses["GetUpdatedCompany"].GetBody<System.Text.Json.JsonElement>();
    var code = json.GetProperty("code").GetString();
    Equal("ACME00112", code);
});

tp.Test("DeleteCompany: After deletion, company should not be found.", () =>
{
    var response = tp.Responses["GetDeletedCompany"];
    var statusCode = response.StatusCode;

    True(statusCode == System.Net.HttpStatusCode.NotFound);
});
