using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Models
{
    public class Contact
    {
        [Required]public int ContactId { get; set; }
        [Required][StringLength(50)] public String FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        [Required][EmailAddress] public string EmailId { get; set; }
        [Required][RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter valid 10-digit number")] public String MobileNo { get; set; }
        [Required]public String Designation { get; set; }

    }
}
