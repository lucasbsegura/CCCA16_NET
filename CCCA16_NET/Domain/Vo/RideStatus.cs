using CCCA16_NET.Domain.Entity;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace CCCA16_NET.Domain.Vo
{
    public abstract class RideStatus
    {
        public abstract string Value { get; set; }
        protected readonly Ride _ride;
        protected RideStatus(Ride ride) { }
        protected abstract void request();
        protected abstract void accept();
        protected abstract void start();
    }

    public class RequestedStatus(Ride ride) : RideStatus(ride)
    {
        private new readonly Ride _ride = ride;

        public override string Value { get; set; } = "requested";

        protected override void accept()
        {
            throw new Exception("Invalid status");
        }

        protected override void request()
        {
            this._ride.Status = new AcceptedStatus(this._ride);
        }

        protected override void start()
        {
            throw new Exception("Invalid status");
        }
    }

    public class AcceptedStatus(Ride ride) : RideStatus(ride)
    {
        private new readonly Ride _ride = ride;

        public override string Value { get; set; } = "accepted";

        protected override void accept()
        {
            throw new Exception("Invalid status");
        }

        protected override void request()
        {
            throw new Exception("Invalid status");
        }

        protected override void start()
        {
            this._ride.Status = new InProgressStatus(this._ride);
        }
    }

    public class InProgressStatus(Ride ride) : RideStatus(ride)
    {
        private new readonly Ride _ride = ride;

        public override string Value { get; set; } = "in_progress";

        protected override void accept()
        {
            throw new Exception("Invalid status");
        }

        protected override void request()
        {
            throw new Exception("Invalid status");
        }

        protected override void start()
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
