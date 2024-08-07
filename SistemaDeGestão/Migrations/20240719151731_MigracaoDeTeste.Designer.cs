﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDeGestão.Data;

#nullable disable

namespace SistemaDeGestão.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240719151731_MigracaoDeTeste")]
    partial class MigracaoDeTeste
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SistemaDeGestão.Models.Adicional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GrupoAdicionalId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemPedidoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<double>("PrecoAdicional")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("GrupoAdicionalId");

                    b.HasIndex("ItemPedidoId");

                    b.ToTable("Adicionais");
                });

            modelBuilder.Entity("SistemaDeGestão.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("SistemaDeGestão.Models.GrupoAdicional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("GrupoAdicionais");
                });

            modelBuilder.Entity("SistemaDeGestão.Models.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("PedidoId")
                        .HasColumnType("int");

                    b.Property<double>("PrecoUnitario")
                        .HasColumnType("double");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("ItensPedido");
                });

            modelBuilder.Entity("SistemaDeGestão.Models.Movimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataMovimentacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Localizacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("TipoMovimentacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("SistemaDeGestão.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("SistemaDeGestão.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AdicionalId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Preco")
                        .HasColumnType("double");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("QuantidadeEstoque")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("SistemaDeGestão.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SistemaDeGestão.Models.Adicional", b =>
                {
                    b.HasOne("SistemaDeGestão.Models.GrupoAdicional", "grupoAdicional")
                        .WithMany("Adicionais")
                        .HasForeignKey("GrupoAdicionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeGestão.Models.ItemPedido", null)
                        .WithMany("Adicionais")
                        .HasForeignKey("ItemPedidoId");

                    b.Navigation("grupoAdicional");
                });

            modelBuilder.Entity("SistemaDeGestão.Models.ItemPedido", b =>
                {
                    b.HasOne("SistemaDeGestão.Models.Pedido", null)
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SistemaDeGestão.Models.Produto", b =>
                {
                    b.HasOne("SistemaDeGestão.Models.Categoria", null)
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDeGestão.Models.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("SistemaDeGestão.Models.GrupoAdicional", b =>
                {
                    b.Navigation("Adicionais");
                });

            modelBuilder.Entity("SistemaDeGestão.Models.ItemPedido", b =>
                {
                    b.Navigation("Adicionais");
                });

            modelBuilder.Entity("SistemaDeGestão.Models.Pedido", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
