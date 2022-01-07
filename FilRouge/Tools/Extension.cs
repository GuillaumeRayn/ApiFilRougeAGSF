using FilRouge.Interfaces;
using FilRouge.Model;
using FilRouge.Repositories;
using FilRouge.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilRouge.Tools
{
    public static class Extension
    {
        public static void AddOurServices(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddScoped<IRepository<Answer>, AnswerRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddScoped<IRepository<Question>, QuestionRepository>();
            services.AddScoped<IRepository<Tag>, TagRepository>();
            services.AddScoped<LoginService>();
        }
    }
}
