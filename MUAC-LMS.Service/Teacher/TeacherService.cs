using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MUAC_LMS.Common;
using MUAC_LMS.Data;
using MUAC_LMS.Domain.User;
using MUAC_LMS.Service.Contracts;
using MUAC_LMS.Service.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUAC_LMS.Service.Teacher
{
    public class TeacherService : ITeacherService
    {
        private readonly MUACContext mUACContext;
        private readonly ISecurityService securityService;
        private readonly UserManager<StoreUser> userManager;
        private readonly IMapper mapper;

        public TeacherService(MUACContext mUACContext, ISecurityService securityService, UserManager<StoreUser> userManager, IMapper mapper)
        {
            this.mUACContext = mUACContext;
            this.securityService = securityService;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task CreateTeacherAsync(TeacherCreateModel teacherCreateModel)
        {
            var userModel = await securityService.CreateNewUserAsync(new Models.Account.UserModel { UserName = teacherCreateModel.Name, Name = teacherCreateModel.Name, IsTeacher = true });
            await mUACContext.SaveChangesAsync();
        }

        public async Task<PaginationModel<TeacherModel>> GetAllTeachers(PaginationBase paginationBase)
        {
            var query = userManager.Users.Where(w => w.IsTeacher && !w.IsDeleted);

            if (!string.IsNullOrEmpty(paginationBase.SearchQuery))
            {
                query = query.Where(w => EF.Functions.Like(w.Name, "%" + paginationBase.SearchQuery + "%"));
            }

            query = query.OrderBy(o => o.Name).Skip(paginationBase.Skip).Take(paginationBase.Take);

            var result = await query.AsNoTracking().ToListAsync();
            var totalRecords = await query.CountAsync();

            var model = mapper.Map<IEnumerable<TeacherModel>>(result);

            var resultSet = new PaginationModel<TeacherModel>
            {
                Details = model,
                TotalRecords = totalRecords
            };

            return resultSet;
        }

        public TeacherModel GetTeacherById(string teacherId)
        {
            var result = userManager.Users.FirstOrDefault(w => w.IsTeacher && !w.IsDeleted && w.Id == teacherId);
            var model = mapper.Map<TeacherModel>(result);
            return model;
        }

        public void UpdateTeacherAsync(TeacherUpdateModel teacherUpdateModel)
        {
            var userStore = new UserStore<StoreUser>(mUACContext);

            var teacher = userManager.Users.FirstOrDefault(w => w.Id == teacherUpdateModel.Id && !w.IsDeleted);
            teacher.Name = teacherUpdateModel.Name;
            teacher.UserName = teacherUpdateModel.Name;
            userStore.UpdateAsync(teacher);
        }
    }
}
