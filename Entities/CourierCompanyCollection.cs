namespace CourierManagementSystem.Entities
{
    //Replace all arrays with dynamic lists 
    public class CourierCompanyCollection
    {
        //getters and setters
        public string CompanyName { get; set; }

        public List<Courier> CourierDetails { get; set; }
        public List<Employee> EmployeeDetails { get; set; }
        public List<Location> LocationDetails { get; set; }

        // Default constructor
        public CourierCompanyCollection()
        {
            CourierDetails = new List<Courier>();
            EmployeeDetails = new List<Employee>();
            LocationDetails = new List<Location>();
        }

    }
    }

