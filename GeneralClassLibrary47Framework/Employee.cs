using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralClassLibrary47Framework
{
    //public class Employee
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public string Gender { get; set; }
    //    public string City { get; set; }
    //    public DateTime DateOfBirth { get; set; }
    //}

    // To set the fields mandatory on form
    //public class Employee
    //{
    //    public int ID { get; set; }
    //    [Required]
    //    public string Name { get; set; }
    //    [Required]
    //    public string Gender { get; set; }
    //    [Required]
    //    public string City { get; set; }
    //    public DateTime? DateOfBirth { get; set; }
    //}


    // Part 21 include properties using the Bind, remove the atrribute Required for Name
    // To set the fields mandatory on form
    //public class Employee
    //{
    //    public int ID { get; set; }

    //    public string Name { get; set; }
    //    [Required]
    //    public string Gender { get; set; }
    //    [Required]
    //    public string City { get; set; }
    //    public DateTime? DateOfBirth { get; set; }
    //}

    // Part 22 Including and Excluding properties using Interfaces
    public interface IEmployee
    {
        int ID { get; set; }
        string Name { get; set; }
        string Gender { get; set; }
        string City { get; set; }
        DateTime? DateOfBirth { get; set; }
    }

    public class Employee : IEmployee
    {
        public int ID { get; set; }

        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
