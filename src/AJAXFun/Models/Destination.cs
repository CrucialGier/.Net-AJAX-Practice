using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AJAXFun.Models
{
    [Table("Destinations")]
    public class Destination
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


        public Destination()
        {
        }

        public Destination(string city, string country, int id = 0)
        {
            City = city;
            Country = country;
            Id = id;
        }
    }
}