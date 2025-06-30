using CourierManagementSystem.Entities;

namespace CourierManagementSystem.Dao
{
    public class CourierUserServiceCollectionImpl:ICourierUserService

    {
        protected CourierCompanyCollection companyObj;

        // Constructor: pass CourierCompanyCollection object
        public CourierUserServiceCollectionImpl(CourierCompanyCollection companyObj)
        {
            this.companyObj = companyObj;
        }

        // 1. Place Order
        public string PlaceOrder(Courier courierObj)
        {
            string trackingNumber = "TRK" + new Random().Next(10000, 99999);
            courierObj.TrackingNumber = trackingNumber;
            courierObj.Status = "YetToTransit";
            companyObj.CourierDetails.Add(courierObj);
            return trackingNumber;
        }

        // 2. Get Order Status
        public string GetOrderStatus(string trackingNumber)
        {
            foreach (var courier in companyObj.CourierDetails)
            {
                if (courier.TrackingNumber == trackingNumber)
                    return courier.Status;
            }
            return "Tracking number not found.";
        }

        // 3. Cancel Order
        public bool CancelOrder(string trackingNumber)
        {
            foreach (var courier in companyObj.CourierDetails)
            {
                if (courier.TrackingNumber == trackingNumber)
                {
                    courier.Status = "Cancelled";
                    return true;
                }
            }
            return false;
        }

        // 4. Get Assigned Orders for a Staff ID
        public List<Courier> GetAssignedOrder(int courierStaffId)
        {
            return companyObj.CourierDetails.FindAll(c => c.UserID == courierStaffId);
        }

    }

}