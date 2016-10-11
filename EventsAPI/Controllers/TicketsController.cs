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
using System.IO;
using Newtonsoft.Json;

namespace EventsAPI.Controllers
{
    public class TicketsController : ApiController
    {
        private EventsDBContext db = new EventsDBContext();

        // GET /Tickets
        public string GetTickets()
        {
            return (new JavaScriptSerializer().Serialize(db.Tickets.AsEnumerable()));
            //      return Helper.AsJsonList<Tickets>((List<Tickets>)(db.Tickets.AsEnumerable()));

        }

        // GET /Tickets/5
        public string GetTickets(int id)
        {
            Tickets tickets = db.Tickets.Find(id);
            if (tickets == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Helper.AsJson(tickets);
        }

        // POST /Tickets        
        public HttpResponseMessage PostTickets([FromBody] string jsTickets)
        {
            if (ModelState.IsValid)
            {
                List<Tickets> tickets = Helper.AsObjectList<Tickets>(jsTickets);
                
                foreach (Tickets ticket in tickets)
                {
                    db.Tickets.Add(ticket);
                }
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tickets);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tickets[0].ticketid}));
  
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }


        // PUT /Tickets/5
        //public HttpResponseMessage PutTickets(int id, Tickets tickets)
        //{
        //    if (ModelState.IsValid && id == tickets.ticketid)
        //    {
        //        db.Entry(tickets).State = EntityState.Modified;

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

        // DELETE /Tickets/5
        //public HttpResponseMessage DeleteTickets(int id)
        //{
        //    Tickets tickets = db.Tickets.Find(id);
        //    if (tickets == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    db.Tickets.Remove(tickets);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, tickets);
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}