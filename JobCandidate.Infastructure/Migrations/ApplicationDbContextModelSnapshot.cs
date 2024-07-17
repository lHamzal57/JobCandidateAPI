﻿// <auto-generated />
using System;
using JobCandidate.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobCandidate.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobCandidate.Domain.Entities.Auth", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("credentials");

                    b.HasData(
                        new
                        {
                            Id = new Guid("acf7595c-df33-4c68-8688-b8a39c9476e8"),
                            Password = "AQAAAAIAAYagAAAAEBiKTrtI4t9zT+V0Rb5SQn2jBqLa10V1vaxeXW01ipw+DjKy50phuxRgVwaGzTSIxA==",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("JobCandidate.Domain.Entities.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("CreatedByUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedByUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("FirstModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("FirstModifiedByUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FreeTextComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GitHubProfileUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModificationDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastModifiedByUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedInProfileUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("MustDeletedPhysical")
                        .HasColumnType("bit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Candidates");
                });

            modelBuilder.Entity("JobCandidate.Domain.Entities.Candidate", b =>
                {
                    b.OwnsOne("JobCandidate.Domain.Entities.TimeInterval", "BestTimeToCall", b1 =>
                        {
                            b1.Property<Guid>("CandidateId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<TimeSpan>("End")
                                .HasColumnType("time");

                            b1.Property<TimeSpan>("Start")
                                .HasColumnType("time");

                            b1.HasKey("CandidateId");

                            b1.ToTable("Candidates");

                            b1.WithOwner()
                                .HasForeignKey("CandidateId");
                        });

                    b.Navigation("BestTimeToCall")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
