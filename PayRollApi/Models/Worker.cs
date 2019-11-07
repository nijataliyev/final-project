using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollApi.Models
{
    public class Worker:IdentityUser
    {
        public Worker()
        {
            WorkerSalaryInfos = new HashSet<WorkerSalaryInfo>();
            WorkerJobInfos = new HashSet<WorkerJobInfo>();
            Appsents = new HashSet<Appsents>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string Picture { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
        public DateTime BirthDate { get; set; }
        public string LivingAddress { get; set; }
        public virtual City City { get; set; }
        public int CityId { get; set; }
        public string PassportNumber { get; set; }
        public DateTime ExpireDatePassport { get; set; }
        public EducationType EducationType { get; set; }
        public Family Family { get; set; }
        public Gender Gender { get; set; }
        public RoleType RoleType { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int? ShopId { get; set; } = null;
        public virtual Shop Shop { get; set; }
        public int ProfessionId { get; set; }
        public virtual Profession Profession { get; set; }
        public decimal Salary { get; set; }
        public bool GiveBonus { get; set; }
        public decimal GiveBonusPrice { get; set; }
        public decimal Penalty { get; set; }
        public bool IsNotWorking { get; set; }
        public DateTime StartDateWork { get; set; }
        public DateTime? EndDateWork { get; set; }
        public virtual ICollection<WorkerSalaryInfo> WorkerSalaryInfos { get; set; }
        public virtual ICollection<WorkerJobInfo> WorkerJobInfos { get; set; }

        public virtual ICollection<Appsents> Appsents { get; set; }
    }
}
