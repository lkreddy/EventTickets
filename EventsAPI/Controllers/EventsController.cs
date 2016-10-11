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
    public class EventsController : ApiController
    {
        private EventsDBContext db = new EventsDBContext();


        // GET /events
        public string GetEvents()
        {
           return (new JavaScriptSerializer().Serialize(db.Events.AsEnumerable()));
        }

        // GET /Events/5
        public string GetEvents(int id)
        {
            Events events = db.Events.Find(id);
            if (events == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Helper.AsJson(events);
        }
        
        // POST /Events
        public HttpResponseMessage PostEvents([FromBody] string jsEvents)
        {
            if (ModelState.IsValid)
            {
                List<Events> events = Helper.AsObjectList<Events>(jsEvents);
                foreach (Events evnt in events)
                {
                    db.Events.Add(evnt);
                }
                db.SaveChanges();
                
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, events);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = events[0].eventid}));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT /Events/5
        //public HttpResponseMessage PutEvents(int id, Events events)
        //{
        //    if (ModelState.IsValid && id == events.eventid)
        //    {
        //        db.Entry(events).State = EntityState.Modified;

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

        // DELETE /Events/5
    //    public HttpResponseMessage DeleteEvents(int id)
    //    {
    //        Events events = db.Events.Find(id);
    //        if (events == null)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.NotFound);
    //        }

    //        db.Events.Remove(events);

    //        try
    //        {
    //            db.SaveChanges();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            return Request.CreateResponse(HttpStatusCode.NotFound);
    //        }

    //        return Request.CreateResponse(HttpStatusCode.OK, events);
    //    }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}