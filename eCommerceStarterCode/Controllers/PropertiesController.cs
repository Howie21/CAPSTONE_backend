using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerceStarterCode.Controllers
{
    [Route("api/properties")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public PropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<PropertiesController>
        [HttpGet]
        public IActionResult Get()
        {
            var properties = _context.Properties.Include(p => p.Address);
            return Ok(properties);
        }

        // GET api/<PropertiesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var property = _context.Properties.Where(p => p.Id == id).Include(p => p.Address).SingleOrDefault();
            return Ok(property);
        }

        // POST api/<PropertiesController>
        [HttpPost]
        public IActionResult Post([FromBody] Property value)
        {
            _context.Properties.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // PUT api/<PropertiesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Property value)
        {
            _context.Properties.Update(value);
            _context.SaveChanges();
            return Ok(value);
        }

        // DELETE api/<PropertiesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var property = _context.Properties.Where(p => p.Id == id).SingleOrDefault();
            _context.Properties.Remove(property);
            _context.SaveChanges();
            return StatusCode(200, property);
        }
    }
}
