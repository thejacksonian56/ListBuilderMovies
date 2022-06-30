using Microsoft.AspNetCore.Identity;

namespace ListBuilderMovies.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
    }
}
