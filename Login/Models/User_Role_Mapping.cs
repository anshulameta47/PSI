using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Com.Sapient.Models;

namespace Com.Sapient.Models
{
    public class User_Role_Mapping
    {
        [Key]
        public long UserAccountId { get; set; }
        public short RoleId { get; set; }
        public Role Role { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
