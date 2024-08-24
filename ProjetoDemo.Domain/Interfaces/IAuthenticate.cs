using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDemo.Domain.Interfaces
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<bool> RegisterAsync(string email, string password);
        Task Logout();
    }
}
