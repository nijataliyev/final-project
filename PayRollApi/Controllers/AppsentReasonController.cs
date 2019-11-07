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
    public class AppsentReasonController : ControllerBase
    {
        public readonly PayRollDbContext _db;
        public AppsentReasonController(PayRollDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppsentReason>> Get()
        {
            return _db.AppsentReasons;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppsentReason>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            var appsentReason = await _db.AppsentReasons.FindAsync(id);

            if (appsentReason == null)
                return NotFound();

            return appsentReason;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AppsentReason appsentReason)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.AppsentReasons.Add(appsentReason);
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
        public async void Put(int id, [FromBody] AppsentReason appsentReasonNew)
        {
            try
            {
                var appsentReasonOld = await _db.AppsentReasons.FindAsync(id);

                if (await TryUpdateModelAsync<AppsentReason>(appsentReasonOld, "", c => appsentReasonNew))
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
                var appsentReason = await _db.AppsentReasons.FindAsync(id);

                _db.AppsentReasons.Remove(appsentReason);

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}