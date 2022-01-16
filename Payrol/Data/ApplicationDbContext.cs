using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.ReportingServices.DataProcessing;
using Payrol.Models;

namespace Payrol.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Salary> Salary { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Staff>()
               .HasOne(x => x.Department)
               .WithMany(x => x.Staffs)
               .HasForeignKey(x => x.StaffDepartmentId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Staff>()
                .HasMany(x => x.Salaries)
                .WithOne(x => x.Staff)
                .HasForeignKey(x => x.SalaryStaffId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Department>()
                .HasMany(x => x.Staffs)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.StaffDepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Salary>()
                .HasOne(x => x.Staff)
               .WithMany(x => x.Salaries)
               .HasForeignKey(x => x.SalaryStaffId)
               .OnDelete(DeleteBehavior.Cascade);

        }

        internal Task<IEnumerable<T>> QueryAsync<T>(string v, object commandType)
        {
          throw new NotImplementedException();
        }
    }


}
