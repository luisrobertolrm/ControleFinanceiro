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
    public class SaidaItemConfiguration : IEntityTypeConfiguration<SaidaItem>
    {
        public void Configure(EntityTypeBuilder<SaidaItem> builder)
        {
            builder.ToTable("SaidaItem");
            builder.HasKey( s => s.Id);

            builder.Property(s => s.Descricao).HasMaxLength(100);

            builder.HasOne(s => s.Saida).WithMany(s => s.SaidasItem).HasForeignKey(s => s.IdSaida);
        }

    }
}
