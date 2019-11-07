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
    public class ProfessionController : ControllerBase
    {
        public readonly PayRollDbContext _db;

        public ProfessionController(PayRollDbContext db)
        {
            _db = db;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Profession>> Get()
        {
            return _db.Professions;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profession>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            var profession = await _db.Professions.FindAsync(id);

            if (profession == null)
                return NotFound();

            return profession;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Profession profession)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Professions.Add(profession);
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
        public async void Put(int id, [FromBody] Profession professionNew)
        {
            try
            {
                var professionOld = await _db.Professions.FindAsync(id);

                if (await TryUpdateModelAsync<Profession>(professionOld, "", c => professionNew))
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
                var profession = await _db.Professions.FindAsync(id);

                _db.Professions.Remove(profession);

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}