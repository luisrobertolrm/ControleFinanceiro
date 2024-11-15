﻿// <auto-generated />
using System;
using ControleFinanceiro.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ControleFinanceiro.Database.Migrations
{
    [DbContext(typeof(ControleFinanceiroContext))]
    partial class ControleFinanceiroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ControleFinanceiro.Core.Entity.Entrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataProjetada")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("IdTipoEntrada")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Mes")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoEntrada");

                    b.HasIndex("Ano", "Mes");

                    b.ToTable("Entrada", (string)null);
                });

            modelBuilder.Entity("ControleFinanceiro.Core.Entity.Periodo", b =>
                {
                    b.Property<int>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Mes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Ano", "Mes");

                    b.ToTable("Periodo", (string)null);
                });

            modelBuilder.Entity("ControleFinanceiro.Core.Entity.Saida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataProjetada")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("IdTipoSaida")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Mes")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoSaida");

                    b.HasIndex("Ano", "Mes");

                    b.ToTable("Saida", (string)null);
                });

            modelBuilder.Entity("ControleFinanceiro.Core.Entity.SaidaItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("IdSaida")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdTipoSaida")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdSaida");

                    b.ToTable("SaidaItem", (string)null);
                });

            modelBuilder.Entity("ControleFinanceiro.Core.Entity.TipoEntrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TipoEntrada", (string)null);
                });

            modelBuilder.Entity("ControleFinanceiro.Core.Entity.TipoSaida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TipoSaida", (string)null);
                });

            modelBuilder.Entity("ControleFinanceiro.Core.Entity.Entrada", b =>
                {
                    b.HasOne("ControleFinanceiro.Core.Entity.TipoEntrada", "TipoEntrada")
                        .WithMany("Entradas")
                        .HasForeignKey("IdTipoEntrada")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleFinanceiro.Core.Entity.Periodo", "Periodo")
                        .WithMany("Entradas")
                        .HasForeignKey("Ano", "Mes")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Periodo");

                    b.Navigation("TipoEntrada");
                });

            modelBuilder.Entity("ControleFinanceiro.Core.Entity.Saida", b =>
                {
                    b.HasOne("ControleFinanceiro.Core.Entity.TipoSaida", "TipoSaida")
                        .WithMany("Saidas")
                        .HasForeignKey("IdTipoSaida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControleFinanceiro.Core.Entity.Periodo", "Periodo")
                        .WithMany("Saidas")
                        .HasForeignKey("Ano", "Mes")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Periodo");

                    b.Navigation("TipoSaida");
                });

            modelBuilder.Entity("ControleFinanceiro.Core.Entity.SaidaItem", b =>
                {
                    b.HasOne("ControleFinanceiro.Core.Entity.Saida", "Saida")
                        .WithMany("SaidasItem")
                        .HasForeignKey("IdSaida")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Saida");
                });

            modelBuilder.Entity("ControleFinanceiro.Core.Entity.Periodo", b =>
                {
                    b.Navigation("Entradas");

                    b.Navigation("Saidas");
                });

            modelBuilder.Entity("ControleFinanceiro.Core.Entity.Saida", b =>
                {
                    b.Navigation("SaidasItem");
                });

            modelBuilder.Entity("ControleFinanceiro.Core.Entity.TipoEntrada", b =>
                {
                    b.Navigation("Entradas");
                });

            modelBuilder.Entity("ControleFinanceiro.Core.Entity.TipoSaida", b =>
                {
                    b.Navigation("Saidas");
                });
#pragma warning restore 612, 618
        }
    }
}
