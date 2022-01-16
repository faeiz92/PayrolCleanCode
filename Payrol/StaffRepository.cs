using Payrol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payrol.Data;
using System.Data.SqlClient;
using Microsoft.ReportingServices.DataProcessing;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace Payrol
{
    public class StaffRepository : IRepositoryStaff
    {
        private readonly ApplicationDbContext _db;
        //public DbContextOptionsBuilder(Microsoft.EntityFrameworkCore.DbContextOptions options);
        public StaffRepository(ApplicationDbContext databaseOptions)
        {
            _db = databaseOptions;
        }

        public async Task<IEnumerable<Salary>> GetSalaries()
        {
            //IEnumerable<Salary> salary = _db.Salary;
            //using (ApplicationDbContext db2 = new SqlConnection(_db))
            //{
            return await _db.QueryAsync<Salary>("select Staff, SalaryBasic, SalaryKwsp, SalaryOvertime, SalaryPerformanceAllowance, SalaryTransportAllowance", commandType : CommandType.Text);
            //}
        }
    }
}
