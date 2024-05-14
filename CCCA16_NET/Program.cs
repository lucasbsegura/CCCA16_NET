using CCCA16_NET;
using CCCA16_NET.Infra.Http;

var builder = WebApplication.CreateBuilder(args);
DiRegistrator.RegisterServices(builder.Services);
var app = builder.Build();
app.MapGet("/ping", () => "pong!");
AccountEndpoint.Create(app);

app.Run();