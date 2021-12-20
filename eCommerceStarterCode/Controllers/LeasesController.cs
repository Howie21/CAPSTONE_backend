using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerceStarterCode.Controllers
{
    [Route("api/leases")]
    [ApiController]
    public class LeasesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public LeasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<LeasesController>
        [HttpGet]
        public IActionResult Get()
        {
            var Leases = _context.Leases;
            return Ok(Leases);
        }

        // GET api/<LeasesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Lease = _context.Leases.Where(l => l.Id == id);
            return Ok(Lease);
        }

        // POST api/<LeasesController>
        [HttpPost]
        public IActionResult Post([FromBody] Lease value)
        {
            _context.Leases.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // PUT api/<LeasesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Lease value)
        {
            _context.Leases.Update(value);
            _context.SaveChanges();
            return Ok(value);
        }

        // DELETE api/<LeasesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Lease = _context.Leases.Where(l => l.Id == id).SingleOrDefault();
            _context.Leases.Remove(Lease);
            _context.SaveChanges();
            return StatusCode(200, Lease);
        }
    }
}
