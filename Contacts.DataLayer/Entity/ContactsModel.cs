namespace Contacts.DataLayer.Entity
{
    using System.Data.Entity;
    
    public partial class ContactsModel : DbContext
    {
        public ContactsModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<ContactRegister> ContactRegisters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
