using CourierManagementSystem.Entities;

namespace CourierManagementSystem.Dao
{
    public class CourierAdminServiceImpl : CourierUserServiceImpl, ICourierAdminService
    {
        public CourierAdminServiceImpl(CourierCompany companyObj) : base(companyObj)
        {
        }
        public int AddCourierStaff(Employee employee)
        {
            int newId = companyObj.EmployeeDetails.Count + 1;
            employee.EmployeeID = newId;
            companyObj.EmployeeDetails.Add(employee);
            return newId;
        }
    }
}


       
    


