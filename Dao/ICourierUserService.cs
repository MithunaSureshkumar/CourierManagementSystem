using CourierManagementSystem.Entities;

namespace CourierManagementSystem.Dao
{
    internal interface ICourierUserService
    {
        string PlaceOrder(Courier courierObj);
        // Get the status of a courier order.
        // param name="trackingNumber"Tracking number of the order
        // returns Status string (e.g., yetToTransit, In Transit, Delivered)
        string GetOrderStatus(string trackingNumber);
        // Cancel a courier order.
        // Tracking number of the order
        // returns True if cancellation is successful, false otherwise
        bool CancelOrder(string trackingNumber);
        // Get all orders assigned to a specific courier staff member.
        // Employee ID of courier staff
        //<returns>List of Courier objects
        List<Courier> GetAssignedOrder(int courierStaffId);
    }
}
