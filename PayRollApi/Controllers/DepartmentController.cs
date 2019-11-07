using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayRollApi.DAL;
using PayRollApi.Models;

namespace PayRollApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly PayRollDbContext _db;

        public DepartmentController(PayRollDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            return _db.Departments;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            var department = await _db.Departments.FindAsync(id);

            if (department == null)
                return NotFound();

            return department;
        }


        [HttpGet("getDepartmentByIdCompany")]
        public async Task<ActionResult<IEnumerable<Department>>> getDepartmentByIdCompany(int id)
        {
            if (id == 0)
                return NotFound();

            var departments = await _db.Departments.Where(c => c.CompanyId == id).ToListAsync();

            return departments;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Departments.Add(department);
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] Department departmentNew)
        {
            try
            {
                var departmentOld = await _db.Departments.FindAsync(id);

                if (await TryUpdateModelAsync<Department>(departmentOld, "", c => departmentNew))
                {
                    await _db.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            try
            {
                var department = await _db.Departments.FindAsync(id);

                _db.Departments.Remove(department);

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}