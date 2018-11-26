using System;
using System.Collections.Generic;
using System.Linq;
using Contacts.DataLayer;
using Contacts.DataLayer.Entity;

namespace Contacts.BusinessLayer.Interfaces
{
    public interface IContactRegister
    {
        IEnumerable<ContactRegister> ContactRegisterGet();
        string ContactRegisterInsert(ContactRegister contact);
        string ContactRegisterUpdate(ContactRegister contact);
        string ContactRegisterDelete(int id);

    }
}
