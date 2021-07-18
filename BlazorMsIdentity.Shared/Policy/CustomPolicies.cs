using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BlazorMsIdentity.Shared.Policy
{
    public class CustomPolicies
    {
        public const string ApplicationAdministrator = "9b895d92-2cd3-44c7-9d02-a6ac2d5ea5c3";
        public const string UserAdministrator = "fe930be7-5e62-47db-91af-98c3a49a38b1";
        public const string DevOpsAdministrator = "e3973bdf-4987-49ae-837a-ba8e231c7286";
        
        public const string AdminPolicy = nameof(AdminPolicy);
        public const string DirectorPolicy = nameof(DirectorPolicy);
        public const string AccountantPolicy = nameof(AccountantPolicy);
        
        public static AuthorizationPolicy IsApplicationAdministrator()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                // .RequireRole(new List<string>{UserRoles.Association, Read})
                .RequireClaim("directoryRole", ApplicationAdministrator)
                // .AddRequirements(new PermissionRequirement(Permissions.Association.Read))
                .Build();
        }

        public static AuthorizationPolicy IsAccountant()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim(ClaimTypes.Role, Roles.Accountant)
                .Build();
        }
        
        public static AuthorizationPolicy IsSystemAdministrator()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim(ClaimTypes.Role, Roles.Admin)
                .Build();
        }
        
        public static AuthorizationPolicy IsDirector()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim(ClaimTypes.Role, Roles.Director)
                .Build();
        }

        public static AuthorizationPolicy IsDevOpsAdministrator()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("directoryRole", DevOpsAdministrator)
                .Build();
        }
    }
}
