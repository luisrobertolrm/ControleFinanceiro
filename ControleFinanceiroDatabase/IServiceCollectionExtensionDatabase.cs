using ControleFinanceiro.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Database
{
    public static class IServiceCollectionExtensionDatabase
    {
        public static void ConfigurarDatabase(this IServiceCollection services)
        {
            services.AddDbContext<ControleFinanceiroContext>(opt => opt.UseInMemoryDatabase("ControleFinanceiro"));
        }
    }
}
