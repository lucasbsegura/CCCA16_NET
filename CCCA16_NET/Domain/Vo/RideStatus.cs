using CCCA16_NET.Domain.Entity;

namespace CCCA16_NET.Domain.Vo
{
    public abstract class RideStatus(Ride ride)
    {
        public abstract string Value { get; set; }
        protected readonly Ride _ride = ride;

        public abstract void Request();
        public abstract void Accept();
        public abstract void Start();
    }

    public class RequestedStatus(Ride ride) : RideStatus(ride)
    {
        private new readonly Ride _ride = ride;

        public override string Value { get; set; } = "requested";

        public override void Accept()
        {
            this._ride.Status = new AcceptedStatus(this._ride);
        }

        public override void Request()
        {
            throw new Exception("Invalid status");
        }

        public override void Start()
        {
            throw new Exception("Invalid status");
        }
    }

    public class AcceptedStatus(Ride ride) : RideStatus(ride)
    {
        private new readonly Ride _ride = ride;

        public override string Value { get; set; } = "accepted";

        public override void Accept()
        {
            throw new Exception("Invalid status");
        }

        public override void Request()
        {
            throw new Exception("Invalid status");
        }

        public override void Start()
        {
            this._ride.Status = new InProgressStatus(this._ride);
        }
    }

    public class InProgressStatus(Ride ride) : RideStatus(ride)
    {
        private new readonly Ride _ride = ride;

        public override string Value { get; set; } = "in_progress";

        public override void Accept()
        {
            throw new Exception("Invalid status");
        }

        public override void Request()
        {
            throw new Exception("Invalid status");
        }

        public override void Start()
        {
            throw new Exception("Invalid status");
        }
    }

    public class RideStatusFactory
    {
        public static RideStatus Create(Ride ride, string status)
        {
            if (status == "requested") return new RequestedStatus(ride);
            if (status == "accepted") return new AcceptedStatus(ride);
            if (status == "in_progress") return new InProgressStatus(ride);
            throw new Exception();
        }
    }
}
