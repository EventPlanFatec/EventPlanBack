using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Application.Interfaces
{
    public interface IPermissionService
    {
        Task<bool> CheckUserPermissionAsync(ClaimsPrincipal user, string permission);
    }
}
