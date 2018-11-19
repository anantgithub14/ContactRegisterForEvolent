namespace Contacts.WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Contacts.WebApi.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Contacts.WebApi.Models.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.contactRegister.AddOrUpdate(x => x.ContactId,
                    new Models.ContactRegister() { ContactId = 1, FirstName = "Anant", LastName="Shah", Email="anantce@gmail.com", PhoneNumber="9049996481", ContactStatus="Active" } );
        }
    }
}
