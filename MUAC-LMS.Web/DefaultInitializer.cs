using Microsoft.AspNetCore.Identity;
using MUAC_LMS.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUAC_LMS.Web
{
    public class DefaultInitializer
    {
        public static void SeedUsers(UserManager<StoreUser> userManager)
        {
            if (userManager.FindByNameAsync("muacadmin").Result == null)
            {
                var defaultUser = new StoreUser
                {
                    UserName = "muacadmin",
                    IsTeacher = true,
                    Name = "muacadmin",
                };
                _ = userManager.CreateAsync(defaultUser, "Admin@123").Result;
            }
        }
    }
}
