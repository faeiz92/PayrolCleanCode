namespace ReportRDLC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Salary")]
    public partial class Salary
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
