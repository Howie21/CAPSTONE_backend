using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerceStarterCode.Controllers
{
    [Route("api/workorders")]
    [ApiController]
    public class WorkOrdersController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public WorkOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            var workOrders = _context.WorkOrders.Include(wo => wo.User).Include(wo => wo.Property).Include(wo => wo.Property.Address);
            return Ok(workOrders);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var workOrder = _context.WorkOrders.Where(wo => wo.RequestorId == id).Include(wo => wo.User).Include(wo => wo.Property).Include(wo => wo.Property.Address).FirstOrDefault();
            return Ok(workOrder);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] WorkOrder value)
        {
            _context.WorkOrders.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public IActionResult Put( [FromBody] WorkOrder value)
        {
            _context.WorkOrders.Update(value);
            _context.SaveChanges();
            return Ok(value);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var WorkOrder = _context.WorkOrders.Where(wo => wo.OrderId == id).SingleOrDefault();
            _context.WorkOrders.Remove(WorkOrder);
            _context.SaveChanges();
            return StatusCode(200, WorkOrder);
        }
    }
}
