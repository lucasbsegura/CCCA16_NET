using System.ComponentModel.DataAnnotations.Schema;

namespace CCCA16_NET.Domain.Vo
{
    public class Coord
    {
        [Column("lat")]
        private decimal Latitude { get; set; }
        [Column("long")]
        private decimal Longitude { get; set; }

        public Coord(decimal latitude, decimal longitude) 
        {
            if (latitude < -90 || latitude > 90) throw new Exception("Invalid latitude");
            if (longitude < -180 || longitude > 180) throw new Exception("Invalid longitude");
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public decimal GetLatitude() { return this.Latitude; }
        public decimal GetLongitude() { return this.Longitude; }
    }
}
