using System.ComponentModel.DataAnnotations.Schema;

namespace CCCA16_NET.Domain.Vo
{
    public class Coord
    {
        [Column("lat")]
        private long Latitude { get; set; }
        [Column("long")]
        private long Longitude { get; set; }

        public Coord(long latitude, long longitude) 
        {
            if (latitude < -90 || latitude > 90) throw new Exception("Invalid latitude");
            if (longitude < -180 || longitude > 180) throw new Exception("Invalid longitude");
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public long GetLatitude() { return this.Latitude; }
        public long GetLongitude() { return this.Longitude; }
    }
}
