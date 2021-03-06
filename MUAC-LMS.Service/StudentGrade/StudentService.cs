﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MUAC_LMS.Common;
using MUAC_LMS.Data;
using MUAC_LMS.Domain.User;
using MUAC_LMS.Service.Contracts;
using MUAC_LMS.Service.Models.Account;
using MUAC_LMS.Service.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUAC_LMS.Service.Student
{
    public class StudentService : IStudentService
    {
        private readonly MUACContext mUACContext;
        private readonly ISecurityService securityService;
        private readonly UserManager<StoreUser> userManager;
        private readonly IMapper mapper;

        public StudentService(MUACContext mUACContext, ISecurityService securityService, UserManager<StoreUser> userManager, IMapper mapper)
        {
            this.mUACContext = mUACContext;
            this.securityService = securityService;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task CreateStudentAsync(StudentCreateModel studentCreateModel)
        {
            var userModel = await securityService.CreateNewUserAsync(new UserModel { Name = studentCreateModel.Name });
            var entity = new Domain.StudentGrade
            {
                StudentGrades = studentCreateModel.StudentGrades,
                StoreUserId = userModel.Id
            };

            await mUACContext.StudentGrades.AddAsync(entity);
            await mUACContext.SaveChangesAsync();
        }

        public async Task<PaginationModel<StudentModel>> GetAllStudents(PaginationBase paginationBase)
        {
            var query = mUACContext.StudentGrades.Include(i => i.StoreUser).Where(w => !w.IsDeleted && !w.StoreUser.IsDeleted);

            if (!string.IsNullOrEmpty(paginationBase.SearchQuery))
            {
                query = query.Where(w => EF.Functions.Like(w.StoreUser.Name, "%" + paginationBase.SearchQuery + "%"));
            }

            var totalRecords = await query.CountAsync();

            query = query.OrderBy(o => o.StoreUser.Name).Skip(paginationBase.Skip).Take(paginationBase.Take);

            var result = await query.AsNoTracking().ToListAsync();

            var model = mapper.Map<IEnumerable<StudentModel>>(result);

            var resultSet = new PaginationModel<StudentModel>
            {
                Details = model,
                TotalRecords = totalRecords
            };

            return resultSet;
        }

        public async Task<StudentModel> GetStudentByIdAsync(string studentId)
        {
            var entity = await mUACContext.StudentGrades.Include(i => i.StoreUser).FirstOrDefaultAsync(w => w.StoreUser.Id == studentId && !w.StoreUser.IsDeleted);
            var model = mapper.Map<StudentModel>(entity);
            return model;
        }

        public async Task UpdateStudentAsync(StudentUpdateModel studentUpdateModel)
        {
            try
            {
                var entity = await mUACContext.StudentGrades.Include(i => i.StoreUser).FirstOrDefaultAsync(w => w.StoreUser.Id == studentUpdateModel.StoreUserId && !w.StoreUser.IsDeleted);
                entity.StoreUser.Name = studentUpdateModel.Name;
                entity.StudentGrades = studentUpdateModel.StudentGrades;

                await mUACContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteStudentAsync(string studentId)
        {
            try
            {
                var userStore = new UserStore<StoreUser>(mUACContext);

                var entity = userManager.Users.FirstOrDefault(w => w.Id == studentId && !w.IsDeleted);
                entity.IsDeleted = true;
                await userStore.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
