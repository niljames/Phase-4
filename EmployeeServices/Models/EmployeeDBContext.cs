using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeServices.Models
{
    public partial class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {

        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEmployees> TblEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=H5CG125CX26;Database=EmployeeDB;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblEmployees>(entity =>
            {
                entity.ToTable("tblEmployees");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ename)
                    .HasColumnName("ename")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Job)
                    .HasColumnName("job")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
