using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayRollApi.DAL;
using PayRollApi.Models;

namespace PayRollApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public PayRollDbContext _db;

        public CompanyController(PayRollDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Company>> Get()
        {
            return _db.Companies;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            var company = await _db.Companies.FindAsync(id);

            if (company == null)
                return NotFound();

            return company;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Company company)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Companies.Add(company);
                    await _db.SaveChangesAsync();
                    return Ok(company);
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
        public async Task<IActionResult> Put(int id, [FromBody] Company companyNew)
        {
            try
            {
                var companyOld =await _db.Companies.FindAsync(id);
                companyOld.Name = companyNew.Name;
                _db.SaveChangesAsync().GetAwaiter().GetResult();
                return Ok(companyOld);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var company = await _db.Companies.FindAsync(id);

                _db.Companies.Remove(company);

                 _db.SaveChangesAsync().GetAwaiter().GetResult();

                return NoContent();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}