using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_CustomerDetails.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace CRUD_CustomerDetails.DataAccess
{
    public class DACustomers
    {
        Customer_DetailsContext dbcontext = new Customer_DetailsContext();

        public int FindCustId(string name)
        {
            var cust = dbcontext.Customer.First(s => s.FullName == name);
            return cust.CustId;
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
           
            try
            {
                return dbcontext.Customer.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool createcustomer(Customer customer)
        {
            bool result = false;
            try
            {
                Customer newcust = new Customer();
                newcust.FullName = customer.FullName;
                newcust.CustId = customer.CustId;
                newcust.InsuranceType = customer.InsuranceType;
                newcust.Gender = customer.Gender;
                newcust.Mobile = customer.Mobile;
                newcust.Age = customer.Age;
                dbcontext.Customer.Add(newcust);
                dbcontext.SaveChanges();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool updatecustomer(int id, Customer customer)
        {
            bool result = false;
            if (id != customer.CustId)
            {
                return result;
            }
            try
            {

                dbcontext.Customer.Update(customer);
                dbcontext.SaveChanges();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public bool DeleteCustomer(int id)
        {
            bool result = false;
            try
            {
                Customer customer = dbcontext.Customer.Find(id);
                if (customer == null)
                {
                    return result;
                }
                dbcontext.Remove(customer);
                dbcontext.SaveChanges();
                result = true;
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
