using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC01.Models
{
    // this class EmployeeDBContext, needs to match the name in the connectionStrings below
    // from the web.config file
    // <connectionStrings>
    //	<add name = "EmployeeDBContext">
    // </connectionStrings> 
    public class EmployeeDBContext : DbContext
    {
        public DbSet<EmployeeDB> Employees { get; set; }
    }
}