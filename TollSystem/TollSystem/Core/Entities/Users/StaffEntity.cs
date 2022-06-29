using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Entities
{
    public class StaffEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public Credentials Credentials { get; set; }


        public StaffEntity()
        {

        }

        public StaffEntity(string firstName, string lastName, double salary, Credentials credentials)
        {
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
            Credentials = credentials;
        }


        public StaffEntity(Staff staff)
        {
            FirstName = staff.Firstname;
            LastName = staff.Lastname;
            Salary = (double)staff.Salary;
            Credentials = new Credentials(staff.Username, staff.Password);
        }
    }
}
