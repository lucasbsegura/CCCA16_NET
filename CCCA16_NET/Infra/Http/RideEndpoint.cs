using CCCA16_NET.Application.UseCase;
using CCCA16_NET.Infra.Repository;

namespace CCCA16_NET.Infra.Http
{
    public static class RideEndpoint
    {
        public static void Create(WebApplication app)
        {
            app.MapGet("/Ride/{rideId}", Get);
        }

        private static async Task<GetRideOutput> Get(Guid rideId, IAccountRepository accountRepository, IRideRepository rideRepository)
        {
            var getRide = new GetRide(accountRepository, rideRepository);
            return await getRide.Execute(rideId);
        }
    }
}
