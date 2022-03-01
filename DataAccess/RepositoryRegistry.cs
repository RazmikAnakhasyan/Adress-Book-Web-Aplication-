using Adress_Book_Web_Aplication_;
using Adress_Book_Web_Aplication_.Repositories.Interfaces;
using Adress_Book_Web_Aplication_.Repositories.Ipmlementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class RepositoryRegistry
    {
        //Adding Dependecy Injection For Interfaces
        public static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IContacts, User_Contacts>();
        }
        //Adding Dependency Injection For Database Context
        public static void RegisterDbContext(IServiceCollection services, string conenctionString)
        {
            services.AddDbContext<AdressBookContext>(_ => _.UseSqlServer(conenctionString));
        }
    }
}
