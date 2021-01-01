using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public bool Hired { get; set; }
    }
}
