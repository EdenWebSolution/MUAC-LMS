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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentCreateModel studentGradeCreateModel)
        {
            await studentService.CreateStudentAsync(studentGradeCreateModel);
            return Created("", null);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllStudent([FromQuery]PaginationBase paginationBase)
        {
            var result = await studentService.GetAllStudents(paginationBase);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetStudentById/{studentId:guid}")]
        public IActionResult GetStudentById(Guid studentId)
        {
            return Ok();
        }
    }
}