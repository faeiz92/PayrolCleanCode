using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payrol.Models
{
    public class Staff 
    {
        [Key]
        public int StaffId { get; set; }

        [Required(ErrorMessage = "Can't empty")]
        public string StaffName { get; set; }

        [Required(ErrorMessage = "Can't empty")]
        public int StaffAge { get; set; }

        [Required(ErrorMessage = "Can't empty")]
        public int StaffDepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual IEnumerable<Salary> Salaries { get; set; }
      
    }
}
