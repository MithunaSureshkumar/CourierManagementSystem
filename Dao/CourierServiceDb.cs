using CourierManagementSystem.ConnectionUtil;
using CourierManagementSystem.Entities;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace CourierManagementSystem.Dao
{
    public class CourierServiceDb
    {
        private static SqlConnection connection;

        public CourierServiceDb()
        {
            connection = CourierManagementSystem.ConnectionUtil.DbConnection.GetConnectionObject(); 
        }
        // 3. get courier by tracking number
        public Courier GetCourierByTrackingNumber(string trackingNumber)
        {
            Courier courier = null;
            string query = "select * from Couriers where TrackingNumber = @TrackingNumber";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                courier = new Courier
                {
                    CourierID = Convert.ToInt32(reader["CourierID"]),
                    SenderName = reader["SenderName"].ToString(),
                    SenderAddress = reader["SenderAddress"].ToString(),
                    ReceiverName = reader["ReceiverName"].ToString(),
                    ReceiverAddress = reader["ReceiverAddress"].ToString(),
                    Weight = Convert.ToDouble(reader["Weight"]),
                    Status = reader["Status"].ToString(),
                    TrackingNumber = reader["TrackingNumber"].ToString(),
                    DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"]),
                    UserID = Convert.ToInt32(reader["UserID"])
                };
            }

            connection.Close();
            return courier;

        }
        
            // 1. Insert a new courier order
            public void InsertCourier(Courier courier)
            {
                string query = @"insert into Couriers (SenderName, SenderAddress, ReceiverName, ReceiverAddress, Weight, Status, TrackingNumber, DeliveryDate, UserID)
                             values (@SenderName, @SenderAddress, @ReceiverName, @ReceiverAddress, @Weight, @Status, @TrackingNumber, @DeliveryDate, @UserID)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SenderName", courier.SenderName);
                cmd.Parameters.AddWithValue("@SenderAddress", courier.SenderAddress);
                cmd.Parameters.AddWithValue("@ReceiverName", courier.ReceiverName);
                cmd.Parameters.AddWithValue("@ReceiverAddress", courier.ReceiverAddress);
                cmd.Parameters.AddWithValue("@Weight", courier.Weight);
                cmd.Parameters.AddWithValue("@Status", courier.Status);
                cmd.Parameters.AddWithValue("@TrackingNumber", courier.TrackingNumber);
                cmd.Parameters.AddWithValue("@DeliveryDate", courier.DeliveryDate);
                cmd.Parameters.AddWithValue("@UserID", courier.UserID);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            // 2. Update courier status
            public bool UpdateCourierStatus(string trackingNumber, string newStatus)
            {
                string query = "update Couriers SET Status = @Status where TrackingNumber = @TrackingNumber";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                connection.Open();
                int rows = cmd.ExecuteNonQuery();
                connection.Close();

                return rows > 0;
            }

            

            // 4. Get delivery history by receiver name
            public List<Courier> GetDeliveryHistory(string receiverName)
            {
                List<Courier> history = new List<Courier>();
                string query = "select * from Couriers where ReceiverName = @ReceiverName";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ReceiverName", receiverName);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Courier courier = new Courier
                    {
                        CourierID = Convert.ToInt32(reader["CourierID"]),
                        SenderName = reader["SenderName"].ToString(),
                        SenderAddress = reader["SenderAddress"].ToString(),
                        ReceiverName = reader["ReceiverName"].ToString(),
                        ReceiverAddress = reader["ReceiverAddress"].ToString(),
                        Weight = Convert.ToDouble(reader["Weight"]),
                        Status = reader["Status"].ToString(),
                        TrackingNumber = reader["TrackingNumber"].ToString(),
                        DeliveryDate = Convert.ToDateTime(reader["DeliveryDate"]),
                        UserID = Convert.ToInt32(reader["UserID"])
                    };
                    history.Add(courier);
                }

                connection.Close();
                return history;
            }

            // 5. Get revenue report (sum of all payments)
            public double GetTotalRevenueReport()
            {
                string query = "select sum(Amount) from Payments";

                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();
                var result = cmd.ExecuteScalar();
                connection.Close();

                return result != DBNull.Value ? Convert.ToDouble(result) : 0.0;
            }

            // 6. Get shipment status report (group by status)
            public Dictionary<string, int> GetShipmentStatusReport()
            {
                Dictionary<string, int> report = new Dictionary<string, int>();
                string query = "select Status, count(*) as Count from Couriers group by Status";

                SqlCommand cmd = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string status = reader["Status"].ToString();
                    int count = Convert.ToInt32(reader["Count"]);
                    report.Add(status, count);
                }

                connection.Close();
                return report;
            }
        }
    }




