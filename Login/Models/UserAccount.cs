using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Com.Sapient.Models
{
	public class UserAccount
	{
        [Key]
        public long Id { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public char Gender { get; set; }
        public long Phone { get; set; }
        public short IsdCode { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<User_Role_Mapping> UserRoleMapping { get; set; } = new List<User_Role_Mapping>();
        public List<User_SecurityQuestion_Mapping> UserSecurityQuestionMapping { get; set; } = new List<User_SecurityQuestion_Mapping>();
        public string FullName()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
	
}