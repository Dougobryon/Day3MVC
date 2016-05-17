using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day3MVC.Models
{
    public class States
    {

        [Key]
        public int StateId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

    }
}