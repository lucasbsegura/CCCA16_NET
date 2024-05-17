using CCCA16_NET.Infra.Repository;

namespace CCCA16_NET.Application.UseCase
{
    public class StartRide(IRideRepository rideRepository)
    {
        private readonly IRideRepository _rideRepository = rideRepository;

        public async Task<Guid> Execute(StartRideInput input)
        {
            var ride = await this._rideRepository.GetRideById(input.RideId);
            if (ride == null) throw new Exception("there is no ride");
            ride.Start();
            this._rideRepository.UpdateRide(ride);
            return ride.RideId;
        }
    }

    public record StartRideInput(Guid RideId)
    {
        public Guid RideId { get; } = RideId;
    }
}
