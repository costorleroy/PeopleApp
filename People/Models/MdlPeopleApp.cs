using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace People.Models
{
    public class MdlPeopleApp
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Floor")]
        [DataType(DataType.Text)]
        public string? selFloor { get; set; }

        [Required]
        [MaxLength(150)]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Enter valid name")]
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public string? FirstName { get; set; }


        [Required]
        [MaxLength(150)]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Eenter valid name.")]
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public string? LastName { get; set; }

        [MaxLength(10)]
        [Display(Name = "Genter")]
        [DataType(DataType.Text)]
        public string? Genter { get; set; }

        [MaxLength(150)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")]
        public string? Email { get; set; }

        [MaxLength(15)]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}?", ErrorMessage = "Enter valid Phone number: (123) 123-1214")]
        public string? Phone { get; set; }

        [MaxLength(10)]
        [Display(Name = "Street No.")]
        [DataType(DataType.Text)]
        public string? StNumber { get; set; }

        [MaxLength(50)]
        [Display(Name = "Street Name")]
        [DataType(DataType.Text)]
        public string? StName { get; set; }

        [MaxLength(50)]
        [Display(Name = "City")]
        [DataType(DataType.Text)]
        public string? StCity { get; set; }

        [MaxLength(50)]
        [Display(Name = "State")]
        [DataType(DataType.Text)]
        public string? StState { get; set; }

        [MaxLength(5)]
        [Display(Name = "Zip")]
        [DataType(DataType.PostalCode)]  //[DataType(DataType.Text)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Enter numeric values only")]
        public string? StZip { get; set; }

        [MaxLength(150)]
        [Display(Name = "Full Address")]
        [DataType(DataType.Text)]
        public string? AddressLine { get; set; }

        [MaxLength(150)]
        [Display(Name = "Job Title")]
        [DataType(DataType.Text)]
        public string? JobTitle { get; set; }

        [MaxLength(50)]
        [Display(Name = "Race")]
        [DataType(DataType.Text)]
        public string? Race { get; set; }

        [Display(Name = "Dated")]
        [DataType(DataType.Date)]
        public DateTime Dated { get; set; }

        
        [Display(Name = "Avatar")]
        [DataType(DataType.Text)]
        public string? Avatar { get; set; }

        //[Display(Name = "Comments")]
        //[DataType(DataType.MultilineText)]
        //public string? Comment { get; set; }

        [Display(Name = "serIn")]
        [DataType(DataType.Text)]
        public string? UserIn { get; set; }

        [Display(Name = "Company Name")]
        [DataType(DataType.Text)]
        public string? CompanyName { get; set; }

        [Display(Name = "Record")]
        [DataType(DataType.Text)]
        public string? RecCount { get; set; }

        [Display(Name = "User Id")]
        [DataType(DataType.Text)]
        public int UserId{ get; set; }

        [NotMapped]
        [Display(Name = "Choose Photo")]
        [Required]
        public IFormFile? CoverPhoto { get; set; }
    }
}
