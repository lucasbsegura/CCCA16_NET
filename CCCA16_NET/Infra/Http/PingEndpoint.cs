namespace CCCA16_NET.Infra.Http
{
    public static class PingEndpoint
    {
        public static void Create(WebApplication app)
        {
            app.MapGet("/ping", () => "pong!");
        }
    }
}
