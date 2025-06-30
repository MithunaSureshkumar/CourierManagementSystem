using CourierManagementSystem.Dao;
using CourierManagementSystem.Entities;

namespace CourierManagementSystem.MainModule
{
    internal class MainModule1
    {

        public void Run()
        {
            CourierServiceDb service = new CourierServiceDb();
            int choice;
            do
            {
                Console.WriteLine("\n=== Courier User Service Menu ===");
                Console.WriteLine("1. Place New Courier Order");
                Console.WriteLine("2. Get Courier Order Status");
                Console.WriteLine("3. Cancel Courier Order");
                Console.WriteLine("4. View Orders Assigned to Courier Staff");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                    continue;
                

                switch (choice)
                {
                    case 1:
                        Courier newCourier = new Courier();

                        Console.Write("Enter Sender Name: ");
                        newCourier.SenderName = Console.ReadLine();

                        Console.Write("Enter Sender Address: ");
                        newCourier.SenderAddress = Console.ReadLine();

                        Console.Write("Enter Receiver Name: ");
                        newCourier.ReceiverName = Console.ReadLine();

                        Console.Write("Enter Receiver Address: ");
                        newCourier.ReceiverAddress = Console.ReadLine();

                        Console.Write("Enter Weight: ");
                        newCourier.Weight = double.Parse(Console.ReadLine());

                        Console.Write("Enter Status: ");
                        newCourier.Status = Console.ReadLine();

                        Console.Write("Enter Tracking Number: ");
                        newCourier.TrackingNumber = Console.ReadLine();

                        Console.Write("Enter Delivery Date (yyyy-mm-dd): ");
                        newCourier.DeliveryDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter User ID: ");
                        newCourier.UserID = int.Parse(Console.ReadLine());

                        service.InsertCourier(newCourier);
                        Console.WriteLine("Courier inserted successfully.");
                        break;

                    case 2:
                        Console.Write("Enter Tracking Number: ");
                        string tnUpdate = Console.ReadLine();
                        Console.Write("Enter New Status: ");
                        string newStatus = Console.ReadLine();
                        bool updated = service.UpdateCourierStatus(tnUpdate, newStatus);
                        Console.WriteLine(updated ? "Status updated." : "Courier not found.");
                        break;

                    case 3:
                        Console.Write("Enter Tracking Number: ");
                        string tn = Console.ReadLine();
                        Courier c = service.GetCourierByTrackingNumber(tn);
                        if (c != null)
                            Console.WriteLine($"Sender: {c.SenderName}, Receiver: {c.ReceiverName}, Status: {c.Status}");
                        else
                            Console.WriteLine("Courier not found.");
                        break;

                    case 4:
                        Console.Write("Enter Receiver Name: ");
                        string receiver = Console.ReadLine();
                        List<Courier> history = service.GetDeliveryHistory(receiver);
                        if (history.Count == 0)
                            Console.WriteLine("No delivery history found.");
                        else
                        {
                            Console.WriteLine("Delivery History:");
                            foreach (var h in history)
                                Console.WriteLine($"{h.TrackingNumber} - {h.Status} - Delivered on: {h.DeliveryDate.ToShortDateString()}");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Shipment Status Report:");
                        var statusReport = service.GetShipmentStatusReport();
                        foreach (var kv in statusReport)
                            Console.WriteLine($"{kv.Key}: {kv.Value}");
                        break;

                    case 6:
                        double revenue = service.GetTotalRevenueReport();
                        Console.WriteLine($"Total Revenue: ₹{revenue}");
                        break;

                    case 7:
                        Console.WriteLine("Exiting user service...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            } while (choice != 5);
        }
    }

}


