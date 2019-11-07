using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollApi.Models
{
    public class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
