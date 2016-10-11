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
    public class TransactionsController : ApiController
    {
        private EventsDBContext db = new EventsDBContext();

        // GET /Transactions
        public string GetTransactions()
        {
            return (new JavaScriptSerializer().Serialize(db.Transactions.AsEnumerable()));
        }


        // GET /Transactions/5
        public string GetTransactions(int id)
        {
            Transactions transactions = db.Transactions.Find(id);
            if (transactions == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Helper.AsJson(transactions);
        }

        // POST /Transactions
        public HttpResponseMessage PostTransactions([FromBody] string jsTransactions)
        {
            if (ModelState.IsValid)
            {
                List<Transactions> transactions = Helper.AsObjectList<Transactions>(jsTransactions);
                foreach (Transactions transaction in transactions)
                {
                    db.Transactions.Add(transaction);
                }
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, transactions);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = transactions[0].transactionid }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        //// PUT /Transactions/5
        //public HttpResponseMessage PutTransactions(int id, Transactions transactions)
        //{
        //    if (ModelState.IsValid && id == transactions.transactionid)
        //    {
        //        db.Entry(transactions).State = EntityState.Modified;

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

        //// DELETE /Transactions/5
        //public HttpResponseMessage DeleteTransactions(int id)
        //{
        //    Transactions transactions = db.Transactions.Find(id);
        //    if (transactions == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    db.Transactions.Remove(transactions);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, transactions);
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}