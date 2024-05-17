using CCCA16_NET.Domain.Entity;
using CCCA16_NET.Domain.Vo;
using CCCA16_NET.Infra.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace CCCA16_NET.Infra.Repository
{
    public interface IRideRepository
    {
        void SaveRide(Ride ride);
        Task<bool> HasActiveRideByPassengerId(Guid passenderId);
        Task<Ride> GetRideById(Guid id);
        void UpdateRide(Ride ride);
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
            return await _connection.GetAsync<Ride>("select ride_id AS RideId, passenger_id AS PassengerId, driver_id AS DriverId, from_lat AS FromLat, from_long AS FromLong, to_lat AS ToLat, to_long AS ToLong, status, date from cccat16.ride where ride_id = @id", new { id });
        }

        public async Task<bool> HasActiveRideByPassengerId(Guid passengerId)
        {
            var ride = await _connection.GetAsync<Ride>("select ride_id AS RideId, passenger_id AS PassengerId, driver_id AS DriverId, from_lat AS FromLat, from_long AS FromLong, to_lat AS ToLat, to_long AS ToLong, status, date from cccat16.ride where passenger_id = @passengerId and status <> 'completed'", new { passengerId });
            return ride != null;
        }

        public async void SaveRide(Ride ride)
        {
            var rideDb = new RideDb(ride.RideId, ride.PassengerId, ride.DriverId, ride.FromLat, ride.FromLong, ride.ToLat, ride.ToLong, ride.Status.Value, ride.Date);
            var result = await _connection.EditData(
            "INSERT INTO cccat16.ride (ride_id, passenger_id, from_lat, from_long, to_lat, to_long, status, date) " +
            "VALUES (@RideId, @PassengerId, @FromLat, @FromLong, @ToLat, @ToLong, @Status, @Date)",
            rideDb);
        }

        public async void UpdateRide(Ride ride)
        {
            var rideDb = new RideDb(ride.RideId, ride.PassengerId, ride.DriverId, ride.FromLat, ride.FromLong, ride.ToLat, ride.ToLong, ride.Status.Value, ride.Date);
            var result = await _connection.EditData(
            "UPDATE cccat16.ride SET status = @Status, driver_id = @DriverId where ride_id = @RideId",
            rideDb);
        }
    }

    public record RideDb(Guid RideId, Guid PassengerId, Guid DriverId, decimal FromLat, decimal FromLong, decimal ToLat, decimal ToLong, string Status, DateTime? Date)
    {
        [Column("ride_id")]
        public Guid RideId { get; } = RideId;
        [Column("passenger_id")]
        public Guid PassengerId { get; } = PassengerId;
        [Column("driver_id")]
        public Guid DriverId { get; } = DriverId;
        [Column("from_lat")]
        public decimal FromLat { get; } = FromLat;
        [Column("from_long")]
        public decimal FromLong { get; } = FromLong;
        [Column("to_lat")]
        public decimal ToLat { get; } = ToLat;
        [Column("to_long")]
        public decimal ToLong { get; } = ToLong;
        [Column("status")]
        public string Status { get; set; } = Status;
        public DateTime? Date { get; } = Date;
    }
}
