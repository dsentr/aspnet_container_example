var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
var app = builder.Build();

app.MapHealthChecks("health");
app.MapGet("/", () =>
{
    var config = app.Services.GetService<IConfiguration>();
    var secretValue = config["danstestsecret1"];
    if (secretValue != null)
    {
        return Results.Ok($"danstestsecret1 variable value is {secretValue}");
    }
    else
    {
        return Results.Ok("enviornment variable notfound");
    }
});

app.Run();

