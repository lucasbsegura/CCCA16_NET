namespace CCCA16_NET.Domain.Entity
{
    public class Ride
    {
        public Guid RideId { get; }
        public string PassengerId { get; }
        public double FromLat { get; }
        public double FromLong { get; }
        public double ToLat { get; }
        public double ToLong { get; }
        public string Status { get; }
        public DateTime? Date { get; }

        private Ride(Guid rideId, string passengerId, double fromLat, double fromLong, double toLat, double toLong, string status, DateTime date)
        {
            this.RideId = rideId;
            this.PassengerId = passengerId;
            this.FromLat = fromLat;
            this.FromLong = fromLong;
            this.ToLat = toLat;
            this.ToLong = toLong;
            this.Status = status;
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
