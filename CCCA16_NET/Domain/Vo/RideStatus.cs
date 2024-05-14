using CCCA16_NET.Domain.Entity;

namespace CCCA16_NET.Domain.Vo
{
    public abstract class RideStatus(Ride ride)
    {
        public abstract string Value { get; set; }
        protected readonly Ride _ride = ride;

        protected abstract void Request();
        protected abstract void Accept();
        protected abstract void Start();
    }

    public class RequestedStatus(Ride ride) : RideStatus(ride)
    {
        private new readonly Ride _ride = ride;

        public override string Value { get; set; } = "requested";

        protected override void Accept()
        {
            throw new Exception("Invalid status");
        }

        protected override void Request()
        {
            this._ride.Status = new AcceptedStatus(this._ride);
        }

        protected override void Start()
        {
            throw new Exception("Invalid status");
        }
    }

    public class AcceptedStatus(Ride ride) : RideStatus(ride)
    {
        private new readonly Ride _ride = ride;

        public override string Value { get; set; } = "accepted";

        protected override void Accept()
        {
            throw new Exception("Invalid status");
        }

        protected override void Request()
        {
            throw new Exception("Invalid status");
        }

        protected override void Start()
        {
            this._ride.Status = new InProgressStatus(this._ride);
        }
    }

    public class InProgressStatus(Ride ride) : RideStatus(ride)
    {
        private new readonly Ride _ride = ride;

        public override string Value { get; set; } = "in_progress";

        protected override void Accept()
        {
            throw new Exception("Invalid status");
        }

        protected override void Request()
        {
            throw new Exception("Invalid status");
        }

        protected override void Start()
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
