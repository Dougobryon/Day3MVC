using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day3MVC.Models
{
    public class Sales
    {

        [Key]
        public int SalesID { get; set; }

        //Foreign key for Customer Models
        public int UserId { get; set; }
        public Customers Customers { get; set; }

        //Foreign key for Property Models

        public int PropertyId { get; set; }
        public PropertyModels Property { get; set; }


        public decimal SalesPrice { get; set; }
        public DateTime SalesDate { get; set; }

    }
}