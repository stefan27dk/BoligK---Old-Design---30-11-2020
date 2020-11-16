using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BoligKø.Web.Areas.Authorization
{
    public class CustomAuthorizationHandler:IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();
            foreach (var requirement in pendingRequirements)
            {
                if (requirement is AdminPermission)
                {
                    if(IsAdmin(context.User,context.Resource))
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            return Task.CompletedTask;
        }

        private bool IsAdmin(ClaimsPrincipal user, object resource)
        {
            if (user.HasClaim("Auth","Admin"))
                return true;
            return false;
        }
    }

    internal class AdminPermission : IAuthorizationRequirement
    {
    }
}
