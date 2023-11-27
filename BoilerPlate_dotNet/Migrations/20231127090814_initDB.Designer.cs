﻿// <auto-generated />
using System;
using BoilerPlate_dotNet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BoilerPlate_dotNet.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231127090814_initDB")]
    partial class initDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BoilerPlate_dotNet.Data.Domain.Competence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Competence");
                });

            modelBuilder.Entity("BoilerPlate_dotNet.Data.Domain.Evaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompetenceId")
                        .HasColumnType("int");

                    b.Property<int>("Note")
                        .HasColumnType("int");

                    b.Property<int>("PersonneId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetenceId");

                    b.HasIndex("PersonneId");

                    b.ToTable("Evaluation");
                });

            modelBuilder.Entity("BoilerPlate_dotNet.Data.Domain.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personne");
                });

            modelBuilder.Entity("BoilerPlate_dotNet.Data.Domain.Evaluation", b =>
                {
                    b.HasOne("BoilerPlate_dotNet.Data.Domain.Competence", "Competence")
                        .WithMany()
                        .HasForeignKey("CompetenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BoilerPlate_dotNet.Data.Domain.Personne", "Personne")
                        .WithMany("Evaluations")
                        .HasForeignKey("PersonneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competence");

                    b.Navigation("Personne");
                });

            modelBuilder.Entity("BoilerPlate_dotNet.Data.Domain.Personne", b =>
                {
                    b.Navigation("Evaluations");
                });
#pragma warning restore 612, 618
        }
    }
}
