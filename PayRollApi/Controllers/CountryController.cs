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
    public class CountryController : ControllerBase
    {
        public readonly PayRollDbContext _db;

        public CountryController(PayRollDbContext db)
        {
            _db = db;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Country>> Get()
        {
            return _db.Countries;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            var country =await _db.Countries.FindAsync(id);

            if(country==null)
                return NotFound();

            return country;
        }

        // POST api/values
        [HttpPost]
        public async  Task<IActionResult> Post([FromBody] Country country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Countries.Add(country);
                    await _db.SaveChangesAsync();
                    return Ok(country);
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
        public async Task<IActionResult> Put(int id, [FromBody] Country countryNew)
        {
            try
            {
                var countryOld = await _db.Countries.FindAsync(id);
                countryOld.Name = countryNew.Name;
                _db.SaveChangesAsync().GetAwaiter().GetResult();
                return Ok(countryOld);

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
                var country = await _db.Countries.FindAsync(id);

                _db.Countries.Remove(country);

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