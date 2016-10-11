using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using EventsAPI.Models;
using System.Web.Script.Serialization;

namespace EventsAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private EventsDBContext db = new EventsDBContext();

        public string GetCustomers()
        {
           return (new JavaScriptSerializer().Serialize(db.Customers.AsEnumerable()));
        }

        // GET /Customers/5

        public string GetCustomers(string userid)
        {
            Customers customers = db.Customers.Find(userid.Trim());
            if (customers == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Helper.AsJson<Customers>(customers);
        }

                // POST /Customers
        public HttpResponseMessage PostCustomers([FromBody] string jsCustomers)
        {
            if (ModelState.IsValid)
            {
                List<Customers> customers = Helper.AsObjectList<Customers>(jsCustomers);
                foreach (Customers customer in customers)
                {
                    db.Customers.Add(customer);
                } 
                db.SaveChanges();
                
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, customers);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = customers[0].userid}));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        // PUT /Customers/5
        //public HttpResponseMessage PutCustomers(string id, Customers customers)
        //{
        //    if (ModelState.IsValid && id == customers.userid)
        //    {
        //        db.Entry(customers).State = EntityState.Modified;

        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            return Request.CreateResponse(HttpStatusCode.NotFound);
        //        }

        //        return Request.CreateResponse(HttpStatusCode.OK);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //}


        // DELETE /Customers/5
    //    public HttpResponseMessage DeleteCustomers(string id)
    //    {
    //        Customers customers = db.Customers.Find(id);
    //        if (customers == null)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.NotFound);
    //        }

    //        db.Customers.Remove(customers);

    //        try
    //        {
    //            db.SaveChanges();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.NotFound);
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, customers);
    //    }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}