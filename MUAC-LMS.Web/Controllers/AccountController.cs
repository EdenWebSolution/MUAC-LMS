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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AccountController : ControllerBase
    {
        private readonly ISecurityService securityService;

        public AccountController(ISecurityService securityService)
        {
            this.securityService = securityService;
        }

        [Route("Authenticate")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await securityService.LoginAsync(loginModel);
                    if (result.Token != null)
                    {
                        return Created("", result);
                    }
                    else
                    {
                        return Unauthorized();

                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong!");
            }
        }

        [Route("NewUser")]
        [HttpPost]
        public async Task<IActionResult> CreateNewUserAsync([FromBody]UserModel userModel)
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

        [Route("AllUsers")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            try
            {
                var result = await securityService.GetAllUsersAsync();
                return Ok(result); ;
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong while getting user list" });
            }
        }

        [Route("DeleteUser")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync([FromQuery] string id)
        {
            try
            {
                await securityService.DeleteUserAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong while deleting the user, try again" });
            }
        }

        [Route("ResetPassword")]
        [HttpPut]
        public async Task<IActionResult> ResetPassword([FromBody] UserUpdateModel userUpdateModel)
        {
            try
            {
                await securityService.ResetPasswordAsync(userUpdateModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong while updating the password, try again" });
            }
        }


    }
}