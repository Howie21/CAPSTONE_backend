using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerceStarterCode.Controllers
{
    [Route("api/tenantsinfo")]
    [ApiController]
    public class TenantsInfoController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public TenantsInfoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<TenantsInfoController>
        [HttpGet]
        public IActionResult Get()
        {
            var tenant = _context.TenantsInfo.Include(tn => tn.Lease).Include(tn => tn.Property).Include(tn => tn.Property.Address);
            return Ok(tenant);
        }

        // GET api/<TenantsInfoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var tenant = _context.TenantsInfo.Where(tn => tn.Id == id).Include(tn => tn.Lease).Include(tn => tn.Property).Include(tn => tn.Property.Address).SingleOrDefault();
            return Ok(tenant);
        }

        // POST api/<TenantsInfoController>
        [HttpPost]
        public IActionResult Post([FromBody] TenantInfo value)
        {
            _context.TenantsInfo.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // PUT api/<TenantsInfoController>/5
        [HttpPut]
        public IActionResult Put([FromBody] TenantInfo value)
        {
            _context.TenantsInfo.Update(value);
            _context.SaveChanges();
            return Ok(value);
        }

        // DELETE api/<TenantsInfoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tenantInfo = _context.TenantsInfo.Where(tn => tn.Id == id).SingleOrDefault();
            _context.TenantsInfo.Remove(tenantInfo);
            _context.SaveChanges();
            return StatusCode(200, tenantInfo);
        }
    }
}
