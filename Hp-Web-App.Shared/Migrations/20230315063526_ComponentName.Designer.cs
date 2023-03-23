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
    [Migration("20230315063526_ComponentName")]
    partial class ComponentName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hp_Web_App.Shared.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyTypeId");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyTypeId = 5,
                            Name = "Hammond Pole"
                        });
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.CompanyDocument", b =>
                {
                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("DocumentId")
                        .HasColumnType("int");

                    b.HasKey("CompanyId", "DocumentId");

                    b.HasIndex("DocumentId");

                    b.ToTable("CompanyDocuments");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.CompanyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CompanyTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Customers would typically be purchasing or selling.",
                            Name = "Customer"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Any organization that sells to Hammond Pole.",
                            Name = "Supplier"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Any company that supplies services to Hammond Pole.",
                            Name = "Contractor"
                        },
                        new
                        {
                            Id = 4,
                            Description = "These are specifically for Estate Agents and their staff.",
                            Name = "Agency"
                        },
                        new
                        {
                            Id = 5,
                            Description = "",
                            Name = "Other"
                        });
                });

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

                    b.Property<string>("ComponentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

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
                            ComponentName = "date",
                            DisplayName = "Date",
                            SqlDataType = "DateTime",
                            SystemType = "System.DateTime"
                        },
                        new
                        {
                            Id = 2,
                            ComponentName = "checkbox",
                            DisplayName = "Yes / No",
                            SqlDataType = "Bit",
                            SystemType = "System.Boolean"
                        },
                        new
                        {
                            Id = 3,
                            ComponentName = "text",
                            DisplayName = "Text",
                            SqlDataType = "Varchar(500)",
                            SystemType = "System.String"
                        },
                        new
                        {
                            Id = 4,
                            ComponentName = "number",
                            DisplayName = "Whole Number",
                            SqlDataType = "Int",
                            SystemType = "System.Int32"
                        },
                        new
                        {
                            Id = 5,
                            ComponentName = "number",
                            DisplayName = "Decimal",
                            SqlDataType = "Float",
                            SystemType = "System.Double"
                        },
                        new
                        {
                            Id = 6,
                            ComponentName = "text",
                            DisplayName = "Memo",
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

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            Email = "alanj@hpd.co.za",
                            IsActive = true,
                            Name = "Admin",
                            Password = "1234",
                            UserRoleId = 1
                        });
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Administrators can Edit or Create Users, Documents, Companies and Questions",
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Users can upload or use non administrative features.",
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionBitValue", b =>
                {
                    b.HasBaseType("Hp_Web_App.Shared.Models.QuestionValue");

                    b.Property<bool?>("BoolValue")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("QuestionBooleanValue");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionDateValue", b =>
                {
                    b.HasBaseType("Hp_Web_App.Shared.Models.QuestionValue");

                    b.Property<DateTime?>("DateValue")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("QuestionDateValue");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionFloatValue", b =>
                {
                    b.HasBaseType("Hp_Web_App.Shared.Models.QuestionValue");

                    b.Property<double>("FloatValue")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("QuestionDecimalValue");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionIntValue", b =>
                {
                    b.HasBaseType("Hp_Web_App.Shared.Models.QuestionValue");

                    b.Property<int>("IntValue")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("QuestionIntegerValue");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionMemoValue", b =>
                {
                    b.HasBaseType("Hp_Web_App.Shared.Models.QuestionValue");

                    b.Property<string>("MemoValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("QuestionMemoValue");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.QuestionStringValue", b =>
                {
                    b.HasBaseType("Hp_Web_App.Shared.Models.QuestionValue");

                    b.Property<string>("StringValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("QuestionStringValue");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.Company", b =>
                {
                    b.HasOne("Hp_Web_App.Shared.Models.CompanyType", "CompanyType")
                        .WithMany("Companies")
                        .HasForeignKey("CompanyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyType");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.CompanyDocument", b =>
                {
                    b.HasOne("Hp_Web_App.Shared.Models.Company", "Company")
                        .WithMany("CompanyDocuments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hp_Web_App.Shared.Models.Document", "Document")
                        .WithMany("CompanyDocuments")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Document");
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

            modelBuilder.Entity("Hp_Web_App.Shared.Models.User", b =>
                {
                    b.HasOne("Hp_Web_App.Shared.Models.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hp_Web_App.Shared.Models.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.Company", b =>
                {
                    b.Navigation("CompanyDocuments");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.CompanyType", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("Hp_Web_App.Shared.Models.Document", b =>
                {
                    b.Navigation("CompanyDocuments");

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

            modelBuilder.Entity("Hp_Web_App.Shared.Models.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
