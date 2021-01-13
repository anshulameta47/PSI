using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Com.Sapient.Models;

namespace Com.Sapient.Models
{
   
    public class User_SecurityQuestion_Mapping
        {
       
        public long UserAccountId { get; set; }
        public short SecurityQuestionId { get; set; }
        public string Answer { get; set; }
        public UserAccount UserAccount { get; set; }
        public SecurityQuestion SecurityQuestion { get; set; }

  
    }
}
