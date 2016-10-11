using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace EventsAPI.Controllers
{
    public class CallBackController : Controller
    {
        //
        // GET: /CallBack/
        public HttpResponseMessage GetCallback()
        {
            // Redirect after performing database activities like saving user
            //var response = Formatting.CreateResponse(HttpStatusCode.Moved);
            //response.Headers.Location = new Uri("http://www.abcmvc.com");
            //return response;
           
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

    }
}
