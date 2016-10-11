using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventsAPI.Models
{
    public class Events
    {
        [Key]
        public int eventid {get;set;}
        public string eventname { get; set; }
        public string sessiondesc { get; set; }
        public string startdate { get; set; }
        public string starttime { get; set; }
        public int duration { get; set; }
        }
}