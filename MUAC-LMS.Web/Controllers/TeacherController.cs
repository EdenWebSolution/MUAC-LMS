using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MUAC_LMS.Common;
using MUAC_LMS.Service.Contracts;
using MUAC_LMS.Service.Models.Teacher;

namespace MUAC_LMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherCreateModel teacherCreateModel)
        {
            try
            {
                await teacherService.CreateTeacherAsync(teacherCreateModel);
                return Created("", null);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong while creating a new teacher, please try again" });
            }
            
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllTeachers([FromQuery] PaginationBase paginationBase)
        {
            try
            {
                var result = await teacherService.GetAllTeachers(paginationBase);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong while retrieving teachers, please try again" });
            }
        }

        [HttpGet]
        [Route("GetTeacherById/{teacherId}")]
        public IActionResult GetTeacherById(string teacherId)
        {
            try
            {
                var result = teacherService.GetTeacherById(teacherId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong while retrieving teacher, please try again" });
            }
        }

        [HttpPut]
        [Route("UpdateTeacher")]
        public async Task<IActionResult> UpdateTeacher([FromBody] TeacherUpdateModel teacherUpdateModel)
        {
            try
            {
                await teacherService.UpdateTeacherAsync(teacherUpdateModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong while upadting user, please try again" });
            }
        }
    }
}