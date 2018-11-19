using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace Contacts.WebApi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(): base("DefaultConnection")
        {

        }

        public DbSet <ContactRegister> contactRegister { get; set; }
    }
}
