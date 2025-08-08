tp.Test("CreateEmployee: Status code should be 201.", () =>
{
    var createResponse = tp.Responses["CreateEmployee"];
    Equal(201, createResponse.StatusCode());
});

tp.Test("GetAllEmployees: Status code should be 200.", () =>
{
    var getAllResponse = tp.Responses["GetAllEpmloyees"];
    Equal(200, getAllResponse.StatusCode());
});

tp.Test("GetAllEmployees: Response should include the created employee.", () =>
{
    var jsonArray = tp.Responses["GetAllEpmloyees"].GetBody<System.Text.Json.JsonElement>();

    bool found = false;
    foreach (var employee in jsonArray.EnumerateArray())
    {
        var firstName = employee.GetProperty("firstName").GetString();
        var lastName = employee.GetProperty("lastName").GetString();

        if (firstName == "John" && lastName == "Doe")
        {
            found = true;
            break;
        }
    }

    True(found);
});

tp.Test("UpdateEmployee: Status code should be 204.", () =>
{
    var statusCode = tp.Responses["UpdateEmployee"].StatusCode();
    Equal(204, statusCode);
});

tp.Test("GetUpdatedEmployee: Status code should be 200.", () =>
{
    Equal(200, tp.Responses["GetUpdateEmployee"].StatusCode());
});

tp.Test("GetUpdatedEmployee: Title should be updated.", () =>
{
    var json = tp.Responses["GetUpdateEmployee"].GetBody<System.Text.Json.JsonElement>();
    var title = json.GetProperty("title").GetString();
    Equal("Senior Developer", title);
});

tp.Test("GetUpdatedEmployee: Phone should be updated.", () =>
{
    var json = tp.Responses["GetUpdateEmployee"].GetBody<System.Text.Json.JsonElement>();
    var phone = json.GetProperty("phone").GetString();
    Equal("+421987654321", phone);
});

tp.Test("DeleteEmployee: After deletion, employee should not be found.", () =>
{
    var response = tp.Responses["GetDeletedEmployee"];
    var statusCode = response.StatusCode;
    True(statusCode == System.Net.HttpStatusCode.NotFound);
});