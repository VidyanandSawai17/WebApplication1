using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models

{
    public class stud
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Qualification { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Mobile_No { get; set; }

        
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter the student ID")]
        public int Id { get; set; }
     

    }
}
