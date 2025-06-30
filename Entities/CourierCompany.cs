namespace CourierManagementSystem.Entities
{
    public class CourierCompany
    {
        public string CompanyName { get; set; }
        public List<Courier> CourierDetails { get; set; }
        public List<Employee> EmployeeDetails { get; set; }
        public List<Location> LocationDetails { get; set; }

        // Default constructor
        public CourierCompany()
        {
            CourierDetails = new List<Courier>();
            EmployeeDetails = new List<Employee>();
            LocationDetails = new List<Location>();
        }

        // Parametrized constructor
        public CourierCompany(string companyName) : this()
        {
            CompanyName = companyName;
        }

        //To string method
        public override string ToString() => $"Courier Company: {CompanyName}, Couriers: {CourierDetails.Count}, Employees: {EmployeeDetails.Count}";
    }
}
