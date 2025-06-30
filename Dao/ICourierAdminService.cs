using CourierManagementSystem.Entities;

namespace CourierManagementSystem.Dao
{
    internal interface ICourierAdminService
    {
        /// Add a new courier staff member.
        /// Employee object representing the new staff
        /// returns ID of the newly added courier staff member
        int AddCourierStaff(Employee staff);
    }
}

