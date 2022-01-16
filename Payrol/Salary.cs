using Payrol.Models;

namespace ReportRDLC
{
   
    public class Salary
    {
        public int SalaryId { get; set; }

        public double SalaryBasic { get; set; }

        public double SalaryTransportAllowance { get; set; }

        public double SalaryPerformanceAllowance { get; set; }

        public double SalaryOvertime { get; set; }

        public double SalaryKwsp { get; set; }

        public int SalaryStaffId { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
