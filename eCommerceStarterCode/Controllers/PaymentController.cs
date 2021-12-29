using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerceStarterCode.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: api/<PaymentController>
        [HttpGet]
        public IActionResult Get()
        {
            var payments = _context.Payments.Include(pm => pm.User).Include(pm => pm.Property);
            return Ok(payments);
        }

        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var payment = _context.Payments.Where(pm => pm.UserId == id ).Include(pm => pm.User).Include(pm => pm.Property);
            return Ok(payment);
        }

        // POST api/<PaymentController>
        [HttpPost]
        public IActionResult Post([FromBody] Payment value)
        {
            _context.Payments.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // PUT api/<PaymentController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Payment value)
        {
            _context.Payments.Update(value);
            _context.SaveChanges();
            return Ok(value);
        }

        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var payment = _context.Payments.Where(pm => pm.Id == id).SingleOrDefault();
            _context.Payments.Remove(payment);
            _context.SaveChanges();
            return StatusCode(200, payment);
        }
    }
}
