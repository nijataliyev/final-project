using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollApi.Models
{
    public class Appsents
    {
        public int Id { get; set; }
        public DateTime WorkerIsAppsentDay { get; set; }
        public string WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
        public int AppsentReasonId { get; set; }
        public virtual AppsentReason AppsentReason { get; set; }
    }
}
