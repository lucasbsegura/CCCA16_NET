using CCCA16_NET;

var builder = WebApplication.CreateBuilder(args);
DiRegistrator.RegisterServices(builder.Services);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/ping", () => "pong!");

app.Run();
