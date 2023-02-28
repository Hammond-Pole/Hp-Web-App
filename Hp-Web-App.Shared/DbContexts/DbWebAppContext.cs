using Hp_Web_App.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace Hp_Web_App.Shared.DbContexts
{
    public class DbWebAppContext : DbContext
    {
        public DbWebAppContext(DbContextOptions options) : base(options)
        {

        }

        // Set Tables
        public DbSet<User>? Users { get; set; }
        public DbSet<Document>? Documents { get; set; }
        public DbSet<QuestionField>? QuestionFields { get; set; }
        public DbSet<QuestionFieldType>? QuestionFieldTypes { get; set; }
        public DbSet<QuestionDateValue>? QuestionValues { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuestionField>()
               .HasOne(qf => qf.QuestionFieldType) // QuestionField has one QuestionFieldType
               .WithMany(qft => qft.QuestionFields) // QuestionFieldType has many QuestionFields
               .HasForeignKey(qf => qf.QuestionFieldTypeId); // QuestionFieldTypeId is the foreign key property for dependent entity

            modelBuilder.Entity<QuestionField>()
                .HasOne(qf => qf.Document) // QuestionField has one Document
                .WithMany(d => d.QuestionFields) // Document has many QuestionFields
                .HasForeignKey(qf => qf.DocumentId); // DocumentId is the foreign key property for dependent entity

            modelBuilder.Entity<QuestionValue>()
                .HasDiscriminator<string>("QuestionValueType")
                .HasValue<QuestionDateValue>("QuestionDateValue")
                .HasValue<QuestionStringValue>("QuestionStringValue")
                .HasValue<QuestionBitValue>("QuestionBooleanValue")
                .HasValue<QuestionIntValue>("QuestionIntegerValue")
                .HasValue<QuestionFloatValue>("QuestionDecimalValue")
                .HasValue<QuestionMemoValue>("QuestionMemoValue");
                ;

            // Seed data for QuestionFieldType table
            modelBuilder.Entity<QuestionFieldType>().HasData(
                new QuestionFieldType { Id = 1, SqlDataType = "DateTime", SystemType = "System.DateTime", DisplayName = "Date" },
                new QuestionFieldType { Id = 2, SqlDataType = "Bit", SystemType = "System.Boolean", DisplayName = "Yes / No" },
                new QuestionFieldType { Id = 3, SqlDataType = "Varchar(500)", SystemType = "System.String", DisplayName = "Text" },
                new QuestionFieldType { Id = 4, SqlDataType = "Int", SystemType = "System.Int32", DisplayName = "Whole Number"},
                new QuestionFieldType { Id = 5, SqlDataType = "Float", SystemType = "System.Double", DisplayName = "Decimal" },
                new QuestionFieldType { Id = 6, SqlDataType = "Varchar(max)", SystemType = "System.String", DisplayName = "Memo" }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
