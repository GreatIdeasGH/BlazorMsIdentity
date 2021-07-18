using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorMsIdentity.Shared.Models
{
    public class UserDto
    {
        [Required(ErrorMessage = "Display Name is required")]
        public string DisplayName { get; set; }
        
        [Required(ErrorMessage = "Username is required")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        public string UserPrincipalName { get; set; }
        
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone]
        public string MobilePhone { get; set; }
        
        [Required(ErrorMessage = "User Password is required")] 
        public string Password { get; set; }
    }
}