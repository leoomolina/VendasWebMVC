﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using VendasWebMVC.Models;

namespace VendasWebMVC.Migrations
{
    [DbContext(typeof(VendasWebMVCContext))]
    [Migration("20210519165853_EntidadesVendedorVendas")]
    partial class EntidadesVendedorVendas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VendasWebMVC.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("VendasWebMVC.Models.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataVenda");

                    b.Property<int>("Status");

                    b.Property<double>("ValorTotal");

                    b.Property<int?>("VendedorId");

                    b.HasKey("Id");

                    b.HasIndex("VendedorId");

                    b.ToTable("Venda");
                });

            modelBuilder.Entity("VendasWebMVC.Models.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataNascimento");

                    b.Property<int?>("DepartamentoId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<double>("SalarioBase");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("VendasWebMVC.Models.Venda", b =>
                {
                    b.HasOne("VendasWebMVC.Models.Vendedor", "Vendedor")
                        .WithMany("Vendas")
                        .HasForeignKey("VendedorId");
                });

            modelBuilder.Entity("VendasWebMVC.Models.Vendedor", b =>
                {
                    b.HasOne("VendasWebMVC.Models.Departamento", "Departamento")
                        .WithMany("Vendedores")
                        .HasForeignKey("DepartamentoId");
                });
#pragma warning restore 612, 618
        }
    }
}
