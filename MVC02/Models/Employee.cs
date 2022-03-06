using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC02.Models
{
    [Table("[tblEmployee2]")]
    public class Employee
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }

        //[ForeignKey("DepartmentId")]
        //public List<Department> Department { get; set; }

        public int DepartmentId { get; set; }
    }
   
}