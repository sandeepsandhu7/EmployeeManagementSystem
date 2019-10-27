﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Model
{
    public class EmployeeModel//These properties are used for mapping the data from models
    {
        public int ID { get; set; }
        public int tblJobID { get; set; }
        public int tblDepartment { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public string JobName { get; set; }
        public string DepartmentName { get; set; }
    }
}
