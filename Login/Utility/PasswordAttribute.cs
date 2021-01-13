using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Com.Sapient.Utility {
    public class PasswordAttribute : ValidationAttribute{

        private const string RegexPattern = @"(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$%^&*_-])";
        private const string OurErrorMessage = "Password must contain atleast 1 uppercase character, 1 lowercase character, 1 special character, 1 digit and  8-12 characters long";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
            var password = value.ToString();

            return Regex.IsMatch(password ?? string.Empty, RegexPattern) ? ValidationResult.Success : new ValidationResult(OurErrorMessage);
        }
    }
}