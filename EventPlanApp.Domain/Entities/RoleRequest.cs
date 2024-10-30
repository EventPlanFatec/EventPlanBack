using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class RoleRequest
    {
        public string RoleName { get; set; }
        public List<string> Permissions { get; set; }
    }
}
