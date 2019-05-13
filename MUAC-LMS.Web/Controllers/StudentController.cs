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
using MUAC_LMS.Service.Models.Student;

namespace MUAC_LMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentCreateModel studentCreateModel)
        {
            try
            {
                await studentService.CreateStudentAsync(studentCreateModel);
                return Created("", null);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong while creating a new teacher, please try again" });
            }
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllStudent([FromQuery]PaginationBase paginationBase)
        {
            try
            {
                var result = await studentService.GetAllStudents(paginationBase);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong while creating a new teacher, please try again" });
            }
        }

        [HttpGet]
        [Route("GetStudentById/{studentId}")]
        public async Task<IActionResult> GetStudentById(string studentId)
        {
            try
            {
                var result = await studentService.GetStudentByIdAsync(studentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong while creating a new teacher, please try again" });
            }
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromBody] StudentUpdateModel studentUpdateModel)
        {
            try
            {
                await studentService.UpdateStudentAsync(studentUpdateModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Something went wrong while creating a new teacher, please try again" });
            }
        }

        [HttpDelete]
        [Route("DeleteStudent/{studentId}")]
        public async Task<IActionResult> DeleteStudent(string studentId)
        {
            try
            {
                await studentService.DeleteStudentAsync(studentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message});
            }
        }
    }
}