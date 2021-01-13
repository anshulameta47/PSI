using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Sapient.Models
{
    public class SecurityQuestion
    {
        [Key]
        public short Id { get; set; }
        public string Question { get; set; }
        public IList<User_SecurityQuestion_Mapping> User_SecurityQuestion_Mapping { get; set; } = new List<User_SecurityQuestion_Mapping>();

    }
}
