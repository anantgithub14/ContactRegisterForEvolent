using Contacts.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace Contacts.MVC.Controllers
{

    public class ContactMVCController : Controller
    {
        HttpClient client;
        string url = "http://localhost:58877/api/Contacts";
        List<SelectListItem> list;


        public ContactMVCController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            list = new List<SelectListItem>
             {
             new SelectListItem
                   {
                       Text="Active",
                       Value = "Active"
                   }
             ,new SelectListItem
                   {
                       Text="Deactive",
                       Value = "Deactive"
                    }
             };
        }
        

        // GET: ContactMVC
        public async Task<ActionResult> Index()
        {

            IEnumerable<ContactRegisterViewModel> contacts = null;
        
            //Sending request to find web api REST service resource GetAllContacts using HttpClient  
            HttpResponseMessage Res = await client.GetAsync(url);

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var contactResponse = Res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the Contact list  
                contacts = JsonConvert.DeserializeObject<List<ContactRegisterViewModel>>(contactResponse);

            }

            return View(contacts);            
        }
        public ActionResult Create()
        {
            ContactRegisterViewModel model = new ContactRegisterViewModel();          

            model.ListStatus = list;


            //return View(new ContactRegisterViewModel());
            return View(model);
        }

        //The Post method
        [HttpPost]
        public async Task<ActionResult> Create(ContactRegisterViewModel Contact)
        {
            
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, Contact);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Contact = JsonConvert.DeserializeObject<ContactRegisterViewModel>(responseData);
                Contact.ListStatus = list;

                return View(Contact);
            }
            return View("Error");
        }

        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, ContactRegisterViewModel Contact)
        {

            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, Contact);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Contact = JsonConvert.DeserializeObject<ContactRegisterViewModel>(responseData);

                return View(Contact);
            }
            return View("Error");
        }

        //The DELETE method
        [HttpPost]
        public async Task<ActionResult> Delete(int id, ContactRegisterViewModel Contact)
        {

            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
    }
}