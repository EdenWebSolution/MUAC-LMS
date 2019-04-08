using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MUAC_LMS.Data;
using MUAC_LMS.Domain.User;
using MUAC_LMS.Service.Contracts;
using MUAC_LMS.Service.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUAC_LMS.Service.Security
{
    public class SecurityService : ISecurityService
    {
        private readonly SignInManager<StoreUser> signInManager;
        private readonly UserManager<StoreUser> userManager;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly MUACContext muacContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SecurityService(
            SignInManager<StoreUser> signInManager,
            UserManager<StoreUser> userManager,
            IConfiguration configuration,
            IMapper mapper,
            MUACContext muacContext,
            IHttpContextAccessor httpContextAccessor
            )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
            this.mapper = mapper;
            this.muacContext = muacContext;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserModel> CreateNewUserAsync(UserModel userModel)
        {
            try
            {
                var storeUser = mapper.Map<StoreUser>(userModel);
                var user = await userManager.CreateAsync(storeUser, userModel.Password);
                if (user.Succeeded)
                {
                    var result = mapper.Map<UserModel>(storeUser);
                    return result;
                }
                else
                {
                    return new UserModel();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public Task DeleteUserAsync(string id)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LoginModel> LoginAsync(LoginModel loginViewModel)
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordAsync(UserUpdateModel userUpdateModel)
        {
            throw new NotImplementedException();
        }
    }
}
