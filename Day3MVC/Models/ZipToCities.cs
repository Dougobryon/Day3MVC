using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day3MVC.Models
{
    public class ZipToCities
    {

        [Key]
        public int ZToC { get; set; }

        //Foreign key for CityId
        public int CityId { get; set; }
        public Cities City { get; set; }

        public int ZipId { get; set; }
        public Zips Zip { get; set; }

    }
}