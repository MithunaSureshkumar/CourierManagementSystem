namespace CourierManagementSystem.Entities
{
    internal class User
    {
         int userID;
         string userName;
        string email;
         string password;
         string contactNumber;
         string address;

        public User() { } // default constructor

        // parametrized constructor
        public User(int userID, string userName, string email, string password, string contactNumber, string address)
        {
            this.userID = userID;
            this.userName = userName;
            this.email = email;
            this.password = password;
            this.contactNumber = contactNumber;
            this.address = address;
        }

        // getters and setters
        public int UserID { get => userID; set => userID = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string ContactNumber { get => contactNumber; set => contactNumber = value; }
        public string Address { get => address; set => address = value; }

        public override string ToString() => $"UserID: {userID}, Name: {userName}, Email: {email}";
    }
}

