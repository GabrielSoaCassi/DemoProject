using Microsoft.AspNetCore.Identity;
using ProjetoDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDemo.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void SeedRoles(string roleName)
        {
            if (!_roleManager.RoleExistsAsync(roleName).Result)
            {
                var role = new IdentityRole();
                role.Name = roleName;
                role.NormalizedName = roleName.ToUpperInvariant();
                var result = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers(string email,string password,string role = "User")
        {
           if(_userManager.FindByEmailAsync(email).Result == null)
            {
                var user = new ApplicationUser();
                user.Email = email;
                user.NormalizedEmail = email.ToUpperInvariant();
                user.UserName = email;
                user.NormalizedUserName = email.ToUpperInvariant();
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();
                
                var result = _userManager.CreateAsync(user,password).Result;
                if (result.Succeeded) 
                {
                    _userManager.AddToRoleAsync(user, role).Wait();
                }
            }
        }
    }
}
