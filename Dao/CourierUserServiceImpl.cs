using CourierManagementSystem.Entities;

namespace CourierManagementSystem.Dao
{
    public class CourierUserServiceImpl:ICourierUserService
    {
        protected CourierCompany companyObj;
        public  CourierUserServiceImpl(CourierCompany companyObj)
        {
            this.companyObj = companyObj;
        }
        public string PlaceOrder(Courier courier)
        {
            courier.TrackingNumber = "TRK" + new Random().Next(10000, 99999);
            companyObj.CourierDetails.Add(courier);
            return courier.TrackingNumber;
        }
        public string GetOrderStatus(string trackingNumber)
        {
            foreach (var courier in companyObj.CourierDetails)
            {
                if (courier.TrackingNumber == trackingNumber)
                    return courier.Status;
            }
            return "Tracking number not found.";
        }

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

        public List<Courier> GetAssignedOrder(int courierStaffId)
        {
            return companyObj.CourierDetails.FindAll(c => c.UserID == courierStaffId);
        }
    }
}

