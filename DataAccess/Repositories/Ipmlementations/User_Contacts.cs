using Adress_Book_Web_Aplication_.Repositories.Interfaces;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adress_Book_Web_Aplication_.Repositories.Ipmlementations
{
    public class User_Contacts : IContacts
    {
        //database context instance
        private readonly AdressBookContext _Context;
        
        public User_Contacts(AdressBookContext context)
        {
            _Context = context;
        }

        // Method for adding new conatct to contact list
        public UsersContact AddContact(UsersContact NewContact)
        {
            _Context.Add(NewContact);
            _Context.SaveChanges();
            return NewContact;
        }

        //Method for change existing contact data
        public UsersContact ChangeContact(UsersContact UpdatedContact)
        {
            var Contact = _Context.UsersContacts.FirstOrDefault(_ => _.FullName == UpdatedContact.FullName);
            
            if (Contact !=null)//checking if we have entity with UpdatedContact.PhoneNumber
            {
                Contact.FullName = UpdatedContact.FullName;
                Contact.PhoneNumber = UpdatedContact.PhoneNumber;
                Contact.EmailAdress = UpdatedContact.EmailAdress;
                Contact.PhysicalAddres = UpdatedContact.PhysicalAddres;
                _Context.SaveChanges();
                     return Contact;
            }
            return null;
        }

        //Method for deleteing existing contact from database
        public UsersContact DeleteContact(string FullName)
        {
                var DeleteContact = _Context.UsersContacts.FirstOrDefault(_ => _.FullName == FullName);
            if (DeleteContact!=null)//checking if we have matching for this contact
            {
                _Context.Remove(DeleteContact);
                _Context.SaveChanges();
                return DeleteContact;
            }
                return null;
        }

        //Method that show all available contacts
        public IEnumerable<UsersContact> GetAll()
        {
            return _Context.UsersContacts;
        }

        //Method that show accurate contact
        public UsersContact GetContact(string FullName)
        {
            var currentContact = _Context.UsersContacts.FirstOrDefault(_ => _.FullName.StartsWith(FullName) || _.FullName.Contains(FullName));
            if (currentContact!=null)//checking if we have matching for this contact
            {
                return currentContact;
            }
            return null;
        }
    }
}
