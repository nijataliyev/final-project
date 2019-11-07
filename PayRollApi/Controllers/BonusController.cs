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
    public class BonusController : ControllerBase
    {
        public readonly PayRollDbContext _db;

        public BonusController(PayRollDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Bonus>> Get()
        {
            return _db.Bonus;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bonus>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            var bonus = await _db.Bonus.FindAsync(id);

            if (bonus == null)
                return NotFound();

            return bonus;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Bonus bonus)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Bonus.Add(bonus);
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
        public async void Put(int id, [FromBody] Bonus bonusNew)
        {
            try
            {
                var bonusOld = await _db.Workers.FindAsync(id);

                if (await TryUpdateModelAsync<Worker>(bonusOld, "", c => bonusNew))
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
                var bonus = await _db.Bonus.FindAsync(id);

                _db.Bonus.Remove(bonus);

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}