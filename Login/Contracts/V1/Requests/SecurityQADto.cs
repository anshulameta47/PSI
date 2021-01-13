
using System.ComponentModel.DataAnnotations;

namespace Com.Sapient.Contracts.V1.Requests {
    public class SecurityQADto {
        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }
    }
}
