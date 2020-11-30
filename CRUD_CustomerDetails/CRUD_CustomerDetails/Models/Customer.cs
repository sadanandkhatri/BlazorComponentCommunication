using System;
using System.Collections.Generic;

namespace CRUD_CustomerDetails.Models
{
    public partial class Customer
    {
        public int CustId { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string InsuranceType { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
    }
}
