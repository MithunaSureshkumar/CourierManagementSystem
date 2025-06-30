namespace CourierManagementSystem.Entities
{
    public class Employee
    {
             int employeeID;
             string employeeName;
            string email;
            string contactNumber;
            string role;
             double salary;

            public Employee() { } // default constructor

        // creating parameterized constructor
            public Employee(int employeeID, string employeeName, string email, string contactNumber, string role, double salary)
            {
                this.employeeID = employeeID;
                this.employeeName = employeeName;
                this.email = email;
                this.contactNumber = contactNumber;
                this.role = role;
                this.salary = salary;
            }
        // getters and setters
            public int EmployeeID { get => employeeID; set => employeeID = value; }
            public string EmployeeName { get => employeeName; set => employeeName = value; }
            public string Email { get => email; set => email = value; }
            public string ContactNumber { get => contactNumber; set => contactNumber = value; }
            public string Role { get => role; set => role = value; }
            public double Salary { get => salary; set => salary = value; }

        // to string method
            public override string ToString() => $"EmployeeID: {employeeID}, Name: {employeeName}, Role: {role}";
        }
    }

