namespace CourierManagementSystem.Entities
{
    public class Location
        {
             int locationID;
             string locationName;
             string address;
        
            public Location() { } // default constructor

        // parameterized constructors
            public Location(int locationID, string locationName, string address)
            {
                this.locationID = locationID;
                this.locationName = locationName;
                this.address = address;
            }
        // getters and setters
            public int LocationID { get => locationID; set => locationID = value; }
            public string LocationName { get => locationName; set => locationName = value; }
            public string Address { get => address; set => address = value; }

        // To string method
            public override string ToString() => $"LocationID: {locationID}, Name: {locationName}";
        }
}
