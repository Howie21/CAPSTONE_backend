using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerceStarterCode.Controllers
{
    [Route("api/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public AddressController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/address
        [HttpGet]
        public IActionResult Get()
        {
            var AddressBook = _context.Addresses;
            return Ok(AddressBook);
        }

        // GET api/address/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Address = _context.Addresses.Where(ad => ad.Id == id);
            return Ok(Address);
        }

        // POST api/<AddressController>
        [HttpPost]
        public IActionResult Post([FromBody] Address value)
        {
            _context.Addresses.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // PUT api/<AddressController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Address value)
        {
            _context.Addresses.Update(value);
            _context.SaveChanges();
            return Ok(value);
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Address = _context.Addresses.Where(ad => ad.Id == id).SingleOrDefault();
            _context.Addresses.Remove(Address);
            _context.SaveChanges();
            return StatusCode(200, Address);
        }
    }
}
