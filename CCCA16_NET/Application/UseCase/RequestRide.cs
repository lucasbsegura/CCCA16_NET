using CCCA16_NET.Domain.Entity;
using CCCA16_NET.Infra.Repository;

namespace CCCA16_NET.Application.UseCase
{
    public class RequestRide(IAccountRepository accountRepository, IRideRepository rideRepository)
    {
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly IRideRepository _rideRepository = rideRepository;

        public async Task<Guid> Execute(RideRequestInput input)
        {
            var account = await this._accountRepository.GetAccountById(input.PassengerId);
            if (!account.IsPassenger) throw new Exception("Account is not from a passenger");
            var hasActiveRide = await this._rideRepository.HasActiveRideByPassengerId(input.PassengerId);
            if (hasActiveRide) throw new Exception("Passenger has an active ride");
            var ride = Ride.Create(input.PassengerId, input.FromLat, input.FromLong, input.ToLat, input.ToLong);
            this._rideRepository.SaveRide(ride);
            return ride.RideId;
        }
    }

    public record RideRequestInput(Guid PassengerId, decimal FromLat, decimal FromLong, decimal ToLat, decimal ToLong)
    {
        public Guid PassengerId { get; } = PassengerId;
        public decimal FromLat { get; } = FromLat;
        public decimal FromLong { get; } = FromLong;
        public decimal ToLat { get; } = ToLat;
        public decimal ToLong { get; } = ToLong;
    }
}
