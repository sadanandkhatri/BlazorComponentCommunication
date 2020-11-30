using CRUD_CustomerDetails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_CustomerDetails.DataAccess;

namespace CRUD_CustomerDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        DACustomers dbobj = new DACustomers();
        //GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return dbobj.GetAllCustomer();
        }

        [HttpPost]
        public bool PostCustomer(Customer customer)
        {
            return dbobj.createcustomer(customer);
        }

        [HttpPut("{id}")]
        public bool PutCustomer(int id, Customer customer)
         {
            return dbobj.updatecustomer(id, customer);
         }

        [HttpDelete("{id}")]
        public bool DeleteCustomer(int id)
        {
            return dbobj.DeleteCustomer(id);
        }
    }
}
