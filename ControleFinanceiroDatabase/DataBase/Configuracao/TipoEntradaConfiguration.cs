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
    public class TipoEntradaConfiguration : IEntityTypeConfiguration<TipoEntrada>
    {
        public void Configure(EntityTypeBuilder<TipoEntrada> builder)
        {
            builder.ToTable("TipoEntrada");
            builder.HasKey( s => s.Id);

            builder.Property(s => s.Nome).HasMaxLength(25);

            builder.HasMany(s => s.Entradas).WithOne(s => s.TipoEntrada).HasForeignKey(s => s.IdTipoEntrada);
        }

    }
}
