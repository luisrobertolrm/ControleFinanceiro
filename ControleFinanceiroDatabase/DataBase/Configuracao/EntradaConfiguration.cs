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
    public class EntradaConfiguration : IEntityTypeConfiguration<Entrada>
    {
        public void Configure(EntityTypeBuilder<Entrada> builder)
        {
            builder.ToTable("Entrada");
            builder.HasKey( s => s.Id );

            builder.Property( s => s.Descricao).HasMaxLength(100);

            builder.HasOne(s => s.TipoEntrada).WithMany(s => s.Entradas).HasForeignKey(s => s.IdTipoEntrada);
        }

    }
}
