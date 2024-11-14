using ControleFinanceiro.Core.Entity;
using ControleFinanceiro.DataBase.Configuracao;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DataBase
{
    public class ControleFinanceiroContext: DbContext
    {
        public ControleFinanceiroContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Entrada> Entrada { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
#if DEBUG
            modelBuilder.Entity<Entrada>().HasData(
            new Entrada
            {
                ID = 1,
                Data = DateTime.Now,
                Nome = "Salário CAST",
                Valor = 8000.01M
            }
        );
#endif

            modelBuilder.ApplyConfiguration( new EntradaConfiguration() );
        }

    }
}
