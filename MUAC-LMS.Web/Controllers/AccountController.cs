using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MUAC_LMS.Service.Contracts;
using MUAC_LMS.Service.Models.Account;

namespace MUAC_LMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ControllerBase
    {
        private readonly ISecurityService securityService;

        public AccountController(ISecurityService securityService)
        {
            this.securityService = securityService;
        }

        [Route("NewUser")]
        [HttpPost]
        public async Task<IActionResult> CreateStaffAsync([FromBody]UserModel userModel)
        {
            try
            {
                var result = await securityService.CreateNewUserAsync(userModel);

                if (result.UserName == null)
                {
                    return Conflict(new { message = "Username is already in use" });
                }
                else
                {
                    return Created(string.Empty, result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}