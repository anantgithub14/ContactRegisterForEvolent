using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Contacts.BusinessLayer.Interfaces;
using Contacts.DataLayer.Entity;
using Contacts.WebApi.Controllers;
using System.Net.Http;

namespace Contacts.WebApi.UnitTest
{
    [TestClass]
    public class ContactsControllerTest
    {
        [TestMethod]
        public void GetContactDetailsTest()
        {
            IContactRegister contact = new FakeContact();
            ContactsController controller = new ContactsController(contact);

            IEnumerable<ContactRegister> lstContacts = new List<ContactRegister>();
            lstContacts = controller.GetContactDetails();

            int count = 0;
            foreach(var objContact in lstContacts)
            {
                count++;
            }

            Assert.IsTrue(count == 1, "Count is not correct");
            

        }
    }

    public class FakeContact : IContactRegister
    {
        public string ContactRegisterDelete(int id)
        {
            return "Deleted";
        }

        public IEnumerable<ContactRegister> ContactRegisterGet()
        {
            List<ContactRegister> contactList = new List<ContactRegister>();
            contactList.Add(new ContactRegister() { ContactId = 1, ContactStatus = "Active", Email = "test@test.com", FirstName = "Aks", LastName = "Test", PhoneNumber = "1232232321" });

            return contactList;
        }

        public string ContactRegisterInsert(ContactRegister contact)
        {
            return "inserted";
        }

        public string ContactRegisterUpdate(ContactRegister contact)
        {
            return "updated";
        }
    }
}
