﻿// <auto-generated />
using System;
using ApiCoreBusiness;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebApi_Concecionaria.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Api_Core_Business.Entidades.Cliente", b =>
                {
                    b.Property<int>("idCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCliente"), 1L, 1);

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dni")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Api_Core_Business.Entidades.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Api_Core_Business.Entidades.Vehiculo", b =>
                {
                    b.Property<int>("idVehiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVehiculo"), 1L, 1);

                    b.Property<DateTime>("fechaBaja")
                        .HasColumnType("datetime2");

                    b.Property<string>("marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("precio")
                        .HasColumnType("real");

                    b.HasKey("idVehiculo");

                    b.ToTable("Vehiculo");
                });

            modelBuilder.Entity("Api_Core_Business.Entidades.Venta", b =>
                {
                    b.Property<int>("idVentas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVentas"), 1L, 1);

                    b.Property<int>("descuento")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("idCliente")
                        .HasColumnType("int");

                    b.Property<int>("idVehiculo")
                        .HasColumnType("int");

                    b.Property<string>("importe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("vehiculoidVehiculo")
                        .HasColumnType("int");

                    b.HasKey("idVentas");

                    b.HasIndex("idCliente");

                    b.HasIndex("vehiculoidVehiculo");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Api_Core_Business.Entidades.Venta", b =>
                {
                    b.HasOne("Api_Core_Business.Entidades.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("idCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api_Core_Business.Entidades.Vehiculo", "vehiculo")
                        .WithMany()
                        .HasForeignKey("vehiculoidVehiculo");

                    b.Navigation("Cliente");

                    b.Navigation("vehiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
