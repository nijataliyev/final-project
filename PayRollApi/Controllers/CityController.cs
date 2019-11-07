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
    public class CityController : ControllerBase
    {
        public readonly PayRollDbContext _db;

        public CityController(PayRollDbContext db)
        {
            _db = db;
        }

        [HttpGet("getCities")]
        public ActionResult<IEnumerable<City>> GetCities()
        {
            return _db.Cities;
        }

        // GET api/values/5
        [HttpGet("getCity")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            if (id == 0)
                return NotFound();

            var city = await _db.Cities.FindAsync(id);

            if (city == null)
                return NotFound();

            return city;
        }

        [HttpGet("getCitiesByIdCountry")]
        public async Task<ActionResult<IEnumerable<City>>> GetCitiesByIdCountry(int id)
        {
            if (id == 0)
                return NotFound();

            var cities = await _db.Cities.Where(c => c.CountryId == id).ToListAsync();

            return cities;
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] City city)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Cities.Add(city);
                    await _db.SaveChangesAsync();
                    return Ok(city);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        // PUT api/values/5
        [HttpPut("editCityByCountryId")]
        public async Task<IActionResult> editCityByCountryId(int id, [FromBody] City cityNew)
        {
            try
            {
                var cityOld = await _db.Cities.FindAsync(id);
                cityOld.Name = cityNew.Name;
                _db.SaveChangesAsync().GetAwaiter().GetResult();
                return Ok(cityOld);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            try
            {
                var city = await _db.Cities.FindAsync(id);

                _db.Cities.Remove(city);

                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}