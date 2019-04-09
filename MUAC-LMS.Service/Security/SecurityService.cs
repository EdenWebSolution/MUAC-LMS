using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MUAC_LMS.Data;
using MUAC_LMS.Domain.User;
using MUAC_LMS.Service.Contracts;
using MUAC_LMS.Service.Models.Account;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        
        public async Task DeleteUserAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            user.IsDeleted = true;
            await userManager.UpdateAsync(user);
        }
        
        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            var allUsers = userManager.Users.Where(w => !w.IsDeleted)
                .Select(s => new UserModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    UserName = s.UserName,
                    IsTeacher = s.IsTeacher
                }).AsNoTracking().AsQueryable();

            //var allUsers = await userManager.Users.Where(w => !w.IsDeleted).ToListAsync();
            //var mappedUsers = mapper.Map<List<UserModel>>(allUsers);
            //return mappedUsers;
            return await allUsers.ToListAsync();
        }

        public async Task<LoginModel> LoginAsync(LoginModel loginViewModel)
        {
            var user = await userManager.FindByNameAsync(loginViewModel.UserName);
            if (user != null && !user.IsDeleted)
            {
                var result = await signInManager.CheckPasswordSignInAsync(user, loginViewModel.Password, false);

                if (result.Succeeded)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]));
                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName,user.UserName),
                        new Claim("isTeacher",user.IsTeacher.ToString()),
                    };

                    var token = new JwtSecurityToken(
                        configuration["Tokens:Issuer"],
                        configuration["Tokens:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddDays(1),
                        signingCredentials: credentials
                        );

                    var generatedToken = new LoginModel
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        TokenExpiration = token.ValidTo,
                        IsTeacher = user.IsTeacher
                    };
                    
                    return generatedToken;
                }
            }
            return new LoginModel();
        }

        public async Task ResetPasswordAsync(UserUpdateModel userUpdateModel)
        {
            try
            {
                var userStore = new UserStore<StoreUser>(muacContext);

                var user = await userManager.FindByIdAsync(userUpdateModel.Id);

                var hashedNewPassword = userManager.PasswordHasher.HashPassword(user, userUpdateModel.Password);

                await userStore.SetPasswordHashAsync(user, hashedNewPassword);
                await userStore.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
