﻿// <auto-generated />
using System;
using Hp_Web_App.Shared.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hp_Web_App.Shared.Migrations
{
    [DbContext(typeof(DbWebAppContext))]
    [Migration("20230227085723_AddDocuments")]
    partial class AddDocuments
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hp_Web_App.Shared.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionField", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionFieldTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.HasIndex("QuestionFieldTypeId");

                    b.ToTable("QuestionFields");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionFieldType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SqlDataType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SystemType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QuestionFieldTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SqlDataType = "DateTime",
                            SystemType = "System.DateTime"
                        },
                        new
                        {
                            Id = 2,
                            SqlDataType = "Bit",
                            SystemType = "System.Boolean"
                        },
                        new
                        {
                            Id = 3,
                            SqlDataType = "Varchar(500)",
                            SystemType = "System.String"
                        },
                        new
                        {
                            Id = 4,
                            SqlDataType = "Int",
                            SystemType = "System.Int32"
                        },
                        new
                        {
                            Id = 5,
                            SqlDataType = "Float",
                            SystemType = "System.Double"
                        },
                        new
                        {
                            Id = 6,
                            SqlDataType = "Varchar(max)",
                            SystemType = "System.String"
                        });
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateValueChanged")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionFieldID")
                        .HasColumnType("int");

                    b.Property<string>("QuestionValueType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionFieldID");

                    b.ToTable("QuestionValue");

                    b.HasDiscriminator<string>("QuestionValueType").HasValue("QuestionValue");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionDateValue", b =>
                {
                    b.HasBaseType("Hp_Web_App.Shared.Models.QuestionValue");

                    b.Property<DateTime?>("DateValue")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("QuestionDateValue");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionStringValue", b =>
                {
                    b.HasBaseType("Hp_Web_App.Shared.Models.QuestionValue");

                    b.Property<string>("StringValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("QuestionStringValue");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionField", b =>
                {
                    b.HasOne("Hp_Web_App.Shared.Models.Document", "Document")
                        .WithMany("QuestionFields")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hp_Web_App.Shared.Models.QuestionFieldType", "QuestionFieldType")
                        .WithMany("QuestionFields")
                        .HasForeignKey("QuestionFieldTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");

                    b.Navigation("QuestionFieldType");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionValue", b =>
                {
                    b.HasOne("Hp_Web_App.Shared.Models.QuestionField", null)
                        .WithMany("Values")
                        .HasForeignKey("QuestionFieldID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.Document", b =>
                {
                    b.Navigation("QuestionFields");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionField", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionFieldType", b =>
                {
                    b.Navigation("QuestionFields");
                });
#pragma warning restore 612, 618
        }
    }
}
