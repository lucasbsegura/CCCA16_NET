using CCCA16_NET.Domain.Entity;

namespace CCCA16_NET.Test.Domain
{
    public class RideTest
    {
        [Fact]
        public void DeveConstruirRide()
        {
            var passengerId = Guid.NewGuid();
            double fromLat = -27.584905257808835;
            double fromLong = -48.545022195325124;
            double toLat = -27.496887588317275;
            double toLong = -48.522234807851476;
            var createRide = Ride.Create(passengerId, (decimal)fromLat, (decimal)fromLong, (decimal)toLat, (decimal)toLong);
            Assert.True(createRide.PassengerId == passengerId);
            Assert.True(createRide.Segment.From.GetLatitude() == (decimal)fromLat);
            Assert.True(createRide.Segment.From.GetLongitude() == (decimal)fromLong);
            Assert.True(createRide.Segment.To.GetLatitude() == (decimal)toLat);
            Assert.True(createRide.Segment.To.GetLongitude() == (decimal)toLong);
            Assert.True(createRide.Status.Value == "requested");
            Assert.True(createRide.Date != null);
            Assert.True(createRide.RideId != Guid.Empty);
        }

        [Fact]
        public void DeveRestaurarRide()
        {
            var rideId = Guid.NewGuid();
            string status = "requested";
            DateTime date = DateTime.Now;
            var passengerId = Guid.NewGuid();
            var driverId = Guid.NewGuid();
            double fromLat = -27.584905257808835;
            double fromLong = -48.545022195325124;
            double toLat = -27.496887588317275;
            double toLong = -48.522234807851476;
            var createRide = Ride.Restore(rideId, passengerId, driverId, (decimal)fromLat, (decimal)fromLong, (decimal)toLat, (decimal)toLong, status, date);
            Assert.True(createRide.RideId == rideId);
            Assert.True(createRide.PassengerId == passengerId);
            Assert.True(createRide.Segment.From.GetLatitude() == (decimal)fromLat);
            Assert.True(createRide.Segment.From.GetLongitude() == (decimal)fromLong);
            Assert.True(createRide.Segment.To.GetLatitude() == (decimal)toLat);
            Assert.True(createRide.Segment.To.GetLongitude() == (decimal)toLong);
            Assert.True(createRide.Status.Value == status);
            Assert.True(createRide.Date == date);
        }
    }
}
