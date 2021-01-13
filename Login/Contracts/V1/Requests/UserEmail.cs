using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Sapient.Contracts.V1.Requests
{
    public class UserEmail
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
