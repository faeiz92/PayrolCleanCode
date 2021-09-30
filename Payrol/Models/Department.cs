using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Payrol.Models
{
    public class Department
    {
        
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage ="Can't empty")]
        public string DepartmentName { get; set; }
        
        [Required(ErrorMessage ="Can't empty")]
        public string DepartmentLocation { get; set; }
        public virtual IEnumerable<Staff>  Staffs { get; set; }


    }
}
