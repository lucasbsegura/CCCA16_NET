using CCCA16_NET.Domain.Entity;

namespace CCCA16_NET.Test.Domain
{
    public class RideTest
    {
        [Fact]
        public void DeveConstruirRide()
        {
            string passengerId = "1";
            double fromLat = -27.584905257808835;
            double fromLong = -48.545022195325124;
            double toLat = -27.496887588317275;
            double toLong = -48.522234807851476;
            var createRide = Ride.Create(passengerId, fromLat, fromLong, toLat, toLong);
            Assert.True(createRide.PassengerId == passengerId);
            Assert.True(createRide.FromLat == fromLat);
            Assert.True(createRide.FromLong == fromLong);
            Assert.True(createRide.ToLat == toLat);
            Assert.True(createRide.ToLong == toLong);
            Assert.True(createRide.Status == "requested");
            Assert.True(createRide.Date != null);
            Assert.True(createRide.RideId != Guid.Empty);
        }

        [Fact]
        public void DeveRestaurarRide()
        {
            Guid rideId = Guid.NewGuid();
            string status = "requested";
            DateTime date = DateTime.Now;
            string passengerId = "1";
            double fromLat = -27.584905257808835;
            double fromLong = -48.545022195325124;
            double toLat = -27.496887588317275;
            double toLong = -48.522234807851476;
            var createRide = Ride.Restore(rideId, passengerId, fromLat, fromLong, toLat, toLong, status, date);
            Assert.True(createRide.RideId == rideId);
            Assert.True(createRide.PassengerId == passengerId);
            Assert.True(createRide.FromLat == fromLat);
            Assert.True(createRide.FromLong == fromLong);
            Assert.True(createRide.ToLat == toLat);
            Assert.True(createRide.ToLong == toLong);
            Assert.True(createRide.Status == status);
            Assert.True(createRide.Date == date);
        }
    }
}
