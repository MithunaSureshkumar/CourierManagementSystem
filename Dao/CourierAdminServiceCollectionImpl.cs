using CourierManagementSystem.Entities;

namespace CourierManagementSystem.Dao
{
    internal class CourierAdminServiceCollectionImpl : CourierUserServiceCollectionImpl, ICourierAdminService
    {
        public CourierAdminServiceCollectionImpl(CourierCompanyCollection companyObj) : base(companyObj)
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
