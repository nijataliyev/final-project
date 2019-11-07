using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PayRollApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollApi.DAL
{

    public static class DefaultDbData
    {
       
        public static void Seed(PayRollDbContext db, UserManager<Worker> userManager, RoleManager<IdentityRole> roleManager)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            var root = configurationBuilder.Build();
         

            if (!roleManager.Roles.Any())
            {
                foreach (var item in Enum.GetNames(typeof(RoleType)))
                {
                    roleManager.CreateAsync(new IdentityRole(item)).GetAwaiter().GetResult();

                }
            }
            if (!db.Countries.Any())
            {
                var country1 = new Country()
                {
                    Name = "Azerbaycan",
                };
                var country2 = new Country()
                {
                    Name = "Rusiya"
                };
                db.Countries.Add(country1);
                db.Countries.Add(country2);
                db.SaveChangesAsync().GetAwaiter().GetResult();

                if (!db.Cities.Any())
                {
                    var city = new City()
                    {
                        Name = "Baki",
                        CountryId=country1.Id
                    };
                    var city1 = new City()
                    {
                        Name = "Sumqait",
                        CountryId = country1.Id
                    };
                    var city2 = new City()
                    {
                        Name = "Moskva",
                        CountryId = country2.Id
                    };
                    db.Cities.AddRange(city,city1,city2);
                    db.SaveChangesAsync().GetAwaiter().GetResult();

                    if (!db.Companies.Any())
                    {
                        var company = new Company()
                        {
                            Name = "NT Holding",
                        };
                        db.Companies.Add(company);
                        db.SaveChangesAsync().GetAwaiter().GetResult();
                        
                        if(!db.Departments.Any())
                        {
                            var department = new Department()
                            {
                                Name = "Human Resource",
                                CompanyId = company.Id
                            };
                            var department1 = new Department()
                            {
                                Name = "IT Programming",
                                CompanyId = company.Id
                            };
                            var department2 = new Department()
                            {
                                Name = "Sale Section",
                                CompanyId = company.Id,

                            };
                            db.Departments.AddRange(department,department1,department2);
                            db.SaveChangesAsync().GetAwaiter().GetResult();

                            if (!db.Shops.Any())
                            {
                                var shop = new Shop()
                                {
                                    Name = "Mango",
                                    DepartmentId = department2.Id
                                };
                                var shop1 = new Shop()
                                {
                                    Name = "New Yorker",
                                    DepartmentId = department2.Id
                                };
                                var shop2 = new Shop()
                                {
                                    Name = "Emporior",
                                    DepartmentId = department2.Id
                                };
                                var shop3 = new Shop()
                                {
                                    Name = "Lc Waikiki",
                                    DepartmentId = department2.Id
                                };
                                db.Shops.AddRange(shop,shop1,shop2,shop3);
                                db.SaveChangesAsync().GetAwaiter().GetResult();

                                if(!db.Professions.Any())
                                {
                                    var profession = new Profession()
                                    {
                                        Name = "Sales Manager"
                                    };
                                    var profession1 = new Profession()
                                    {
                                        Name = "Sales Manager Assitance"
                                    };
                                    var profession2 = new Profession()
                                    {
                                        Name = "Chief Saler"
                                    };
                                    var profession3 = new Profession()
                                    {
                                        Name = "Shop Manager"
                                    };
                                    var profession4 = new Profession()
                                    {
                                        Name = "Brand Manager"
                                    };
                                    var profession5 = new Profession()
                                    {
                                        Name = "Programmer"
                                    };
                                    var profession6 = new Profession()
                                    {
                                        Name = "Chief Programmer"
                                    };
                                    var profession7 = new Profession()
                                    {
                                        Name = "Human Resources"
                                    };
                                    var profession8 = new Profession()
                                    {
                                        Name = "Human Resource Direktor"
                                    };
                                    db.Professions.AddRange(profession,profession1,profession2,profession3,profession4,profession5,
                                                            profession6,profession7,profession8);
                                    db.SaveChangesAsync().GetAwaiter().GetResult();

                                    if (!userManager.Users.Any())
                                    {
                                        var worker = new Worker()
                                        {
                                            Name = "Nicat",
                                            Surname = "Eliyev",
                                            FatherName = "Sheadet",
                                            Picture= "sksksks",
                                            BirthDate = DateTime.Now,
                                            LivingAddress = "Nerimanov",
                                            CityId = city.Id,
                                            PassportNumber = "AZE123456789",
                                            ExpireDatePassport = DateTime.Now,
                                            EducationType = EducationType.High,
                                            Family = Family.Married,
                                            Gender = Gender.Male,
                                            DepartmentId = department1.Id,
                                            ProfessionId = profession6.Id,
                                            Salary = 2500,
                                            GiveBonus = true,
                                            GiveBonusPrice = 200,
                                            StartDateWork = DateTime.Now,
                                            Email = "nijat.Aliyev@mail.ru",
                                            UserName= root.GetSection("Admin").GetSection("Name").Value
                                    };
                                        userManager.CreateAsync(worker, root.GetSection("Admin").GetSection("Password").Value).GetAwaiter().GetResult();
                                        userManager.AddToRoleAsync(worker, "Admin").GetAwaiter().GetResult();
                                        if(!db.WorkerJobInfos.Any())
                                        {
                                            var workerJobInfos = new WorkerJobInfo()
                                            {
                                                WorkPlace = "Akkord ASC",
                                                Name = "Muhendis",
                                                EnterJobDate = DateTime.Now.AddMonths(-12),
                                                LeaveJobDate = DateTime.Now.AddMonths(-6),
                                                LeaveJobReason = "Layihenin sonu",
                                                WorkerId = worker.Id,
                                                
                                            };
                                            db.WorkerJobInfos.Add(workerJobInfos);
                                            db.SaveChangesAsync().GetAwaiter().GetResult();

                                            if(!db.WorkerSalaryInfos.Any())
                                            {
                                                var workerSalaryInfo = new WorkerSalaryInfo()
                                                {
                                                    AMonthSalary = 2500,
                                                    Month = 1,
                                                    Year = 1,
                                                    WorkerId = worker.Id
                                                };
                                                db.WorkerSalaryInfos.Add(workerSalaryInfo);
                                                db.SaveChangesAsync().GetAwaiter().GetResult();
                                                
                                                if(!db.AppsentReasons.Any())
                                                {
                                                    var appsentReason = new AppsentReason()
                                                    {
                                                        Text = "Xeste",
                                                        AppsentReasonType = AppsentReasonType.Allow
                                                    };
                                                    db.AppsentReasons.Add(appsentReason);
                                                    db.SaveChangesAsync().GetAwaiter().GetResult();

                                                    if(!db.Appsents.Any())
                                                    {
                                                        var appsent = new Appsents()
                                                        {
                                                            WorkerIsAppsentDay = DateTime.Now.AddDays(5),
                                                            AppsentReasonId = appsentReason.Id,
                                                            WorkerId = worker.Id
                                                        };
                                                        db.Appsents.Add(appsent);
                                                        db.SaveChangesAsync().GetAwaiter().GetResult();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
