﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NuvisoftBackend.Adapters.SQLServerDataAccess.Contexts;

#nullable disable

namespace NuvisoftBackend.Adapters.SQLServerDataAccess.Migrations
{
    [DbContext(typeof(NuvisoftDB))]
    [Migration("20230219215735_AddsUserRolesEntities")]
    partial class AddsUserRolesEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Answer", b =>
                {
                    b.Property<Guid>("answer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("created_by")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_correct")
                        .HasColumnType("bit");

                    b.Property<Guid>("question_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("updated_by")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("answer_id");

                    b.HasIndex("question_id");

                    b.ToTable("tb_answer", (string)null);
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Job", b =>
                {
                    b.Property<Guid>("job_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("created_by")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("end")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("start")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("template_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("updated_by")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("job_id");

                    b.HasIndex("template_id");

                    b.ToTable("tb_job", (string)null);
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Privilege", b =>
                {
                    b.Property<Guid>("privilege_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("created_by")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("role_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("updated_by")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("privilege_id");

                    b.HasIndex("role_id");

                    b.HasIndex("user_id");

                    b.ToTable("atb_privilege", (string)null);
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.PrivilegeSubject", b =>
                {
                    b.Property<Guid>("privilege_subject_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("created_by")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("privilege_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("subject_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("updated_by")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("privilege_subject_id");

                    b.HasIndex("privilege_id");

                    b.HasIndex("subject_id");

                    b.ToTable("atb_privilege_subject", (string)null);
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Question", b =>
                {
                    b.Property<Guid>("question_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("created_by")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_auto")
                        .HasColumnType("bit");

                    b.Property<int>("score")
                        .HasColumnType("int");

                    b.Property<Guid>("template_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("updated_by")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("question_id");

                    b.HasIndex("template_id");

                    b.ToTable("tb_question", (string)null);
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Role", b =>
                {
                    b.Property<Guid>("role_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("created_by")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("updated_by")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("role_id");

                    b.ToTable("tb_role", (string)null);
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.School", b =>
                {
                    b.Property<Guid>("school_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("created_by")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("updated_by")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("school_id");

                    b.ToTable("tb_school", (string)null);
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Subject", b =>
                {
                    b.Property<Guid>("subject_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("created_by")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("updated_by")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("subject_id");

                    b.ToTable("tb_subject", (string)null);
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Template", b =>
                {
                    b.Property<Guid>("template_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("created_by")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("subject_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("updated_by")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("template_id");

                    b.HasIndex("subject_id");

                    b.ToTable("tb_template", (string)null);
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.User", b =>
                {
                    b.Property<Guid>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("created_by")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("id_card")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("school_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("updated_by")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("user_id");

                    b.HasIndex("school_id");

                    b.ToTable("tb_user", (string)null);
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Answer", b =>
                {
                    b.HasOne("NuvisoftBackend.Core.Domain.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("question_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Job", b =>
                {
                    b.HasOne("NuvisoftBackend.Core.Domain.Models.Template", "Template")
                        .WithMany("Jobs")
                        .HasForeignKey("template_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Privilege", b =>
                {
                    b.HasOne("NuvisoftBackend.Core.Domain.Models.Role", "Role")
                        .WithMany("Privileges")
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NuvisoftBackend.Core.Domain.Models.User", "User")
                        .WithMany("Privileges")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.PrivilegeSubject", b =>
                {
                    b.HasOne("NuvisoftBackend.Core.Domain.Models.Privilege", "Privilege")
                        .WithMany("PrivilegesSubject")
                        .HasForeignKey("privilege_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NuvisoftBackend.Core.Domain.Models.Subject", "Subject")
                        .WithMany("PrivilegesSubject")
                        .HasForeignKey("subject_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Privilege");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Question", b =>
                {
                    b.HasOne("NuvisoftBackend.Core.Domain.Models.Template", "Template")
                        .WithMany("Questions")
                        .HasForeignKey("template_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Template");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Template", b =>
                {
                    b.HasOne("NuvisoftBackend.Core.Domain.Models.Subject", "Subject")
                        .WithMany("Templates")
                        .HasForeignKey("subject_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.User", b =>
                {
                    b.HasOne("NuvisoftBackend.Core.Domain.Models.School", "School")
                        .WithMany("Users")
                        .HasForeignKey("school_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Privilege", b =>
                {
                    b.Navigation("PrivilegesSubject");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Role", b =>
                {
                    b.Navigation("Privileges");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.School", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Subject", b =>
                {
                    b.Navigation("PrivilegesSubject");

                    b.Navigation("Templates");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Template", b =>
                {
                    b.Navigation("Jobs");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.User", b =>
                {
                    b.Navigation("Privileges");
                });
#pragma warning restore 612, 618
        }
    }
}
