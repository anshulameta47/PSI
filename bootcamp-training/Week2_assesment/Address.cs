using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_Week2
{
    class Address
    {
        private int housenumber;
        private string street;
        private string city;
        private int pin;
        public void setHousenumber(int housenumber)
        {
            this.housenumber = housenumber;
        }
        public void setStreet(string street)
        {
            this.street = street;
        }
        public void setCity(string city)
        {
            this.city = city;
        }
        public void setPin(int pin)
        {
            this.pin = pin;
        }

    }
}
