using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CS305_WebApp.Models
{
    public class RosterModel
    {
        public int ID { get; set; }
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
    }
}