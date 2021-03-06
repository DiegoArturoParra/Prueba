// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Prueba.Api.Repositorio;

namespace Prueba.Api.Migrations
{
    [DbContext(typeof(Mapeo))]
    partial class MapeoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Prueba.Models.Gato", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("text");

                    b.Property<object[]>("breeds")
                        .HasColumnType("json")
                        .HasColumnName("breeds");

                    b.Property<int>("height")
                        .HasColumnType("integer");

                    b.Property<string>("url")
                        .HasColumnType("text");

                    b.Property<int>("width")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("gato", "public");
                });
#pragma warning restore 612, 618
        }
    }
}
