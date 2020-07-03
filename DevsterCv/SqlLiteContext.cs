using DevsterCv.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv
{
    public class SqlLiteContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Technique> Techniques { get; set; }
        public DbSet<EmployeeTechnique> EmployeeTechniques { get; set; }
        public DbSet<EmployeeTrade> EmployeeTrades { get; set; }
        public DbSet<EmployeeMiddleware> EmployeeMiddlewares { get; set; }
        public DbSet<EmployeeTraining> EmployeeTrainings { get; set; }
        public DbSet<EmployeeExpertise> EmployeeExpertises { get; set; }
        public DbSet<Assigment> Assigments { get; set; }
        public DbSet<Expertise> Expertises { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<Middleware> Middlewares { get; set; }




        public SqlLiteContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlite(connectionString: "Filename=./SustainItCV-V01.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTechnique>()
                .HasKey(bc => new { bc.EmployeeId, bc.TechniqueId });
            modelBuilder.Entity<EmployeeTechnique>()
                .HasOne(bc => bc.Employee)
                .WithMany(b => b.EmployeeTechniques)
                .HasForeignKey(bc => bc.EmployeeId);
            modelBuilder.Entity<EmployeeTechnique>()
                .HasOne(bc => bc.Technique)
                .WithMany(c => c.EmployeeTechniques)
                .HasForeignKey(bc => bc.TechniqueId);

            modelBuilder.Entity<EmployeeExpertise>()
    .HasKey(bc => new { bc.EmployeeId, bc.ExpertiseId });
            modelBuilder.Entity<EmployeeExpertise>()
                .HasOne(bc => bc.Employee)
                .WithMany(b => b.EmployeeExpertises)
                .HasForeignKey(bc => bc.EmployeeId);
            modelBuilder.Entity<EmployeeExpertise>()
                .HasOne(bc => bc.Expertise)
                .WithMany(c => c.EmployeeExpertises)
                .HasForeignKey(bc => bc.ExpertiseId);

            modelBuilder.Entity<EmployeeMiddleware>()
       .HasKey(bc => new { bc.EmployeeId, bc.MiddlewareId });
            modelBuilder.Entity<EmployeeMiddleware>()
                .HasOne(bc => bc.Employee)
                .WithMany(b => b.EmployeeMiddleswares)
                .HasForeignKey(bc => bc.EmployeeId);
            modelBuilder.Entity<EmployeeMiddleware>()
                .HasOne(bc => bc.Middleware)
                .WithMany(c => c.EmployeeMiddleswares)
                .HasForeignKey(bc => bc.MiddlewareId);

            modelBuilder.Entity<EmployeeTrade>()
    .HasKey(bc => new { bc.EmployeeId, bc.TradeId });
            modelBuilder.Entity<EmployeeTrade>()
                .HasOne(bc => bc.Employee)
                .WithMany(b => b.EmployeeTrades)
                .HasForeignKey(bc => bc.EmployeeId);
            modelBuilder.Entity<EmployeeTrade>()
                .HasOne(bc => bc.Trade)
                .WithMany(c => c.EmployeeTrades)
                .HasForeignKey(bc => bc.TradeId);

            modelBuilder.Entity<EmployeeTraining>()
.HasKey(bc => new { bc.EmployeeId, bc.TrainingId });
            modelBuilder.Entity<EmployeeTraining>()
                .HasOne(bc => bc.Employee)
                .WithMany(b => b.EmployeeTrainings)
                .HasForeignKey(bc => bc.EmployeeId);
            modelBuilder.Entity<EmployeeTraining>()
                .HasOne(bc => bc.Training)
                .WithMany(c => c.EmployeeTrainings)
                .HasForeignKey(bc => bc.TrainingId);
        }

        public DbSet<DevsterCv.Models.Company> Company { get; set; }

    }
}
