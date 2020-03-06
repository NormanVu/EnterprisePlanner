using Microsoft.AspNetCore.Identity;

namespace Authentication.Models.Entities
{
    /// <summary>
    /// Extended application user with properties to identity user
    /// </summary>
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
