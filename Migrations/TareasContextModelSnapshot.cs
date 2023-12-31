﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using proyectoef;

#nullable disable

namespace proyectoef.Migrations
{
    [DbContext(typeof(TareasContext))]
    partial class TareasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("proyectoef.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("integer");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("444d704f-9ef9-430e-89d1-9520c2bc507a"),
                            Nombre = "Actividades pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("444d704f-9ef9-430e-89d1-9520c2bc5002"),
                            Nombre = "Actividades personales",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uuid");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("444d704f-9ef9-430e-89d1-9520c2bc5010"),
                            CategoriaId = new Guid("444d704f-9ef9-430e-89d1-9520c2bc507a"),
                            FechaCreacion = new DateTime(2023, 6, 21, 19, 0, 39, 356, DateTimeKind.Utc).AddTicks(4580),
                            PrioridadTarea = 1,
                            Titulo = "Pago de servicios públicos"
                        },
                        new
                        {
                            TareaId = new Guid("444d704f-9ef9-430e-89d1-9520c2bc5011"),
                            CategoriaId = new Guid("444d704f-9ef9-430e-89d1-9520c2bc5002"),
                            FechaCreacion = new DateTime(2023, 6, 21, 19, 0, 39, 356, DateTimeKind.Utc).AddTicks(4592),
                            PrioridadTarea = 0,
                            Titulo = "Terminar de ver peliculas en Netflix"
                        });
                });

            modelBuilder.Entity("proyectoef.Models.Tarea", b =>
                {
                    b.HasOne("proyectoef.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("proyectoef.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
