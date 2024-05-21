using CCCA16_NET.Domain.Vo;
using System.ComponentModel.DataAnnotations.Schema;

namespace CCCA16_NET.Domain.Entity
{
    public class Ride
    {
        public Guid RideId { get; }
        public Guid PassengerId { get; }
        public Guid DriverId { get; set;  }
        public Segment Segment { get; set; }
        public RideStatus Status { get; set; }
        public DateTime? Date { get; }

        private Ride(Guid rideId, Guid passengerId, Guid driverId, Segment segment, string status, DateTime date)
        {
            this.RideId = rideId;
            this.PassengerId = passengerId;
            this.DriverId = driverId;
            this.Segment = segment;
            this.Status = RideStatusFactory.Create(this, status);
            this.Date = date;
        }
        public static Ride Create(Guid passengerId, decimal fromLat, decimal fromLong, decimal toLat, decimal toLong)
        {
            var rideId = Guid.NewGuid();
            var status = "requested";
            var date = DateTime.Now;
            var ride = new Ride(rideId, passengerId, Guid.Empty, new Segment(new Coord(fromLat, fromLong), new Coord(toLat, toLong)), status, date);
            return ride;
        }

        public static Ride Restore(Guid rideId, Guid passengerId, Guid driverId, decimal fromLat, decimal fromLong, decimal toLat, decimal toLong, string status, DateTime date)
        {
            return new Ride(rideId, passengerId, driverId, new Segment(new Coord(fromLat, fromLong), new Coord(toLat, toLong)), status, date);
        }

        public void Accept(Guid driverId)
        {
            this.Status.Accept();
            this.DriverId = driverId;
        }

        public void Start()
        {
            this.Status.Start();
        }

        public string GetStatus()
        {
            return this.Status.Value;
        }

        public decimal GetFromLat()
        {
            return this.Segment.From.GetLatitude();
        }

        public decimal GetFromLong()
        {
            return this.Segment.From.GetLongitude();
        }

        public decimal GetToLat()
        {
            return this.Segment.To.GetLatitude();
        }

        public decimal GetToLong()
        {
            return this.Segment.To.GetLongitude();
        }
    }
}
