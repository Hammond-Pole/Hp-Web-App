using Hp_Web_App.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hp_Web_App.Shared.DbContexts
{
    public class DbWebAppContext : DbContext
    {
        // To add a new migration type the following command in the Package Manager Console:
        // Add-Migration <MigrationName>
        // To update the database type the following command in the Package Manager Console:
        // Update-Database

        public DbWebAppContext(DbContextOptions options) : base(options)
        {

        }

        // Set Tables
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<QuestionField> QuestionFields { get; set; }
        public DbSet<QuestionFieldType> QuestionFieldTypes { get; set; }
        public DbSet<QuestionDateValue> QuestionValues { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<CompanyDocument> CompanyDocuments { get; set; }
        public DbSet<DocumentsAttached> DocumentsAttached { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            modelBuilder.Entity<DocumentsAttached>()
                .HasMany(e => e.QuestionValues)
                .WithOne(e => e.DocumentsAttached)
                .HasForeignKey(e => e.DocumentsAttachedId);

            modelBuilder.Entity<QuestionFieldType>().Ignore(e => e.ComponentType);
            
            modelBuilder.Entity<User>()
                .HasMany(da => da.DocumentsAttached) // User has many DocumentsAttached
                .WithOne(u => u.User) // DocumentsAttached has one User
                .HasForeignKey(da => da.UserId); // UserId is the foreign key property for dependent entity

            modelBuilder.Entity<User>()
                .HasOne(u => u.UserRole) // User has one UserRole
                .WithMany(ur => ur.Users) // UserRole has many Users
                .HasForeignKey(u => u.UserRoleId); // UserRoleId is the foreign key property for dependent entity

            modelBuilder.Entity<Company>()
                .HasMany(da => da.DocumentsAttached) // Company has many DocumentsAttached
                .WithOne(c => c.Company) // DocumentsAttached has one Company
                .HasForeignKey(da => da.CompanyId); // CompanyId is the foreign key property for dependent entity

            modelBuilder.Entity<Document>()
                .HasMany(da => da.DocumentsAttached) // Document has many DocumentsAttached
                .WithOne(d => d.Document) // DocumentsAttached has one Document
                .HasForeignKey(da => da.DocumentId); // DocumentId is the foreign key property for dependent entity

            modelBuilder.Entity<Company>()
                .HasOne(c => c.CompanyType) // Company has one CompanyType
                .WithMany(ct => ct.Companies) // CompanyType has many Companies
                .HasForeignKey(c => c.CompanyTypeId); // CompanyTypeId is the foreign key property for dependent entity

            modelBuilder.Entity<User>()
                .HasOne(c => c.Company) // User has one Company
                .WithMany(ct => ct.Users) // Company has many Users
                .HasForeignKey(c => c.CompanyId); // CompanyId is the foreign key property for dependent entity

            modelBuilder.Entity<CompanyDocument>()
                .HasKey(cd => new { cd.CompanyId, cd.DocumentId }); // Composite key

            modelBuilder.Entity<CompanyDocument>()
                .HasOne(c => c.Company) // Company has one CompanyType
                .WithMany(cd => cd.CompanyDocuments)
                .HasForeignKey(cd => cd.CompanyId);

            modelBuilder.Entity<CompanyDocument>()
                .HasOne(cd => cd.Document) // Company has many CompanyDocuments
                .WithMany(cd => cd.CompanyDocuments) // Document has one CompanyDocument
                .HasForeignKey(cd => cd.DocumentId);

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
                new QuestionFieldType { Id = 1, SqlDataType = "DateTime", SystemType = "System.DateTime", DisplayName = "Date", ComponentName = "date" },
                new QuestionFieldType { Id = 2, SqlDataType = "Bit", SystemType = "System.Boolean", DisplayName = "Yes / No", ComponentName = "checkbox" },
                new QuestionFieldType { Id = 3, SqlDataType = "Varchar(500)", SystemType = "System.String", DisplayName = "Text", ComponentName = "text" },
                new QuestionFieldType { Id = 4, SqlDataType = "Int", SystemType = "System.Int32", DisplayName = "Whole Number", ComponentName = "number" },
                new QuestionFieldType { Id = 5, SqlDataType = "Float", SystemType = "System.Double", DisplayName = "Decimal", ComponentName = "decimal" },
                new QuestionFieldType { Id = 6, SqlDataType = "Varchar(max)", SystemType = "System.String", DisplayName = "Memo", ComponentName = "Memo" }
            );

            // Seed data for CompanyType table
            modelBuilder.Entity<CompanyType>().HasData(
                               new CompanyType { Id = 1, Name = "Customer", Description = "Customers would typically be purchasing or selling." },
                               new CompanyType { Id = 2, Name = "Supplier", Description = "Any organization that sells to Hammond Pole." },
                               new CompanyType { Id = 3, Name = "Contractor", Description = "Any company that supplies services to Hammond Pole." },
                               new CompanyType { Id = 4, Name = "Agency", Description = "These are specifically for Estate Agents and their staff." },
                               new CompanyType { Id = 5, Name = "Other" }
            );

            modelBuilder.Entity<UserRole>().HasData(
                               new UserRole { Id = 1, Name = "Administrator", Description = "Administrators can Edit or Create Users, Documents, Companies and Questions" },
                                    new UserRole { Id = 2, Name = "User", Description = "Users can upload or use non administrative features." }
            );

            modelBuilder.Entity<Company>().HasData(
                            new Company { Id = 1, Name = "Hammond Pole", CompanyTypeId = 5 });

            modelBuilder.Entity<User>().HasData(
                                new User { Id = 1, Name = "Admin", Email = "alanj@hpd.co.za", CompanyId = 1, UserRoleId = 1, IsActive = true, Password = "1234" });

            base.OnModelCreating(modelBuilder);
        }
    }
}