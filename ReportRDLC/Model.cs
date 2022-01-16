using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ReportRDLC
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Staffs)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.StaffDepartmentId);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Salaries)
                .WithRequired(e => e.Staff)
                .HasForeignKey(e => e.SalaryStaffId);
        }
    }
}
