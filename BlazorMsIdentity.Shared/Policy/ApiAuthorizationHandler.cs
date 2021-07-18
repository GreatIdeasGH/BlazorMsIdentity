using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BlazorMsIdentity.Shared.Policy
{
    // public class ApiAuthorizationHandler : IAuthorizationRequirement
    // {
    //     public string Permission { get; private set; }
    //
    //     public ApiAuthorizationHandler(string permission)
    //     {
    //         Permission = permission;
    //     }
    // }

    public class ApiAuthorizationHandler : AuthorizationHandler<ApiAuthorizationHandler>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiAuthorizationHandler requirement)
        {
            if (context.User.HasClaim(ClaimTypes.Role, Roles.Admin) ||
                context.User.HasClaim(ClaimTypes.Role, Roles.ProjectManager))
            {
                context.Succeed(requirement);
            }
            return Task.FromResult(0);
        }
    }
}
