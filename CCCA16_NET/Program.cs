using CCCA16_NET;
using CCCA16_NET.Infra.Http;

var builder = WebApplication.CreateBuilder(args);
DiRegistrator.RegisterServices(builder.Services);
var app = builder.Build();

AccountEndpoint.Create(app);
PingEndpoint.Create(app);
SignUpEndpoint.Create(app);

app.Run();