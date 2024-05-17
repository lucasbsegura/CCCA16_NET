﻿using CCCA16_NET.Application.UseCase;
using CCCA16_NET.Infra.Repository;
using System.Net.NetworkInformation;

namespace CCCA16_NET.Infra.Http
{
    public static class RideEndpoint
    {
        public static void Create(WebApplication app)
        {
            app.MapGet("/Ride/{rideId}", Get);
            app.MapPost("/Ride/Request", Request);
            app.MapPost("/Ride/Accept", Accept);
        }

        private static async Task<GetRideOutput> Get(Guid rideId, IAccountRepository accountRepository, IRideRepository rideRepository)
        {
            var getRide = new GetRide(accountRepository, rideRepository);
            return await getRide.Execute(rideId);
        }

        private static async Task<Guid> Request(RideRequestInput input, IAccountRepository accountRepository, IRideRepository rideRepository)
        {
            var requestRide = new RequestRide(accountRepository, rideRepository);
            return await requestRide.Execute(input);
        }

        private static async Task<Guid> Accept(AcceptRideInput input, IAccountRepository accountRepository, IRideRepository rideRepository)
        {
            var acceptRide = new AcceptRide(accountRepository, rideRepository);
            return await acceptRide.Execute(input);
        }
    }
}