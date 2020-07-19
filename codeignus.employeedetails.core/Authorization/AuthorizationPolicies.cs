using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codeignus.employeedetails.core.Authorization
{
 
        public class AuthorizationPolicies
        {
            public const string ADMIN = "Admin";
            public const string USER = "User";

            public static AuthorizationPolicy UserPolicy()
            {
                return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                    .RequireRole(USER).Build();
            }

            public static AuthorizationPolicy AdminPolicy()
            {
                return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                    .RequireRole(ADMIN).Build();
            }
        }
    
}
