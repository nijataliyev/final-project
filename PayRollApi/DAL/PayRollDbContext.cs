using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PayRollApi.Models;
using PayRollApi.Models.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollApi.DAL
{
    public class PayRollDbContext:IdentityDbContext<Worker,IdentityRole,string>
    {
        public PayRollDbContext(DbContextOptions<PayRollDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<WorkerJobInfo> WorkerJobInfos { get; set; }
        public DbSet<WorkerSalaryInfo> WorkerSalaryInfos { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Bonus> Bonus { get; set; }
        public DbSet<Appsents> Appsents { get; set; }
        public DbSet<AppsentReason> AppsentReasons { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
