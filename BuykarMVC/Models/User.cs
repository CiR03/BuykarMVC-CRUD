using System.ComponentModel.DataAnnotations;

namespace BuykarMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "* field required")]
        public string? Name { get; set; }
        [Required (ErrorMessage = "* field required")]
        public string? Email { get; set; }
        [Required (ErrorMessage = "* field required")]
        public string? Password { get; set; }
        [Required (ErrorMessage = "* field required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password doesn't, match,try again !")]
        public string? ConfirmPassword { get; set; }

        [Required (ErrorMessage = "* field required")]
        public long Phone_Number {get;set;}
    }
}
