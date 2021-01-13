using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Sapient.Models
{
    public class Address
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int PinCode { get; set; }


    }
}
