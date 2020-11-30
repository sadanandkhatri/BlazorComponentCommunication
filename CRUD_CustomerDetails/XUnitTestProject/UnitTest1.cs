using System;
using Xunit;
using CRUD_CustomerDetails.DataAccess;
using CRUD_CustomerDetails.Models;
using System.Collections.Generic;
using System.Linq;
using CRUD_CustomerDetails.Controllers;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        DACustomers dataCust = new DACustomers();
        CustomerController _controller = new CustomerController();
        [Fact]
        public void Test1()
        {
            var list = dataCust.GetAllCustomer();
            Assert.IsType<List<Customer>>(list);
            Assert.Equal(3, list.Count());
        }

        [Fact]
        public void Test2()
        {
            bool result = _controller.PostCustomer(new Customer()
            {
                FullName = "XYZ",
                Mobile = "9823768280",
                Age = 22,
                Gender = "Female",
                InsuranceType = "Life Insurance"
            });
            Assert.True(result);
        }

        [Fact]
        public void Test3()
        {
            int custId = dataCust.FindCustId("XYZ");
            bool result = _controller.DeleteCustomer(custId);
            Assert.True(result);
        }
    }
}
