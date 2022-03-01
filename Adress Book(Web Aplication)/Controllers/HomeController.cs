using Adress_Book_Web_Aplication_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Adress_Book_Web_Aplication_.Repositories.Ipmlementations;

namespace Adress_Book_Web_Aplication_.Controllers
{
    public class HomeController : Controller
    {
        private readonly User_Contacts Contacts;
        public HomeController()
        {
            Contacts = new User_Contacts(new AdressBookContext());
        }

        //Home Page
        public IActionResult Index()
        {
            return View();
        }
        //Return All Contacts List
        [Route("All")]
        [HttpGet]
        public IEnumerable<UsersContact> AllContacts()
        {
            return Contacts.GetAll();
        }

        [Route("Search")]
        [HttpGet]
        public UsersContact SearchContact(string FullName) {
            return Contacts.GetContact(FullName);
        }

        //Delete Contact By FullName
        [Route("Delete")]
        [HttpPost]
        public UsersContact DeleteContact(string FullName)
        {
            return Contacts.DeleteContact(FullName);
        }

        //Add New Contact 
        [Route("Add")]
        [HttpPost]
        public UsersContact AddContact(UsersContact contact)
        {
           return Contacts.AddContact(contact);
        }

        //Update Existing Contact
        [Route("Update")]
        [HttpPost]
        public UsersContact UpdateContact(UsersContact contact) {
            return Contacts.ChangeContact(contact);
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
