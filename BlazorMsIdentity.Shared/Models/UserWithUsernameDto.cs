using System.ComponentModel.DataAnnotations;

namespace BlazorMsIdentity.Shared.Models
{
    public class UserWithUsernameDto: UserBaseDto
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserPrincipalName { get; set; }
    }
}