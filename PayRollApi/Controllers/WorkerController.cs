using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using PayRollApi.DAL;
using PayRollApi.Models;
using PayRollApi.Models.ViewModels;

namespace PayRollApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        public readonly PayRollDbContext _db;
        public readonly UserManager<Worker> _userManger;
        public SignInManager<Worker> _signInManager;

        public WorkerController(PayRollDbContext db, SignInManager<Worker> signInManager, UserManager<Worker> userManger)
        {
            _db = db;
            _userManger = userManger;
            _signInManager = signInManager;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<WorkerViewModel>> Get()
        {
            
            var workers = _db.Workers
                .Include(x => x.Department)
                .Include(x => x.Department.Company)
                .Include(x => x.Shop)
                .Include(x => x.Profession)
                .Include(x => x.City)
                .Include(x => x.City.Country)
                .Include(x => x.WorkerSalaryInfos)
                  .Where(y => !y.IsNotWorking)
                .Select(x => new WorkerViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Fathername = x.FatherName,
                    Department = x.Department.Name,
                    Shop = x.Shop.Name,
                    Company = x.Department.Company.Name,
                    Profession = x.Profession.Name,
                    Salary = x.Salary,
                    BonusPrice = x.GiveBonusPrice,
                    Picture = x.Picture,
                    BirthDate = x.BirthDate,
                    Country = x.City.Country.Name,
                    City = x.City.Name,
                    LivingAddress = x.LivingAddress,
                    PenaltyPrice = x.Penalty,
                    MonthSalary=GetThisMonthSalary(x.WorkerSalaryInfos)
                })
                .ToList();
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "Image");
            foreach (var worker in workers)
            {
                var imageFullPath = Path.Combine(path, worker.Picture);
                if (System.IO.File.Exists(imageFullPath))
                {
                    byte[] imageArray = System.IO.File.ReadAllBytes(imageFullPath);
                    string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                    worker.Picture = base64ImageRepresentation;
                }

            }

            return workers;
        }
        public decimal GetThisMonthSalary(IEnumerable<WorkerSalaryInfo> workerSalary)
        {
            decimal res = 0;
            var now = DateTime.Now;
            var month = now.Month;
            var year = now.Year;
            if (workerSalary.Where(y => y.Year == year && y.Month == month).FirstOrDefault() != null)
                res = workerSalary.Where(y => y.Year == year && y.Month == month).FirstOrDefault().AMonthSalary;

            return res;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerViewModel>> Get(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
                return NotFound();

            var x = await _db.Workers
                .Include(y => y.Department)
                .Include(y => y.Department.Company)
                .Include(y => y.Shop)
                .Include(y => y.Profession)
                .Include(y => y.City)
                .Include(y => y.City.Country)
                .Where(y=>!y.IsNotWorking)
                .SingleOrDefaultAsync(y => y.Id == id);
            var worker = new WorkerViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Fathername = x.FatherName,
                Department = x.Department?.Name,
                Shop = x.Shop?.Name,
                Company = x.Department?.Company?.Name,
                Profession = x.Profession?.Name,
                Salary = x.Salary,
                BonusPrice = x.GiveBonusPrice,
                Picture = x.Picture,
                BirthDate = x.BirthDate,
                Country = x.City.Country.Name,
                City = x.City.Name,
                LivingAddress = x.LivingAddress,
                PenaltyPrice =x.Penalty,
            };
            worker.HasPassword = await _userManger.HasPasswordAsync(x);
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "Image");
            var imageFullPath = Path.Combine(path, worker.Picture);

            if (System.IO.File.Exists(imageFullPath))
            {
                byte[] imageArray = System.IO.File.ReadAllBytes(imageFullPath);
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                worker.Picture = base64ImageRepresentation;
            }
            if (worker == null)
                return NotFound();

            return worker;
        }

        [HttpGet("getOldWorkers")]
        public async Task<ActionResult<IEnumerable<WorkerViewModel>>> getOldWorkers()
        {
            var workers = await _db.Workers
               .Include(y => y.Department)
               .Include(y => y.Department.Company)
               .Include(y => y.Shop)
               .Include(y => y.Profession)
               .Include(y => y.City)
               .Include(y => y.City.Country)
               .Where(y => y.IsNotWorking).Select(x => new WorkerViewModel()
               {
                   Id = x.Id,
                   Name = x.Name,
                   Surname = x.Surname,
                   Fathername = x.FatherName,
                   Department = x.Department == null ? "" : x.Department.Name,
                   Shop = x.Shop == null ? "" : x.Shop.Name,
                   Company = x.Department == null ? "" : x.Department.Company == null ? "" : x.Department.Company.Name,
                   Profession = x.Profession == null ? "" : x.Profession.Name,
                   Salary = x.Salary,
                   BonusPrice = x.GiveBonusPrice,
                   Picture = x.Picture,
                   BirthDate = x.BirthDate,
                   Country = x.City.Country.Name,
                   City = x.City.Name,
                   LivingAddress = x.LivingAddress,
                   PenaltyPrice = x.Penalty,
               }).ToListAsync();
            string path = Directory.GetCurrentDirectory();
            path = Path.Combine(path, "Image");
            foreach (var worker in workers)
            {
                var imageFullPath = Path.Combine(path, worker.Picture);
                if (System.IO.File.Exists(imageFullPath))
                {
                    byte[] imageArray = System.IO.File.ReadAllBytes(imageFullPath);
                    string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                    worker.Picture = base64ImageRepresentation;
                }

            }
            return workers;

        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Worker worker)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (worker.ShopId == 0)
                        worker.ShopId = null;

                    if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
                    {
                        return Ok();
                    }

                    if (!worker.Photo.ContentType.Contains("image/"))
                    {
                        ModelState.AddModelError("Photo", "This is shoul be image");
                        return Ok();
                    }

                    string path = Directory.GetCurrentDirectory();
                    path = Path.Combine(path, "Image");
                    string fileName = Path.Combine("img", Guid.NewGuid().ToString() + worker.Photo.FileName);

                    path = Path.Combine(path, fileName);

                    using (FileStream fileStream = new FileStream(path, FileMode.Create))
                    {
                        await worker.Photo.CopyToAsync(fileStream);
                    }

                    worker.Picture = fileName;
                    worker.UserName = "UserName" + (_db.Workers.Count() + 1);

                    string role = Enum.GetName(typeof(RoleType), worker.RoleType);

                    var result = await _userManger.CreateAsync(worker);
                    if (result.Succeeded)
                    {
                        var currentUser = await _userManger.FindByNameAsync(worker.UserName);

                        var roleresult =await _userManger.AddToRoleAsync(currentUser, role);

                    }


                    return Ok();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        // PUT api/values/5
        [HttpPut("editWorker")]
        public async Task<IActionResult> editWorker(string id, [FromBody] WorkerViewModel workerNew)
        {
            try
            {
                var workerOld = await _db.Workers.FindAsync(id);
                workerOld.Name = workerNew.Name;
                workerOld.Surname = workerNew.Surname;
                workerOld.FatherName = workerNew.Fathername;
                workerOld.BirthDate = workerNew.BirthDate;
                _db.SaveChangesAsync().GetAwaiter().GetResult();
                return Ok(workerOld);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var worker = await _db.Workers.FindAsync(id);

                worker.IsNotWorking = true;

                await _db.SaveChangesAsync();

                return Ok(1);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("addSalary")]
        public async Task<IActionResult> AddSalary([FromBody] WorkerViewModel worker)
        {
            try
            {
                var currentWorker = await _db.Workers.FindAsync(worker.Id);

                currentWorker.Salary = worker.Salary;

                await _db.SaveChangesAsync();

                return Ok(currentWorker.Salary);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("giveAppsent")]
        public async Task<IActionResult> GiveAppsent([FromForm] AppsentViewModel appsent)
        {
            try
            {
                var appsentReason = new AppsentReason()
                {
                     AppsentReasonType=appsent.AppsentReasonType,
                      Text=appsent.Text
                };
                await _db.AppsentReasons.AddAsync(appsentReason);
                await _db.SaveChangesAsync();

                var createAppsent = new Appsents()
                {
                    WorkerId = appsent.WorkerId,
                    WorkerIsAppsentDay = appsent.WorkerIsAppsentDay,
                    AppsentReasonId = appsentReason.Id
                };
                await _db.Appsents.AddAsync(createAppsent);
                await _db.SaveChangesAsync();

                return Ok(createAppsent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("addBonusPrice")]
        public async Task<IActionResult> AddBonusPrice([FromBody] WorkerViewModel worker)
        {
            try
            {
                var currentWorker = await _db.Workers.FindAsync(worker.Id);

                currentWorker.GiveBonusPrice = worker.BonusPrice;

                await _db.SaveChangesAsync();

                return Ok(currentWorker.GiveBonusPrice);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost("givePenalty")]
        public async Task<IActionResult> givePenalty([FromBody] WorkerViewModel worker)
        {
            try
            {
                var currentWorker = await _db.Workers.FindAsync(worker.Id);

                currentWorker.Penalty = worker.PenaltyPrice;

                await _db.SaveChangesAsync();

                return Ok(currentWorker.Penalty);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost("calculate")]
        public async Task<IActionResult> Calculate()
        {
            try
            {
                var now = DateTime.Now;
                var month = now.Month;
                var year = now.Year;
                var currentWorker = await _db.Workers
                     .Include(x => x.Department)
                .Include(x => x.Department.Company)
                .Include(x => x.Shop)
                .Include(x => x.Profession)
                .Include(x => x.City)
                .Include(x => x.City.Country)
                .Include(x=>x.WorkerSalaryInfos)
                .Include(x=>x.Appsents)
                .Include("Appsents.AppsentReason")
                .Where(x=>!x.IsNotWorking)

                    .Select(x => new WorkerViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Fathername = x.FatherName,
                    Department = x.Department.Name,
                    Shop = x.Shop==null?"" :x.Shop.Name,
                    Company = x.Department==null?"": x.Department.Company ==null?"":x.Department.Company.Name,
                    Profession = x.Profession==null?"":x.Profession.Name,
                    Salary = x.Salary,
                    BonusPrice = x.GiveBonusPrice,
                    Picture = x.Picture,
                    BirthDate = x.BirthDate,
                    Country = x.City.Country.Name,
                    City = x.City.Name,
                    LivingAddress = x.LivingAddress,
                    PenaltyPrice = x.Penalty,
                    MonthSalary = GetThisMonthSalary(x.WorkerSalaryInfos)==0? CalculateMonthSalary(x): GetThisMonthSalary(x.WorkerSalaryInfos)
                    }).ToListAsync();
                _db.SaveChanges();

                return Ok(currentWorker);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        private decimal CalculateMonthSalary(Worker worker)
        {
            var now = DateTime.Now;
            decimal t = 0;
            var day =  now.Subtract(worker.StartDateWork).Days+1;
            var daysOfMonth =  DateTime.DaysInMonth(now.Year,now.Month);
            var month = now.Month;
            var h = new DateTime(now.Year, month, daysOfMonth);
            if(!worker.WorkerSalaryInfos.Any(x=>x.Month==now.Month && x.Year == now.Year))
            {
                if (((now.Day + 1) == daysOfMonth && (new DateTime(now.Year, month, daysOfMonth)).DayOfWeek == DayOfWeek.Saturday) ||
               ((now.Day + 2) == daysOfMonth && (new DateTime(now.Year, month, daysOfMonth)).DayOfWeek == DayOfWeek.Sunday) ||
                (now.Day == daysOfMonth))
                {
                    foreach (var appsent in worker.Appsents)
                    {
                        if (appsent.AppsentReason.AppsentReasonType == AppsentReasonType.NotAllow)
                            day--;
                    }
                    t = Math.Round(((((worker.Salary / daysOfMonth) * day) + worker.GiveBonusPrice) - worker.Penalty), 2);

                    WorkerSalaryInfo workerSalaryInfo = new WorkerSalaryInfo()
                    {
                        AMonthSalary = t,
                        Year = now.Year,
                        Month = now.Month,
                        WorkerId = worker.Id
                    };
                    _db.WorkerSalaryInfos.Add(workerSalaryInfo);
                }
            }
            return Math.Round(t,2);
        }

        [HttpPost("givePassword")]
        public async Task<IActionResult> GivePassword([FromBody] WorkerViewModel worker)
        {
            try
            {
                if (worker.Password != worker.ConfirmPassword)
                    return BadRequest();
                var currentWorker = await _userManger.FindByIdAsync(worker.Id);


                var hasPassword = await _userManger.HasPasswordAsync(currentWorker);

                if (hasPassword)
                    await _userManger.ChangePasswordAsync(currentWorker, worker.OldPassword, worker.Password);
                else
                    await _userManger.AddPasswordAsync(currentWorker, worker.Password);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}