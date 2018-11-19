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
using Contacts.WebApi.Models;

namespace Contacts.WebApi.Controllers
{
    public class ContactsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Contacts
        public IQueryable<ContactRegister> GetContactDetails()
        {
            return db.contactRegister;
        }

        // GET: api/Contacts/5
        [ResponseType(typeof(ContactRegister))]
        public IHttpActionResult GetContact(int id)
        {
            ContactRegister contact = db.contactRegister.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
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

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
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

            db.contactRegister.Add(contact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contact.ContactId }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(ContactRegister))]
        public IHttpActionResult DeleteContact(int id)
        {
            ContactRegister contact = db.contactRegister.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.contactRegister.Remove(contact);
            db.SaveChanges();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.contactRegister.Count(e => e.ContactId == id) > 0;
        }
    }
}