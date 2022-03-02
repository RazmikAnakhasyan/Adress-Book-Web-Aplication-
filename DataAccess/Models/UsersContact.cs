using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess
{
    public partial class UsersContact
    {
        public long ContactId { get; set; }
        public string FullName { get; set; }
        public string EmailAdress { get; set; }
        public string PhysicalAddres { get; set; }
        public string PhoneNumber { get; set; }
    }
}
