using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Sapient.Contracts.V1.Requests {
    public class AddressDto {
        [Required]
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        [Required]
        public string City { get; set; }
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int Pin { get; set; }
    }
}
