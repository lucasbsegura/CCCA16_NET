using CCCA16_NET.Infra.Repository;

namespace CCCA16_NET.Application.UseCase
{
    public class GetRide
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRideRepository _rideRepository;

        public GetRide(IAccountRepository accountRepository, IRideRepository rideRepository)
        {
            _accountRepository = accountRepository;
            _rideRepository = rideRepository;
        }

        public async Task<GetRideOutput> Execute(Guid rideId)
        {
            var ride = await this._rideRepository.GetRideById(rideId);
            var passanger = await this._accountRepository.GetAccountById(ride.PassengerId);
            if (ride.DriverId == null || ride.DriverId == Guid.Empty)
            {
                return new GetRideOutput(ride.RideId, ride.PassengerId, ride.FromLat, ride.FromLat, ride.ToLat, ride.ToLong, passanger.Name.GetValue(), passanger.Email.GetValue(), "", "");
            }
            var driver = await this._accountRepository.GetAccountById(ride.DriverId);
            return new GetRideOutput(ride.RideId, ride.PassengerId, ride.FromLat, ride.FromLat, ride.ToLat, ride.ToLong, passanger.Name.GetValue(), passanger.Email.GetValue(), driver.Name.GetValue(), driver.Email.GetValue());
        }
    }

    public record GetRideOutput(Guid RideId, Guid PassangerId, decimal FromLat, decimal FromLong, decimal ToLat, decimal ToLong, string PassangerName, string PassangerEmail, string DriverName, string DriverEmail)
    {
        public Guid RideId { get; } = RideId;
        public Guid PassengerId { get; } = PassangerId;
        public decimal FromLat { get; } = FromLat;
        public decimal FromLong { get; } = FromLong;
        public decimal ToLat { get; } = ToLat;
        public decimal ToLong { get; } = ToLong;
        public string PassangerName { get; } = PassangerName;
        public string PassangerEmail { get; } = PassangerEmail;
        public string DriverName { get; } = DriverName;
        public string DriverEmail { get; } = DriverEmail;
    }
}


