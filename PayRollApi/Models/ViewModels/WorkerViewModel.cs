using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollApi.Models.ViewModels
{
    public class WorkerViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public string Department { get; set; }
        public string Company { get; set; }
        public string Shop { get; set; }
        public string Profession { get; set; }
        public decimal Salary { get; set; }
        public decimal BonusPrice { get; set; }
        public decimal PenaltyPrice { get; set; }
        public decimal MonthSalary { get; set; }
        public string Picture { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool HasPassword { get; set; }
        public string OldPassword { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string LivingAddress { get; set; }
        public DateTime WorkerIsAppsentDay { get; set; }
        public string Text { get; set; }
        public AppsentReasonType AppsentReasonType { get; set; }
    }
}
