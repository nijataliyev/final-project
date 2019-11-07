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
    public class WorkerSalaryInfoController : ControllerBase
    {
        public readonly PayRollDbContext _db;

        public WorkerSalaryInfoController(PayRollDbContext db)
        {
            _db = db;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<WorkerSalaryInfo>> Get()
        {
            return _db.WorkerSalaryInfos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerSalaryInfo>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            var workerSalaryInfo = await _db.WorkerSalaryInfos.FindAsync(id);

            if (workerSalaryInfo == null)
                return NotFound();

            return workerSalaryInfo;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WorkerSalaryInfo workerSalaryInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.WorkerSalaryInfos.Add(workerSalaryInfo);
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
        public async void Put(int id, [FromBody] WorkerSalaryInfo workerSalaryInfoNew)
        {
            try
            {
                var workerSalaryInfoOld = await _db.WorkerSalaryInfos.FindAsync(id);

                if (await TryUpdateModelAsync<WorkerSalaryInfo>(workerSalaryInfoOld, "", c => workerSalaryInfoNew))
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
                var workerSalaryInfo = await _db.WorkerSalaryInfos.FindAsync(id);

                _db.WorkerSalaryInfos.Remove(workerSalaryInfo);

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}