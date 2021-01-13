using Com.Sapient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Sapient.Utility
{
    public class GenerateActivationToken
    {
        //Generates Token for authentication
        public string GenerateToken(long userId)
        {
            long timeStamp= DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            string token = new Guid().ToString() + timeStamp.ToString();
            return token;
        }
    }
}
