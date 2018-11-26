using System.Collections.Generic;
using System.Linq;
using Contacts.BusinessLayer.Interfaces;
using Contacts.DataLayer.DataAccess;
using Contacts.DataLayer.Entity;

namespace Contacts.BusinessLayer.Implementation
{
    public class Contact : IContactRegister
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        private List<ContactRegister> listContact = new List<ContactRegister>();
        private ContactRegister objContactRegister = new ContactRegister();

        
        public IEnumerable<ContactRegister> ContactRegisterGet()
        {
            listContact = unitOfWork.GetContactRegisterRepository.Get().ToList();

            return listContact;
        }

        public string ContactRegisterInsert(ContactRegister contact)
        {
            this.unitOfWork.GetContactRegisterRepository.Insert(contact);
            int insertData = this.unitOfWork.Save();

            if (insertData > 0)
            {
                return "Successfully Inserted contact records";
            }
            else
            {
                return "Insertion faild";
            }
        }

        public string ContactRegisterUpdate(ContactRegister contact)
        {
            objContactRegister = unitOfWork.GetContactRegisterRepository.GetByID(contact.ContactId);

            if (objContactRegister != null)
            {
                objContactRegister.FirstName = contact.FirstName;
                objContactRegister.LastName = contact.LastName;
                objContactRegister.PhoneNumber = contact.PhoneNumber;
                objContactRegister.Email = contact.Email;
                objContactRegister.ContactStatus = contact.ContactStatus;
            }
            this.unitOfWork.GetContactRegisterRepository.Attach(objContactRegister);
            int result = this.unitOfWork.Save();

            if (result > 0)
            {
                return "Sucessfully updated contact records";
            }
            else
            {
                return "Updation faild";
            }
        }

        public string ContactRegisterDelete(int id)
        {
            var objContact = this.unitOfWork.GetContactRegisterRepository.GetByID(id);
            this.unitOfWork.GetContactRegisterRepository.Delete(objContact);
            int deleteData = this.unitOfWork.Save();
            if (deleteData > 0)
            {
                return "Successfully deleted contact records";
            }
            else
            {
                return "Deletion faild";
            }
        }
    }
}
