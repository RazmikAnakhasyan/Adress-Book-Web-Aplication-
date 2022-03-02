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
using Adress_Book_Web_Aplication_.Repositories.Interfaces;

namespace Adress_Book_Web_Aplication_.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContacts _Contacts;//Now This Interface Iplement User_Contact Class 

        public HomeController(IContacts contacts)
        {
            _Contacts = contacts;
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
            return _Contacts.GetAll();
        }

        [Route("Search")]
        [HttpPost]
        public UsersContact SearchContact([FromBody] UsersContact Contact)
        {
            return _Contacts.GetContact(Contact.FullName);
        }

        //Delete Contact By FullName
        [Route("Delete")]
        [HttpPost]
        public UsersContact DeleteContact(string FullName)
        {
            return _Contacts.DeleteContact(FullName);
        }

        //Add New Contact 
        [Route("Add")]
        [HttpPost]
        public UsersContact AddContact(UsersContact contact)
        {
           return _Contacts.AddContact(contact);
        }

        //Update Existing Contact
        [Route("Update")]
        [HttpPost]
        public UsersContact UpdateContact(UsersContact contact) {
            return _Contacts.ChangeContact(contact);
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
