using System;
using System.Collections.Generic;
using System.Text;

namespace Driver.Application.DTO
{
   public class DriverDTO
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
