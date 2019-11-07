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
    public class WorkerJobInfoController : ControllerBase
    {
        public readonly PayRollDbContext _db;

        public WorkerJobInfoController(PayRollDbContext db)
        {
            _db = db;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<WorkerJobInfo>> Get()
        {
            return _db.WorkerJobInfos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerJobInfo>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            var workerJobInfo = await _db.WorkerJobInfos.FindAsync(id);

            if (workerJobInfo == null)
                return NotFound();

            return workerJobInfo;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WorkerJobInfo workerJobInfo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.WorkerJobInfos.Add(workerJobInfo);
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
        public async void Put(int id, [FromBody] WorkerJobInfo workerJobInfoNew)
        {
            try
            {
                var workerJobInfoOld = await _db.WorkerJobInfos.FindAsync(id);

                if (await TryUpdateModelAsync<WorkerJobInfo>(workerJobInfoOld, "", c => workerJobInfoNew))
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
                var workerJobInfo = await _db.WorkerJobInfos.FindAsync(id);

                _db.WorkerJobInfos.Remove(workerJobInfo);

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}