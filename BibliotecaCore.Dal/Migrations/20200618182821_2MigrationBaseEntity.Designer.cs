﻿// <auto-generated />
using System;
using BibliotecaCore.Dal.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BibliotecaCore.Dal.Migrations
{
    [DbContext(typeof(DbLibraryContext))]
    [Migration("20200618182821_2MigrationBaseEntity")]
    partial class _2MigrationBaseEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BibliotecaCore.Dal.Entities.Author", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BibliotecaCore.Dal.Entities.Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Authorid");

                    b.Property<int?>("Categoryid");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.HasIndex("Authorid");

                    b.HasIndex("Categoryid");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BibliotecaCore.Dal.Entities.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("BibliotecaCore.Dal.Entities.Book", b =>
                {
                    b.HasOne("BibliotecaCore.Dal.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("Authorid");

                    b.HasOne("BibliotecaCore.Dal.Entities.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("Categoryid");
                });
#pragma warning restore 612, 618
        }
    }
}
