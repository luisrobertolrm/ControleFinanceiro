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
    public class SaidaConfiguration : IEntityTypeConfiguration<Saida>
    {
        public void Configure(EntityTypeBuilder<Saida> builder)
        {
            builder.ToTable("Saida");
            builder.HasKey( s => s.Id);

            builder.Property(s => s.Descricao).HasMaxLength(100);

            builder.HasOne(s => s.TipoSaida).WithMany(s => s.Saidas).HasForeignKey(s => s.IdTipoSaida);
        }

    }
}
