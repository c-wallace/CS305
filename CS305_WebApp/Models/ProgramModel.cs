using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CS305_WebApp.Models
{
    public class ProgramModel
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string address { get; set; }

        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        [Display(Name = "Phone Number")]
        public string number { get; set; }

        public virtual ICollection<Keywords> keywords { get; set; }
    }
}