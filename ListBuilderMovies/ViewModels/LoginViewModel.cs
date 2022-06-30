using System.ComponentModel.DataAnnotations;

namespace ListBuilderMovies.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }


    }
}
