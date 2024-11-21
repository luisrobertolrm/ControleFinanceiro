using ControleFinanceiro.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Negocio
{
    public static class IServiceCollectionExtensionNegocio
    {
        public static void ConfigurarDatabase(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetService<IConfiguration>();

            //services.AddDbContext<ControleFinanceiroContext>(opt => opt.UseInMemoryDatabase("ControleFinanceiro"));
            services.AddDbContext<ControleFinanceiroContext>(opt => opt.UseSqlite(configuration.GetConnectionString("controleFinanceiro")));

            services.AddAutoMapper(Assembly.GetAssembly(typeof(IServiceCollectionExtensionNegocio)));
        }
    }
}
