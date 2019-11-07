using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollApi.Models
{
    public class WorkerJobInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string WorkPlace { get; set; }
        public DateTime EnterJobDate { get; set; }
        public DateTime LeaveJobDate { get; set; }
        public string LeaveJobReason { get; set; }
        public string WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
