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
            TempData["Message"] = "Success";
            return _Contacts.GetAll();
        }

        [Route("Search")]
        [HttpPost]
        public IActionResult SearchContact([FromBody] UsersContact Contact)
        {
            TempData["Message"] = "Success";
            return _Contacts.GetContact(Contact.FullName)!=null ? View("./Index", _Contacts.GetContact(Contact.FullName)) : View("./Index", TempData["Message"] = "Error");
        }

        //Delete Contact By FullName
        [Route("Delete")]
        [HttpPost]
        public IActionResult DeleteContact(string FullName)
        {
            TempData["Message"] = "Success";
            return _Contacts.DeleteContact(FullName)!=null ? View("./Index", _Contacts.DeleteContact(FullName)) : View("./Index", TempData["Message"]="Error");
        }

        //Add New Contact 
        [Route("Add")]
        [HttpPost]
        public IActionResult AddContact(UsersContact contact)
        {
            TempData["Message"] = "Success";
            return _Contacts.AddContact(contact)!=null ? View("./Index",_Contacts.AddContact(contact)) : View("./Index", TempData["Message"]="Error");
        }

        //Update Existing Contact
        [Route("Update")]
        [HttpPost]
        public IActionResult UpdateContact(UsersContact contact) {
            TempData["Message"] = "Success";
            return _Contacts.ChangeContact(contact) != null ? View("./Index", _Contacts.ChangeContact(contact)) : View("./Index", TempData["Message"]="Error");
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
