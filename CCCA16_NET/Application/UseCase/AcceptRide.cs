using CCCA16_NET.Infra.Repository;

namespace CCCA16_NET.Application.UseCase
{
    public class AcceptRide(IAccountRepository accountRepository, IRideRepository rideRepository)
    {
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly IRideRepository _rideRepository = rideRepository;

        public async Task<Guid> Execute(AcceptRideInput input)
        {
            var account = await this._accountRepository.GetAccountById(input.DriverId);
            if (!account.IsDriver) throw new Exception("Account is not from a driver");
            var ride = await this._rideRepository.GetRideById(input.RideId);
            if (ride == null) throw new Exception("there is no ride");
            ride.Accept(input.DriverId);
            this._rideRepository.UpdateRide(ride);
            return ride.RideId;
        }
    }

    public record AcceptRideInput(Guid RideId, Guid DriverId)
    {
        public Guid RideId { get; } = RideId;
        public Guid DriverId { get; } = DriverId;
    }
}
