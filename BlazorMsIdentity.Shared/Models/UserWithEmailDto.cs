using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorMsIdentity.Shared.Models
{
    public class UserWithEmailDto: UserBaseDto
    {
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        public string UserPrincipalName { get; set; }
        
    }
}