using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC02.Models
{
    // this class EmployeeContext, needs to match the name in the connectionStrings below
    // from the web.config file
    // <connectionStrings>
    //	<add name = "EmployeeDBContext">
    // </connectionStrings> 
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}