using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollApi.Models.ViewModels
{
    public class AppsentViewModel
    {
        public DateTime WorkerIsAppsentDay { get; set; }
        public string Text { get; set; }
        public string WorkerId { get; set; }
        public AppsentReasonType AppsentReasonType { get; set; }
    }

}
