using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanApp.Domain.Entities
{
    public class Role
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Permissions { get; private set; }

        public Role(string name, string permissions)
        {
            Id = Guid.NewGuid();
            Name = name;
            Permissions = permissions;
        }

        // Você pode criar métodos para manipular as permissões se necessário, por exemplo:
        public bool HasPermission(string permission)
        {
            return Permissions.Contains(permission);
        }
    }

}
