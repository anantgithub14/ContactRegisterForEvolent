using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Contacts.BusinessLayer.Interfaces;
using Contacts.DataLayer.Entity;

namespace Contacts.WebApi.Controllers
{
    public class ContactsController : ApiController
    {
        IContactRegister _objContact;

        public ContactsController(IContactRegister objContact)
        {
            this._objContact = objContact;
        }

        // GET: api/Contacts
        public IEnumerable<ContactRegister> GetContactDetails()
        {
            IEnumerable<ContactRegister> contactDetail = new List<ContactRegister>();
            try
            {
                contactDetail = _objContact.ContactRegisterGet();
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return contactDetail;
            //return db.contactRegister;
        }

        // GET: api/Contacts/5
        [ResponseType(typeof(ContactRegister))]
        public IHttpActionResult GetContact(int id)
        {
            ContactRegister contactDetail = new ContactRegister();
            try
            {
                contactDetail = _objContact.ContactRegisterGet().Where(E => E.ContactId == id).FirstOrDefault();
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            if (contactDetail == null)
            {
                return NotFound();
            }

            return Ok(contactDetail);
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, ContactRegister contact)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.ContactId)
            {
                return BadRequest();
            }


            try
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }

                var objContact = this._objContact.ContactRegisterUpdate(contact);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

                      

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contacts
        [ResponseType(typeof(ContactRegister))]
        public IHttpActionResult PostContact(ContactRegister contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            try
            {
                var objContact = this._objContact.ContactRegisterInsert(contact);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }

            return CreatedAtRoute("DefaultApi", new { id = contact.ContactId }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(ContactRegister))]
        public IHttpActionResult DeleteContact(int id)
        {
            try
            {
                var objContact = this._objContact.ContactRegisterDelete(id);
            }
            catch (ApplicationException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, ReasonPhrase = ex.Message });
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { StatusCode = HttpStatusCode.BadGateway, ReasonPhrase = ex.Message });
            }
            
            
            return Ok();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private bool ContactExists(int id)
        {
            return _objContact.ContactRegisterGet().Count(e => e.ContactId == id) > 0;            
        }
    }
}