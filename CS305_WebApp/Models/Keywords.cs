using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS305_WebApp.Models
{
    public class Keywords
    {
        public int ID { get; set; }

        public string keyword { get; set; }

        public virtual ICollection<ProgramModel> programs { get; set; }

    }
   
}