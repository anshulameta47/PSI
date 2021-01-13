using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Sapient.Contracts.V1.Requests
{
    public class OtpVerificationRequest
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }
}
