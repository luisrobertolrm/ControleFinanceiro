using ControleFinanceiro.Core.Entity;
using ControleFinanceiro.DataBase.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DataBase
{
    public class ControleFinanceiroContext: DbContext
    {
        public override int SaveChanges()
        {
            var entidadesCriadas = this.ChangeTracker
               .Entries()
               .Where(x => typeof(IAuditoria).IsAssignableFrom(x.Entity.GetType()) && (x.State == EntityState.Added || x.State == EntityState.Modified))
               .ToList();

            foreach (var item in entidadesCriadas)
            {
                (item.Entity as IAuditoria).DataAlteracao = DateTime.Now;
            }

            return base.SaveChanges();
        }

        public ControleFinanceiroContext() : base()
        {
        }

        public ControleFinanceiroContext(DbContextOptions options):base(options)
        {
        }


        public DbSet<TipoEntrada> TipoEntrada { get; set; }
        public DbSet<TipoSaida> TipoSaida { get; set; }
        public DbSet<Entrada> Entrada { get; set; }
        public DbSet<Saida> Saida { get; set; }
        public DbSet<Periodo> Periodo { get; set; }
        public DbSet<SaidaItem> SaidaItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=localhost; Database=ControleFinanceiro; Username=postgres; Password=123456789");
            optionsBuilder.UseSqlite("Data Source=C:\\Sqlite\\controleFinanceiro.db");

            optionsBuilder.LogTo(s => System.Diagnostics.Debug.WriteLine(s));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration( new EntradaConfiguration());
            modelBuilder.ApplyConfiguration(new SaidaConfiguration());
            modelBuilder.ApplyConfiguration(new PeriodoConfiguration());
            modelBuilder.ApplyConfiguration(new SaidaItemConfiguration());
            modelBuilder.ApplyConfiguration(new TipoEntradaConfiguration());
            modelBuilder.ApplyConfiguration(new TipoSaidaConfiguration());
        }

    }
}
