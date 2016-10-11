using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventsAPI.Models
{
    public class Transactions
    {
         [Key]
        public int transactionid { get; set; }
        public string ticketname { get; set; }
        public string sessiondesc { get; set; }
        public string eventname { get; set; }        
        public int quantity { get; set; }
        public int price { get; set; }
        public string timestamp { get; set; }
        public string userid { get; set; }     
    }
}