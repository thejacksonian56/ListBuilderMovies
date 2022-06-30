using System.ComponentModel.DataAnnotations;

namespace ListBuilderMovies.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {

        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }



    }
}
