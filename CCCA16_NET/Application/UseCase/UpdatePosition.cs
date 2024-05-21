using CCCA16_NET.Domain.Entity;
using CCCA16_NET.Infra.Repository;

namespace CCCA16_NET.Application.UseCase
{
    public class UpdatePosition(IRideRepository rideRepository, IPositionRepository positionRepository)
    {
        private readonly IRideRepository _rideRepository = rideRepository;
        private readonly IPositionRepository _positionRepository = positionRepository;

        public async void Execute(UpdatePositionInput input)
        {
            var position = Position.Create(input.RideId, input.Latitude, input.Longitude);
            this._positionRepository.SavePosition(position);
        }
    }

    public record UpdatePositionInput(Guid RideId, decimal Latitude, decimal Longitude) 
    {
        public Guid RideId { get; } = RideId;
        public decimal Latitude { get; } = Latitude;
        public decimal Longitude { get; } = Longitude;
    }
}
