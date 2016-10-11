using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventsAPI.Models
{
    public class Tickets
    {
        [Key]
        public int ticketid { get; set; }
        public string ticketname { get; set; }
        public string eventname { get; set; }
        public string sessiondesc { get; set; }
        public string availability { get; set; }
        public int minqty { get; set; }
        public int maxqty { get; set; }
        public int status { get; set; }
        public int price { get; set; }
    }
}