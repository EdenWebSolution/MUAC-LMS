using MUAC_LMS.Common;
using MUAC_LMS.Service.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUAC_LMS.Service.Contracts
{
    public interface ITeacherService
    {
        Task CreateTeacherAsync(TeacherCreateModel teacherCreateModel);
        Task<PaginationModel<TeacherModel>> GetAllTeachers(PaginationBase paginationBase);
        TeacherModel GetTeacherById(string teacherId);
        Task UpdateTeacherAsync(TeacherUpdateModel teacherUpdateModel);
    }
}
