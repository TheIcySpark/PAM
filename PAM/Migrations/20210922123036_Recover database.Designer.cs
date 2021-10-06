﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PAM.Data;

namespace PAM.Migrations
{
    [DbContext(typeof(PAMContext))]
    [Migration("20210922123036_Recover database")]
    partial class Recoverdatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PAM.Models.IMDBActor", b =>
                {
                    b.Property<int>("IMDBActorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CharacterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IMDBItemID")
                        .HasColumnType("int");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IMDBActorID");

                    b.HasIndex("IMDBItemID");

                    b.ToTable("IMDBActor");
                });

            modelBuilder.Entity("PAM.Models.IMDBCompany", b =>
                {
                    b.Property<int>("IMDBCompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IMDBItemID")
                        .HasColumnType("int");

                    b.HasKey("IMDBCompanyID");

                    b.HasIndex("IMDBItemID");

                    b.ToTable("IMDBCompany");
                });

            modelBuilder.Entity("PAM.Models.IMDBDirector", b =>
                {
                    b.Property<int>("IMDBDirectorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DirectorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IMDBItemID")
                        .HasColumnType("int");

                    b.HasKey("IMDBDirectorID");

                    b.HasIndex("IMDBItemID");

                    b.ToTable("IMDBDirector");
                });

            modelBuilder.Entity("PAM.Models.IMDBGenre", b =>
                {
                    b.Property<int>("IMDBGenreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IMDBItemID")
                        .HasColumnType("int");

                    b.HasKey("IMDBGenreID");

                    b.HasIndex("IMDBItemID");

                    b.ToTable("IMDBGenre");
                });

            modelBuilder.Entity("PAM.Models.IMDBItem", b =>
                {
                    b.Property<int>("IMDBItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Awards")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IMDBID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IMDBRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetacriticRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Runtime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrailerLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IMDBItemID");

                    b.ToTable("IMDBItem");
                });

            modelBuilder.Entity("PAM.Models.IMDBItemsList", b =>
                {
                    b.Property<int>("IMDBItemsListID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("IMDBItemsListID");

                    b.ToTable("IMDBItemsList");
                });

            modelBuilder.Entity("PAM.Models.IMDBWriter", b =>
                {
                    b.Property<int>("IMDBWriterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IMDBItemID")
                        .HasColumnType("int");

                    b.Property<string>("WriterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IMDBWriterID");

                    b.HasIndex("IMDBItemID");

                    b.ToTable("IMDBWriter");
                });

            modelBuilder.Entity("PAM.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GoogleUserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PAM.Models.IMDBActor", b =>
                {
                    b.HasOne("PAM.Models.IMDBItem", null)
                        .WithMany("ActorsList")
                        .HasForeignKey("IMDBItemID");
                });

            modelBuilder.Entity("PAM.Models.IMDBCompany", b =>
                {
                    b.HasOne("PAM.Models.IMDBItem", null)
                        .WithMany("CompanysList")
                        .HasForeignKey("IMDBItemID");
                });

            modelBuilder.Entity("PAM.Models.IMDBDirector", b =>
                {
                    b.HasOne("PAM.Models.IMDBItem", null)
                        .WithMany("DirectorsList")
                        .HasForeignKey("IMDBItemID");
                });

            modelBuilder.Entity("PAM.Models.IMDBGenre", b =>
                {
                    b.HasOne("PAM.Models.IMDBItem", null)
                        .WithMany("GenresList")
                        .HasForeignKey("IMDBItemID");
                });

            modelBuilder.Entity("PAM.Models.IMDBWriter", b =>
                {
                    b.HasOne("PAM.Models.IMDBItem", null)
                        .WithMany("WritersList")
                        .HasForeignKey("IMDBItemID");
                });

            modelBuilder.Entity("PAM.Models.IMDBItem", b =>
                {
                    b.Navigation("ActorsList");

                    b.Navigation("CompanysList");

                    b.Navigation("DirectorsList");

                    b.Navigation("GenresList");

                    b.Navigation("WritersList");
                });
#pragma warning restore 612, 618
        }
    }
}