using ControleFinanceiro.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DataBase.Configuracao
{
    public class PeriodoConfiguration : IEntityTypeConfiguration<Periodo>
    {
        public void Configure(EntityTypeBuilder<Periodo> builder)
        {
            builder.ToTable("Periodo");
            builder.HasKey( s => new { s.Ano, s.Mes });

            builder.HasMany(s => s.Entradas).WithOne(s => s.Periodo).HasForeignKey(s => new { s.Ano, s.Mes});
            builder.HasMany(s => s.Saidas).WithOne(s => s.Periodo).HasForeignKey(s => new { s.Ano, s.Mes });
        }

    }
}
