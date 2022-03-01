using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adress_Book_Web_Aplication_.Repositories.Interfaces
{
    interface IContacts
    {
        IEnumerable<UsersContact> GetAll();

        UsersContact GetContact(string PhoneNumber);

        UsersContact DeleteContact(string PhoneNumber);

        UsersContact ChangeContact(UsersContact UpdatedContact);

        UsersContact AddContact(UsersContact NewContact);

        
    }
}
