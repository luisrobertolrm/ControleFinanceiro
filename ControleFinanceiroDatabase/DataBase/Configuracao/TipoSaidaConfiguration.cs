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
    public class TipoSaidaConfiguration : IEntityTypeConfiguration<TipoSaida>
    {
        public void Configure(EntityTypeBuilder<TipoSaida> builder)
        {
            builder.ToTable("TipoSaida");
            builder.HasKey( s => s.Id);

            builder.Property(s => s.Nome).HasMaxLength(25);

            builder.HasMany(s => s.Saidas).WithOne(s => s.TipoSaida).HasForeignKey(s => s.IdTipoSaida);
        }

    }
}
