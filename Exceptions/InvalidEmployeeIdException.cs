using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem.Exceptions
{
   
        public class InvalidEmployeeIdException : Exception // from exception class which is a base
        {
            public InvalidEmployeeIdException() : base("Invalid Employee ID.") { } // default exception

            public InvalidEmployeeIdException(string message) : base(message) { }// creating custom exception
        }
    
}
