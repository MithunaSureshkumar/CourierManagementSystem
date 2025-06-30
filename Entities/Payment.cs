namespace CourierManagementSystem.Entities
{
    internal class Payment
    {
         long paymentID;
         long courierID;
         double amount;
         DateTime paymentDate;

        // Default constructor
        public Payment() { }

        // Parameterized constructor
        public Payment(long paymentID, long courierID, double amount, DateTime paymentDate)
        {
            this.paymentID = paymentID;
            this.courierID = courierID;
            this.amount = amount;
            this.paymentDate = paymentDate;
        }

        // getters and setters
        public long PaymentID { get => paymentID; set => paymentID = value; }
        public long CourierID { get => courierID; set => courierID = value; }
        public double Amount { get => amount; set => amount = value; }
        public DateTime PaymentDate { get => paymentDate; set => paymentDate = value; }


        // To string method
        public override string ToString() => $"PaymentID: {paymentID}, CourierID: {courierID}, Amount: {amount}";
    }
}

