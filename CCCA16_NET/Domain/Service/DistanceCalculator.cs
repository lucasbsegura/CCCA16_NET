using CCCA16_NET.Domain.Entity;
using CCCA16_NET.Domain.Vo;

namespace CCCA16_NET.Domain.Service
{
    public class DistanceCalculator
    {
        public static double Calculate(Position[] positions)
        {
            double distance = 0;
            for (var i = 0; i < positions.Count(); i++)
            {
                if (i + 1 == positions.Count()) break;
                var nextPosition = positions[i + 1];
                var segment = new Segment(positions[i].Coord, nextPosition.Coord);
                distance += segment.GetDistance();
            }
            return distance;
        }
    }
}
