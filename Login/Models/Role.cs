using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Com.Sapient.Models
{
    public class Role
    {
        [Key]
        public short Id { get; set; }
        public string Name { get; set; }
        public IList<User_Role_Mapping> User_Role_Mapping { get; set; } = new List<User_Role_Mapping>();

    }
}
