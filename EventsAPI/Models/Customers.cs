using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventsAPI.Models
{    
    public class Customers
    {
        [Key]
        public string userid { get; set; }
        public string password { get; set; }        
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
          
    }
}