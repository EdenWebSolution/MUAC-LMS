using MUAC_LMS.Service.Models;
using MUAC_LMS.Service.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUAC_LMS.Service.Contracts
{
    public interface ISecurityService
    {
        Task<LoginModel> LoginAsync(LoginModel loginViewModel);
        Task<UserModel> CreateNewUserAsync(UserModel userModel);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task DeleteUserAsync(string id);
        Task ResetPasswordAsync(UserUpdateModel userUpdateModel);
    }
}
