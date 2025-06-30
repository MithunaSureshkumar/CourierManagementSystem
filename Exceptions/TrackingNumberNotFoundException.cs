namespace CourierManagementSystem.Exceptions
{
        public class TrackingNumberNotFoundException : Exception
        {
            public TrackingNumberNotFoundException() : base("Tracking number not found.") { } //default exception

        public TrackingNumberNotFoundException(string message) : base(message) { } //creating custom exception
    } 
    }

