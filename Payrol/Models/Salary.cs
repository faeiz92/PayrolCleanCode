using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payrol.Models
{
    public class Salary
    {
        [Key]
        public int SalaryId { get; set; }
        [Required(ErrorMessage = "Can't empty")]
        public double SalaryBasic { get; set; }

        [Required(ErrorMessage = "Can't empty")]
        public double SalaryTransportAllowance { get; set; }

        [Required(ErrorMessage = "Can't empty")]
        public double SalaryPerformanceAllowance { get; set; }

        [Required(ErrorMessage = "Can't empty")]
        public double SalaryOvertime { get; set; }

        [Required(ErrorMessage = "Can't empty")]
        public double SalaryKwsp { get; set; }

        [Required(ErrorMessage = "Can't empty")]
        public int SalaryStaffId { get; set; }
        public virtual Staff Staff { get; set; }
    
    }
}
