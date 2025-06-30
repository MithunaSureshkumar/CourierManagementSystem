using CourierManagementSystem.Entities;
using CourierManagementSystem.MainModule;
using System.ComponentModel;

namespace CourierManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainModule1 app = new MainModule1();
            app.Run();
            //            //Task 1 Control flow Statements

            //            // 1.Write a program that checks whether a given order is delivered or not based on its status (e.g., 
            //            // "Processing," "Delivered," "Cancelled"). Use if-else statements for this

            //            Console.WriteLine("Enter the Status of the Delivery");
            //            String Status = Console.ReadLine();
            //            String lowerstatus = Status.ToLower();
            //            if (lowerstatus == "processing")
            //            {
            //                Console.WriteLine("Your order is under Processing");
            //            }
            //            else if (lowerstatus == "delivered")
            //            {
            //                Console.WriteLine("Your Order had delivered");
            //            }
            //            else
            //            {
            //                Console.WriteLine("Your Order had been Cancelled");
            //            }

            //            // 2. Implement a switch-case statement to categorize parcels based on their weight into "Light," "Medium," or "Heavy."

            //            Console.Write("Enter the parcel weight: ");
            //            double weight = Convert.ToDouble(Console.ReadLine());
            //            // Categorize using switch by mapping weight range to a category code
            //            int categoryCode;
            //            if (weight < 1)
            //                categoryCode = 1; // Light
            //            else if (weight >= 1 && weight <= 5)
            //                categoryCode = 2; // Medium
            //            else
            //                categoryCode = 3; // Heavy

            //            switch (categoryCode)
            //            {
            //                case 1:
            //                    Console.WriteLine("Parcel is Light");
            //                    break;
            //                case 2:
            //                    Console.WriteLine("Parcel is Medium");
            //                    break;
            //                case 3:
            //                    Console.WriteLine("Parcel is Heavy");
            //                    break;
            //                default:
            //                    Console.WriteLine("Invalid weight category");
            //                    break;
            //            }

            //            // 3.Implement User Authentication 1. Create a login system for employees and customers using Java control flow statements.

            //            string empUsername = "employee1";
            //            string empPassword = "emp1";
            //            string custUsername = "customer1";
            //            string custPassword = "cust1";

            //            Console.Write("Enter user type: "); //employee,customer
            //            string userType = Console.ReadLine().ToLower();

            //            Console.Write("Enter username: ");
            //            string inputUsername = Console.ReadLine();

            //            Console.Write("Enter password: ");
            //            string inputPassword = Console.ReadLine();

            //            if (userType == "employee")
            //            {
            //                if (inputUsername == empUsername && inputPassword == empPassword)
            //                    Console.WriteLine("Employee login successful");
            //                else
            //                    Console.WriteLine(" Invalid employee credentials");
            //            }
            //            else if (userType == "customer")
            //            {
            //                if (inputUsername == custUsername && inputPassword == custPassword)
            //                    Console.WriteLine(" Customer login successful");
            //                else
            //                    Console.WriteLine(" Invalid customer credentials");
            //            }
            //            else
            //            {
            //                Console.WriteLine(" Unknown user type");
            //            }

            //            //4. Implement Courier Assignment Logic 1. Develop a mechanism to assign couriers to shipments based 
            //            // on predefined criteria(e.g., proximity, load capacity) using loops.

            //                string[] couriers = { "Raj", "Ali", "John", "Sara" };
            //                int[] loadCapacities = { 30, 20, 25, 15 }; // in kg
            //                int[] proximities = { 10, 5, 8, 12 };      // in km

            //                Console.Write("Enter parcel weight: ");
            //                int parcelWeight = int.Parse(Console.ReadLine());

            //                Console.Write("Enter maximum acceptable proximity: ");
            //                int maxProximity = int.Parse(Console.ReadLine());

            //                bool assigned = false;

            //                for (int i = 0; i < couriers.Length; i++)
            //                {
            //                    if (loadCapacities[i] >= parcelWeight && proximities[i] <= maxProximity)
            //                    {
            //                        Console.WriteLine($"Courier assigned: {couriers[i]}");
            //                        assigned = true;
            //                        break;
            //                    }
            //                }

            //                if (!assigned)
            //                {
            //                    Console.WriteLine(" No suitable courier found based on the criteria");
            //                }

            //            // Loops and Iterations
            //            // 5.  Write a C# program that uses a for loop to display all the orders for a specific customer.

            //                string[] customerNames = { "Alice", "Bob", "Alice", "John" };
            //                string[] orderDetails = { "Order101 - Laptop", "Order102 - Phone", "Order103 - Tablet", "Order104 - Monitor" };

            //                Console.Write("Enter customer name to search: ");
            //                string customerToSearch = Console.ReadLine();

            //                bool found = false;

            //                Console.WriteLine("\nOrders for customer: " + customerToSearch);

            //                for (int i = 0; i < customerNames.Length; i++)
            //                {
            //                    if (customerNames[i].Equals(customerToSearch, StringComparison.OrdinalIgnoreCase)) // to ignore the case
            //                    {
            //                        Console.WriteLine(orderDetails[i]);
            //                        found = true;
            //                    }
            //                }

            //                if (!found)
            //                {
            //                    Console.WriteLine("No orders found");
            //                }



            //            // 6. Implement a while loop to track the real-time location of a courier until it reaches its destination.

            //                int location = 0;
            //                int destination = 100;

            //                Console.WriteLine("Tracking courier");

            //                while (location < destination)
            //                {
            //                    Console.WriteLine($"Current location: " + location + " km");

            //                    // for every loop the distance increases by 10km
            //                    location += 10;
            //                }

            //                Console.WriteLine("Courier  reached the destination");

            //            // task 3 - Arrays and Data Structures
            //// 7.Create an array to store the tracking history of a parcel, where each entry represents a location  update.

            //                // Create an array to store location updates
            //                string[] trackingHistory = new string[5];

            //                // Sample location updates
            //                trackingHistory[0] = "Warehouse - Chennai";
            //                trackingHistory[1] = "Sorting Center - Bangalore";
            //                trackingHistory[2] = "En route to Hyderabad";
            //                trackingHistory[3] = "Arrived at Hyderabad Hub";
            //                trackingHistory[4] = "Out for delivery - Hyderabad";

            //                // Print the tracking history
            //                Console.WriteLine("Parcel Tracking History:");
            //                for (int i = 0; i < trackingHistory.Length; i++)
            //                {
            //                    Console.WriteLine($"Update {i + 1}: {trackingHistory[i]}"); // gives in the format update 1 : history{1}
            //                }
            //            //8. Implement a method to find the nearest available courier for a new order using an array of couriers.  

            //                string[] Couriers = { "Ram", "Vijay", "Anita", "John" };
            //                int[] distances = { 12, 5, 8, 6 };
            //                bool[] available = { true, false, true, true };

            //                int min = int.MaxValue; // here we can use any hard coded values
            //                string nearest = ""; // no courier has been assigned initially

            //                for (int i = 0; i < couriers.Length; i++)
            //                {
            //                    if (available[i] && distances[i] < min)
            //                    {
            //                        min = distances[i];
            //                        nearest = couriers[i];
            //                    }
            //                }

            //                Console.WriteLine("Nearest available courier: " + (nearest != "" ? nearest : "None")); // using ternary operator

            //            // Task 4
            //            // 9. Parcel Tracking: Create a program that allows users to input a parcel tracking number.Store the
            //            //tracking number and Status in 2d String Array. Initialize the array with values.Then, simulate the
            //            //tracking process by displaying messages like "Parcel in transit," "Parcel out for delivery," or "Parcel 
            //            //delivered" based on the tracking number's status.  


            //                string[,] parcels = new string[,]
            //                {
            //                       { "TRK001", "In Transit" },
            //                       { "TRK002", "Out for Delivery" },
            //                       { "TRK003", "Delivered" },
            //                       { "TRK004", "Pending" }
            //                };
            //                Console.Write("Enter Tracking Number: ");
            //                string input = Console.ReadLine();
            //                 found = false;
            //                for (int i = 0; i < parcels.GetLength(0); i++) // searching 
            //                {
            //                    if (parcels[i, 0].Equals(input, StringComparison.OrdinalIgnoreCase))
            //                    {
            //                        found = true;
            //                        string status = parcels[i, 1];

            //                        Console.WriteLine("Tracking Number: " + parcels[i, 0]);
            //                        Console.WriteLine("Status: " + status);
            //                    if (status == "In Transit")
            //                        Console.WriteLine("Parcel is moving through the logistics network");
            //                    else if (status == "Out for Delivery")
            //                        Console.WriteLine("Parcel is out for delivery");
            //                    else if (status == "Delivered")
            //                        Console.WriteLine("Parcel has been delivered");
            //                    else
            //                        Console.WriteLine("Parcel status is currently pending");
            //                    }
            //                }

            //                if (!found)
            //                {
            //                    Console.WriteLine(" Tracking number not found");
            //                }

            //            //            // 10. Customer Data Validation: Write a function which takes 2 parameters, data-denotes the data and 
            //            //            detail - denotes if it is name addtress or phone number.Validate customer information based on
            //            //following critirea. Ensure that names contain only letters and are properly capitalized, addresses do not
            //            //contain special characters, and phone numbers follow a specific format(e.g., ###-###-####). 




            //            //// 11. Address Formatting: Develop a function that takes an address as input (street, city, state, zip code) 
            //            //and formats it correctly, including capitalizing the first letter of each word and properly formatting the
            //            //zip code.

            //            static string CapitalizeWords(string input)
            //            {
            //                string[] words = input.Split(' ');
            //                for (int i = 0; i < words.Length; i++)
            //                {
            //                    if (words[i].Length > 0)
            //                        words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            //                }
            //                return string.Join(" ", words);
            //            }

            //                string street = "123 main street";
            //                string city = "new york";
            //                string state = "new york";
            //                string zip = "456";

            //                // Capitalize each part
            //                street = CapitalizeWords(street);
            //                city = CapitalizeWords(city);
            //                state = CapitalizeWords(state);

            //                // Format ZIP code to 5 digits
            //                if (zip.Length < 6)
            //                    zip = zip.PadLeft(6, '0');
            //                else if (zip.Length > 6)
            //                    zip = zip.Substring(0, 6);

            //                // Combine and print
            //                Console.WriteLine("Formatted Address:");
            //                Console.WriteLine($"{street}, {city}, {state} - {zip}");

            //  // 12. Order Confirmation Email: Create a program that generates an order confirmation email. The email 
            // //  should include details such as the customer's name, order number, delivery address, and expected delivery date

            //                // Sample input data
            //                string customerName = "Mithuna Sureshkumar";
            //                string orderNumber = "ORD123456";
            //                string deliveryAddress = "25, Rose Street, Coimbatore, Tamil Nadu - 641001";
            //                DateTime expectedDeliveryDate = DateTime.Now.AddDays(5);

            //                // Generate the email message
            //                string emailMessage = GenerateConfirmationEmail(customerName, orderNumber, deliveryAddress, expectedDeliveryDate);

            //                // Display the email
            //                Console.WriteLine("=== Order Confirmation Email ===\n");
            //                Console.WriteLine(emailMessage);


            //            static string GenerateConfirmationEmail(string name, string orderNo, string address, DateTime deliveryDate)
            //            {
            //                return
            //             $@"Dear {name},

            //            Thank you for your order!

            //             Order Number   : {orderNo}
            //             Delivery Address: {address}
            //             Expected Delivery Date: {deliveryDate.ToString("dddd, dd MMMM yyyy")}

            //             We will notify you once your parcel is out for delivery.

            //             Warm regards,
            //             Courier Management Team";
            //            }
            //            //13. Calculate Shipping Costs: Develop a function that calculates the shipping cost based on the distance 
            //            //between two locations and the weight of the parcel.You can use string inputs for the source and destination addresses.

            //            Console.Write("Enter Source Address: ");
            //        string source = Console.ReadLine();

            //        Console.Write("Enter Destination Address: ");
            //        string destination1 = Console.ReadLine();

            //        Console.Write("Enter Weight of Parcel (kg): ");
            //         weight = Convert.ToDouble(Console.ReadLine());

            //        int distance = GetDistance(source, destination1);
            //        double ratePerKm = 4.0; // ₹4 per km
            //        double ratePerKg = 8.0; // ₹8 per kg

            //        double cost = (distance * ratePerKm) + (weight * ratePerKg);

            //        Console.WriteLine($"\nShipping Cost from {source} to {destination1} for {weight}kg is ₹{cost:F2}");
            //              // Simulate distance estimation
            //    static int GetDistance(string from, string to)
            //        {
            //            if ((from.ToLower() == "coimbatore" && to.ToLower() == "chennai") ||
            //                (from.ToLower() == "chennai" && to.ToLower() == "coimbatore"))
            //                return 500;

            //            if ((from.ToLower() == "coimbatore" && to.ToLower() == "bangalore") ||
            //                (from.ToLower() == "bangalore" && to.ToLower() == "coimbatore"))
            //                return 350;

            //            if ((from.ToLower() == "chennai" && to.ToLower() == "bangalore") ||
            //                (from.ToLower() == "bangalore" && to.ToLower() == "chennai"))
            //                return 350;

            //            return 100; // default distance if not matched

            //        }
            // //  14.Password Generator: Create a function that generates secure passwords for courier system
            // //accounts.Ensure the passwords contain a mix of uppercase letters, lowercase letters, numbers, and
            // //special characters.

            //                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            //                Random rand = new Random();
            //                string password = "";

            //                for (int i = 0; i < 8; i++) // password length is 8
            //                {
            //                    int index = rand.Next(chars.Length);
            //                    password += chars[index];
            //                }

            //                Console.WriteLine("Generated Password: " + password);

            //            //   15.Find Similar Addresses: Implement a function that finds similar addresses in the system. This can be
            //            //useful for identifying duplicate customer entries or optimizing delivery routes.Use string functions to
            //            //implement this.

            //                string[] addresses = {
            //            "123 Main Street",
            //            "123 Main St.",
            //            "456 Elm Road",
            //            "123 main street",
            //            "789 Pine Avenue"
            //        };

            //                Console.Write("Enter address to search: ");
            //                string input1 = Console.ReadLine().ToLower();

            //                Console.WriteLine("\nSimilar Addresses:");
            //                foreach (string addr in addresses)
            //                {
            //                    if (addr.ToLower().Contains(input1))
            //                    {
            //                        Console.WriteLine(addr);
            //                    }
            //                }
            //            }
        }
    }
}















    


























    











