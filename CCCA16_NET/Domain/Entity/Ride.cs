using CCCA16_NET.Domain.Vo;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCCA16_NET.Domain.Entity
{
    public class Ride
    {
        [Column("ride_id")]
        public Guid RideId { get; }
        [Column("passenger_id")]
        public string PassengerId { get; }
        [Column("from_lat")]
        public double FromLat { get; }
        [Column("from_long")]
        public double FromLong { get; }
        [Column("to_lat")]
        public double ToLat { get; }
        [Column("to_long")]
        public double ToLong { get; }
        [Column("status")]
        public RideStatus Status { get; set; }
        public DateTime? Date { get; }

        private Ride(Guid rideId, string passengerId, double fromLat, double fromLong, double toLat, double toLong, string status, DateTime date)
        {
            this.RideId = rideId;
            this.PassengerId = passengerId;
            this.FromLat = fromLat;
            this.FromLong = fromLong;
            this.ToLat = toLat;
            this.ToLong = toLong;
            this.Status = RideStatusFactory.Create(this, status);
            this.Date = date;
        }
        public static Ride Create(string passengerId, double fromLat, double fromLong, double toLat, double toLong)
        {
            var rideId = Guid.NewGuid();
            var status = "requested";
            var date = DateTime.Now;
            return new Ride(rideId, passengerId, fromLat, fromLong, toLat, toLong, status, date);
        }

        public static Ride Restore(Guid rideId, string passengerId, double fromLat, double fromLong, double toLat, double toLong, string status, DateTime date)
        {
            return new Ride(rideId, passengerId, fromLat, fromLong, toLat, toLong, status, date);
        }
    }
}
