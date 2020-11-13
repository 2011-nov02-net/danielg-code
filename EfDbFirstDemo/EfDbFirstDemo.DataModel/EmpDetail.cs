using System;
using System.Collections.Generic;

#nullable disable

namespace EfDbFirstDemo.DataModel
{
    public partial class EmpDetail
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public int Salary { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual Employee1 Employee { get; set; }
    }
}
