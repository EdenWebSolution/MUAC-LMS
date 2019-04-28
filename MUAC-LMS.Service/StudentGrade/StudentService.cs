﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MUAC_LMS.Common;
using MUAC_LMS.Data;
using MUAC_LMS.Service.Contracts;
using MUAC_LMS.Service.Models.Account;
using MUAC_LMS.Service.Models.Student;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUAC_LMS.Service.Student
{
    public class StudentService : IStudentService
    {
        private readonly MUACContext mUACContext;
        private readonly ISecurityService securityService;
        private readonly IMapper mapper;

        public StudentService(MUACContext mUACContext, ISecurityService securityService, IMapper mapper)
        {
            this.mUACContext = mUACContext;
            this.securityService = securityService;
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

            query = query.OrderBy(o => o.StoreUser.Name).Skip(paginationBase.Skip).Take(paginationBase.Take);

            var result = await query.AsNoTracking().ToListAsync();
            var totalRecords = await query.CountAsync();

            var model = mapper.Map<IEnumerable<StudentModel>>(result);

            var resultSet = new PaginationModel<StudentModel>
            {
                Details = model,
                TotalRecords = totalRecords
            };

            return resultSet;
        }
    }
}