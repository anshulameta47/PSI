
namespace Com.Sapient.Contracts.V1.Requests {
    public class CreateUserRequest {
        //
        // [Required]
        // [EmailAddress]
        public string Email { get; set; }
        // [Required]
        // [MinLength(8)]
        // [MaxLength(20)]
        // [Password]
        public string Password { get; set; }
        // [Required]
        // public string FirstName { get; set; }
        // [Required]
        // public string LastName { get; set; }
        // public char Gender { get; set; } // Use Enum 
        // public long Phone { get; set; }
        // public int CountryCode { get; set; }
        // public List<AddressDto> Address { get; set; }
        // public List<SecurityQADto> SecurityQA { get; set; }
    }

    //public enum Gender {
    //    Male,
    //    Female,
    //}
}
