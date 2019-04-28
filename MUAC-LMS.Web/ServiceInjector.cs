using Microsoft.Extensions.DependencyInjection;
using MUAC_LMS.Data;
using MUAC_LMS.Service.Contracts;
using MUAC_LMS.Service.Security;
using MUAC_LMS.Service.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUAC_LMS.Web
{
    public class ServiceInjector
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<MUACContext, MUACContext>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
