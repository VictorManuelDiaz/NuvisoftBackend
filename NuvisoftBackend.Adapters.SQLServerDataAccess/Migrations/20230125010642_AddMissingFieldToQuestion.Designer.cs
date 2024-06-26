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
    [Migration("20230125010642_AddMissingFieldToQuestion")]
    partial class AddMissingFieldToQuestion
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

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Answer", b =>
                {
                    b.HasOne("NuvisoftBackend.Core.Domain.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("question_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
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

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Subject", b =>
                {
                    b.Navigation("Templates");
                });

            modelBuilder.Entity("NuvisoftBackend.Core.Domain.Models.Template", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
