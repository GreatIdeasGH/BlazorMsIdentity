using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Logging;

namespace BlazorMsIdentity.Shared.Policy
{
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; private set; }

        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }

    public class PermissionAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, WeatherForecast>
    {
        static readonly Dictionary<OperationAuthorizationRequirement, Func<List<UserPermissionType>, bool>> ValidateUserPermissions
            = new Dictionary<OperationAuthorizationRequirement, Func<List<UserPermissionType>, bool>>

            {
                { Operations.Create, x => x.Contains(UserPermissionType.Creator) },

                { Operations.Read, x => x.Contains(UserPermissionType.Creator) ||
                                        x.Contains(UserPermissionType.Reader) ||
                                        x.Contains(UserPermissionType.Contributor) ||
                                        x.Contains(UserPermissionType.Owner) },

                { Operations.Update, x => x.Contains(UserPermissionType.Contributor) ||
                                          x.Contains(UserPermissionType.Owner) },

                { Operations.Delete, x => x.Contains(UserPermissionType.Owner) },

                { Operations.Publish, x => x.Contains(UserPermissionType.Owner) },

                { Operations.UnPublish, x => x.Contains(UserPermissionType.Owner) }
            };

        private enum UserPermissionType { Admin, Creator, Reader, Contributor, Owner };
        private readonly ILogger _logger;

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement,
            WeatherForecast resource)
        {
            // if the survey is in the same tenant
            //      Add SURVEYADMIN/SURVEYCREATER/SURVEYREADER to permission set
            // else if survey is in differnt tenant
            //      Add CONTRIBUTOR to permission set if user is contributor on survey
            //
            // if user is owner of the survey
            //      Add OWNER to the permission set
            // var permissions = new List<UserPermissionType>();
            // int surveyTenantId = context.User.GetSurveyTenantIdValue();
            // int userId = context.User.GetSurveyUserIdValue();
            // string user = context.User.GetUserName();
            //
            // if (resource.TenantId == surveyTenantId)
            // {
            //     // Admin can do anything, as long as the resource belongs to the admin's tenant.
            //     if (context.User.HasClaim(ClaimTypes.Role, Roles.SurveyAdmin))
            //     {
            //         context.Succeed(requirement);
            //         return Task.FromResult(0);
            //     }
            //
            //     if (context.User.HasClaim(ClaimTypes.Role, Roles.SurveyCreator))
            //     {
            //         permissions.Add(UserPermissionType.Creator);
            //     }
            //     else
            //     {
            //         permissions.Add(UserPermissionType.Reader);
            //     }
            //
            //     if (resource.OwnerId == userId)
            //     {
            //         permissions.Add(UserPermissionType.Owner);
            //     }
            // }
            // if (resource.Contributors != null && resource.Contributors.Any(x => x.UserId == userId))
            // {
            //     permissions.Add(UserPermissionType.Contributor);
            // }
            //
            // if (ValidateUserPermissions[requirement](permissions))
            // {
            //     _logger.ValidatePermissionsSucceeded(user, context.User.GetTenantIdValue(), requirement.Name, permissions.Select(p => p.ToString()));
            //     context.Succeed(requirement);
            // }

            return Task.FromResult(0);
        }
    }
}
