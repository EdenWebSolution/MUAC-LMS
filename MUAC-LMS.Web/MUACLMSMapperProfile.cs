using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MUAC_LMS.Domain;
using MUAC_LMS.Domain.User;
using MUAC_LMS.Service.Models.Account;
using MUAC_LMS.Service.Models.Student;
using MUAC_LMS.Service.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUAC_LMS.Web
{
    public class MUACLMSMapperProfile : Profile
    {
        public MUACLMSMapperProfile()
        {
            CreateMap<StoreUser, UserModel> ().ReverseMap();
            CreateMap<IdentityResult, UserModel>().ReverseMap();
            CreateMap<StudentGrade, StudentModel>().ForMember(dest => dest.Name, src => src.MapFrom(dest => dest.StoreUser.Name));
            CreateMap<StoreUser, TeacherModel>().ReverseMap();
        }
    }
}
