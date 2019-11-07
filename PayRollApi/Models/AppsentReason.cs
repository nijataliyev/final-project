using System.Collections.Generic;

namespace PayRollApi.Models
{
    public class AppsentReason
    {
        public AppsentReason()
        {
            Appsents = new HashSet<Appsents>();
        }
        public int Id { get; set; }
        public string Text { get; set; }

        public AppsentReasonType AppsentReasonType { get; set; }

        public virtual ICollection<Appsents> Appsents { get; set; }
    }
}