using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollApi.Models
{
    public class WorkerSalaryInfo
    {
        public int Id { get; set; }
        public decimal AMonthSalary { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
