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
    public class ShopController : ControllerBase
    {
        public readonly PayRollDbContext _db;

        public ShopController(PayRollDbContext db)
        {
            _db = db;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Shop>> Get()
        {
            return _db.Shops;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shop>> Get(int id)
        {
            if (id == 0)
                return NotFound();

            var shop = await _db.Shops.FindAsync(id);

            if (shop == null)
                return NotFound();

            return shop;
        }

        [HttpGet("getShopsByIdDepartment")]
        public async Task<ActionResult<IEnumerable<Shop>>> getShopsByIdDepartment(int id)
        {
            if (id == 0)
                return NotFound();

            var shops = await _db.Shops.Where(c => c.DepartmentId == id).ToListAsync();

            return shops;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Shop shop)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Shops.Add(shop);
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
        public async void Put(int id, [FromBody] Shop shopNew)
        {
            try
            {
                var shopOld = await _db.Shops.FindAsync(id);

                if (await TryUpdateModelAsync<Shop>(shopOld, "", c => shopNew))
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
                var shop = await _db.Shops.FindAsync(id);

                _db.Shops.Remove(shop);

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}