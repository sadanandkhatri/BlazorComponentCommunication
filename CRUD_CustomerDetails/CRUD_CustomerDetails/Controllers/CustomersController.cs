//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using CRUD_CustomerDetails.Models;

//namespace CRUD_CustomerDetails.Controllers
//{
   
//    [Route("api/[controller]")]
//    [ApiController]
    
    
//    public class CustomersController : ControllerBase
//    {
       
//        private readonly Customer_DetailsContext _context;

//        public CustomersController(Customer_DetailsContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Customers
//        //[HttpGet]
//        //public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
//        //{
//        //    return await _context.Customers.ToListAsync();
//        //}

    

//        // PUT: api/Customers/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutCustomer(int id, Customer customer)
//        {
//            if (id != customer.CustId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(customer).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!CustomerExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Customers
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
//        {
            
//            _context.Customers.Add(customer);
//            await _context.SaveChangesAsync();
//            //var apiVersion = version.ToString();
//            return CreatedAtAction("GetCustomer", new { id = customer.CustId }, customer);
//        }

//        // DELETE: api/Customers/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
//        {
//            var customer = await _context.Customers.FindAsync(id);
//            if (customer == null)
//            {
//                return NotFound();
//            }

//            _context.Customers.Remove(customer);
//            await _context.SaveChangesAsync();

//            return customer;
//        }

//        private bool CustomerExists(int id)
//        {
//            return _context.Customers.Any(e => e.CustId == id);
//        }
//    }
//}
