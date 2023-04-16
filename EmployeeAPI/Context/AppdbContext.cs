using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Context
{
    public class AppdbContext : DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
        {            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Positions> Positions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Employe

            modelBuilder.Entity<Employee>().ToTable("TB_EMPLOYEES");
            modelBuilder.Entity<Employee>().HasKey(a => a.EmployeeId);

            modelBuilder.Entity<Employee>().HasIndex(a => a.Cpf).IsUnique();
            modelBuilder.Entity<Employee>().Property(a => a.EmployeeId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Employee>().Property(a => a.Name).HasMaxLength(120);
            modelBuilder.Entity<Employee>().Property(a => a.Cpf).HasMaxLength(14);
            modelBuilder.Entity<Employee>().Property(a => a.MotherName).HasMaxLength(120);

            #endregion

            #region Adress

            modelBuilder.Entity<Adress>().ToTable("TB_ADREESSES");
            modelBuilder.Entity<Adress>().HasKey(a => a.AdressId);
            modelBuilder.Entity<Adress>().Property(a => a.AdressId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Adress>().Property(a => a.Cep).HasMaxLength(9);
            modelBuilder.Entity<Adress>().Property(a => a.Street).HasMaxLength(60);
            modelBuilder.Entity<Adress>().Property(a => a.Complement).HasMaxLength(50);
            modelBuilder.Entity<Adress>().Property(a => a.Cep).HasMaxLength(40);

            #endregion

            #region Positions

            modelBuilder.Entity<Positions>().ToTable("TB_POSITIONS");
            modelBuilder.Entity<Positions>().HasKey(a => a.OfficeId);
            modelBuilder.Entity<Positions>().Property(a => a.OfficeId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Positions>().Property(a => a.Description).HasMaxLength(30);

            #endregion

            #region Relationship

            modelBuilder.Entity<Adress>().HasOne(a => a.Employee).WithOne(a => a.Adress).HasForeignKey<Adress>(a => a.EmployeeId);
            modelBuilder.Entity<Employee>().HasOne(a => a.Office).WithMany(a => a.Employee).HasForeignKey(a => a.OfficeId);

            #endregion

            #region PopulandoBanco

            modelBuilder.Entity<Positions>().HasData(                
                    new Positions { OfficeId = 1, Description = "Junior Developer" },
                    new Positions { OfficeId = 2, Description = "Engineer Developer" },
                    new Positions { OfficeId = 3, Description = "Senior Developer" },
                    new Positions { OfficeId = 4, Description = "Back-End Developer" },
                    new Positions { OfficeId = 5, Description = "Front-End Developer" },
                    new Positions { OfficeId = 6, Description = "Full-Stack Developer" },
                    new Positions { OfficeId = 7, Description = "Senior Back-End Developer" }
                );

            modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        EmployeeId = 1,
                        Name = "Amanda Do Espirito Santo",
                        Cpf = "432.756.645-43",
                        Sex = "Fêmea",
                        MotherName = "Marlene Dal Pra",
                        UserName = "amandaeps",
                        Email = "amanda@gmail.com",
                        Password = "Neg@7699",
                        OfficeId = 2
                    }
                );

            modelBuilder.Entity<Adress>().HasData(
                    new Adress
                    {
                        AdressId = 1,
                        Cep = "89224-475",
                        Street = "Areia Branca",
                        Number = 1215,
                        Neighborhood = "Jardim Iririu",
                        Complement = "Bloco 06 apt 201",
                        City = "Joinville",
                        EmployeeId = 1
                    }                 
                );

            #endregion
        }
    }
}
