using ControleFinanceiro.Core.Entity;
using ControleFinanceiro.Database;
using ControleFinanceiro.Negocio.Interface;
using ControleFinanceiro.Negocio.Servicos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Negocio
{
    public static class IServiceCollectionExtensionDatabase
    {
        public static void Configurar(this IServiceCollection services)
        {
            services.ConfigurarDatabase();
            services.AddScoped<IEntradaService, EntradaService>();
            services.AddAutoMapper(Assembly.GetAssembly(typeof(Entrada)));
        }
    }
}
