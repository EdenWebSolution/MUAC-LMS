using MUAC_LMS.Common;
using MUAC_LMS.Service.Models.Student;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUAC_LMS.Service.Contracts
{
    public interface IStudentService
    {
        Task CreateStudentAsync(StudentCreateModel studentCreateModel);
        Task<PaginationModel<StudentModel>> GetAllStudents(PaginationBase paginationBase);
        Task<StudentModel> GetStudentById(string studentId);
    }
}
