using CCCA16_NET.Domain.Vo;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCCA16_NET.Domain.Entity
{
    public class Ride
    {
        [Column("ride_id")]
        public Guid RideId { get; }
        [Column("passenger_id")]
        public Guid PassengerId { get; }
        [Column("driver_id")]
        public Guid DriverId { get; }
        [Column("from_lat")]
        public decimal FromLat { get; }
        [Column("from_long")]
        public decimal FromLong { get; }
        [Column("to_lat")]
        public decimal ToLat { get; }
        [Column("to_long")]
        public decimal ToLong { get; }
        [Column("status")]
        public RideStatus Status { get; set; }
        public DateTime? Date { get; }

        private Ride(Guid rideId, Guid passengerId, Guid driverId, decimal fromLat, decimal fromLong, decimal toLat, decimal toLong, string status, DateTime date)
        {
            this.RideId = rideId;
            this.PassengerId = passengerId;
            this.DriverId = driverId;
            this.FromLat = fromLat;
            this.FromLong = fromLong;
            this.ToLat = toLat;
            this.ToLong = toLong;
            this.Status = RideStatusFactory.Create(this, status);
            this.Date = date;
        }
        public static Ride Create(Guid passengerId, Guid driverId, decimal fromLat, decimal fromLong, decimal toLat, decimal toLong)
        {
            var rideId = Guid.NewGuid();
            var status = "requested";
            var date = DateTime.Now;
            return new Ride(rideId, passengerId, driverId, fromLat, fromLong, toLat, toLong, status, date);
        }

        public static Ride Restore(Guid rideId, Guid passengerId, Guid driverId, decimal fromLat, decimal fromLong, decimal toLat, decimal toLong, string status, DateTime date)
        {
            return new Ride(rideId, passengerId, driverId, fromLat, fromLong, toLat, toLong, status, date);
        }
    }
}
