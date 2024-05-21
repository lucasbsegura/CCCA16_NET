namespace CCCA16_NET.Domain.Vo
{
    public class Segment(Coord from, Coord to)
    {
        public Coord From { get; } = from;
        public Coord To { get; } = to;

        public double GetDistance()
        {
            var earthRadius = 6371;
            var degreesToRadians = Math.PI / 180;
            var deltaLat = (double)(this.To.GetLatitude() - this.From.GetLatitude()) * degreesToRadians;
            var deltaLon = (double)(this.To.GetLongitude() - this.From.GetLongitude()) * degreesToRadians;
            var a =
                Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                Math.Cos((double)this.From.GetLatitude() * degreesToRadians) *
                Math.Cos((double)this.To.GetLatitude() * degreesToRadians) *
                Math.Sin(deltaLon / 2) *
                Math.Sin(deltaLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var distance = earthRadius * c;
            return Math.Round(distance);
        }
    }
}
