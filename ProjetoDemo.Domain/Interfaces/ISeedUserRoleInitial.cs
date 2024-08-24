using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDemo.Domain.Interfaces
{
    public interface ISeedUserRoleInitial
    {
        void SeedUsers(string email, string password, string role);
        void SeedRoles(string roleName);
    }
}
