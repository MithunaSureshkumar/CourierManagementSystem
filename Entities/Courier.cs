namespace CourierManagementSystem.Entities
{
    public class Courier
    {
         int courierID;
         string senderName;
         string senderAddress;
         string receiverName;
         string receiverAddress;
         double weight;
         string status;
         string trackingNumber;
         DateTime deliveryDate;
        int userID;

        public Courier() { }    // default constructor


        // creating parameterized constructor
        public Courier(int courierID, string senderName, string senderAddress, string receiverName, string receiverAddress, double weight, string status, string trackingNumber, DateTime deliveryDate, int userID)
        {
            this.courierID = courierID;
            this.senderName = senderName;
            this.senderAddress = senderAddress;
            this.receiverName = receiverName;
            this.receiverAddress = receiverAddress;
            this.weight = weight;
            this.status = status;
            this.trackingNumber = trackingNumber;
            this.deliveryDate = deliveryDate;
            this.userID = userID;
        }

        //Adding getters and setters
        public int CourierID { get => courierID; set => courierID = value; }
        public string SenderName { get => senderName; set => senderName = value; }
        public string SenderAddress { get => senderAddress; set => senderAddress = value; }
        public string ReceiverName { get => receiverName; set => receiverName = value; }
        public string ReceiverAddress { get => receiverAddress; set => receiverAddress = value; }
        public double Weight { get => weight; set => weight = value; }
        public string Status { get => status; set => status = value; }
        public string TrackingNumber { get => trackingNumber; set => trackingNumber = value; }
        public DateTime DeliveryDate { get => deliveryDate; set => deliveryDate = value; }
        public int UserID { get => userID; set => userID = value; }

        // to string method
        public override string ToString() => $"CourierID: {courierID}, Sender: {senderName}, Status: {status}";
    }
}
