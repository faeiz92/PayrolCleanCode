using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payrol.Models;


namespace Payrol
{
    public interface IRepositoryStaff
    {
        Task<IEnumerable<Salary>> GetSalaries();
    }
}
