using CCCA16_NET.Domain.Entity;
using CCCA16_NET.Infra.Database;
using System.Data.Common;

namespace CCCA16_NET.Infra.Repository
{
    public interface IRideRepository
    {
        void SaveRide(Ride ride);
        Task<bool> HasActiveRideByPassengerId(string email);
        Task<Ride> GetRideById(Guid id);
        
    }


    public class RideRepository : IRideRepository
    {
        private readonly IDbService _connection;
        public RideRepository(IDbService connection)
        {
            _connection = connection;
        }

        public async Task<Ride> GetRideById(Guid id)
        {
            var ride = await _connection.GetAsync<Ride>("select * from cccat16.ride where ride_id = @rideId", new { id });
            return ride;
        }

        public async Task<bool> HasActiveRideByPassengerId(string passengerId)
        {
            var ride = await _connection.GetAsync<Ride>("select * from cccat16.ride where passenger_id = @passengerId and status <> 'completed'", new { passengerId });
            return ride != null;
        }

        public async void SaveRide(Ride ride)
        {
            var result = await _connection.EditData(
            "INSERT INTO cccat16.ride (ride_id, passenger_id, from_lat, from_long, to_lat, to_long, status, date) " +
            "VALUES (@RideId, @PassengerId, @FromLat, @FromLong, @ToLat, @ToLong, @Status, @Date)",
            ride);
        }
    }
}
