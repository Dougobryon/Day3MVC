using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day3MVC.Models
{
    public class Cities
    {

        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string ImgSrc { get; set; }
        public string Description { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }

        //Foreign Key

        public string ZipCodeId { get; set; }
        public Zips Zip { get; set; }
        public string StateId { get; set; }
        public States State { get; set; }

    }
}