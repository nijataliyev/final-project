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
    public class AppsentController : ControllerBase
    {
        public readonly PayRollDbContext _db;

        public AppsentController(PayRollDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Appsents>> Get()
        {
            return _db.Appsents;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appsents>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            var appsent = await _db.Appsents.FindAsync(id);

            if (appsent == null)
                return NotFound();

            return appsent;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Appsents appsent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Appsents.Add(appsent);
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
        public async void Put(int id, [FromBody] Appsents appsentNew)
        {
            try
            {
                var appsentOld = await _db.Appsents.FindAsync(id);

                if (await TryUpdateModelAsync<Appsents>(appsentOld, "", c => appsentNew))
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
                var appsent = await _db.Appsents.FindAsync(id);

                _db.Appsents.Remove(appsent);

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}