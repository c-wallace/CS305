using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CS305_WebApp.Models
{
    public class RosterModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Description")]
        public string description { get; set; }
    }
}