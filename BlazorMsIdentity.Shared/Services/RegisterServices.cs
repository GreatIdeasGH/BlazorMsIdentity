using BlazorMsIdentity.Shared.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorMsIdentity.Shared.Services
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterPolicies(this IServiceCollection services)
        {

            // Policies
           services.AddAuthorizationCore(options =>
            {
                options.AddPolicy(PolicyNames.RequireAdmin, policy =>
                {
                    policy.AddRequirements(new ApiAuthorizationHandler());
                    policy.RequireAuthenticatedUser();
                });

                options.AddPolicy(CustomPolicies.ApplicationAdministrator, CustomPolicies.IsApplicationAdministrator());
                options.AddPolicy(CustomPolicies.AdminPolicy, CustomPolicies.IsSystemAdministrator());
                options.AddPolicy(CustomPolicies.DevOpsAdministrator, CustomPolicies.IsDevOpsAdministrator());
                options.AddPolicy(CustomPolicies.DirectorPolicy, CustomPolicies.IsDirector());
                options.AddPolicy(CustomPolicies.AccountantPolicy, CustomPolicies.IsAccountant());

                // options.FallbackPolicy = options.DefaultPolicy;
            });
           
           // By default, all incoming requests will be authorized according to the default policy
           services.AddScoped<IAuthorizationHandler, ApiAuthorizationHandler>();

           return services;
        }
    }
}