using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevelopmentPractice.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0)
                {
                    age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Age cannot be negative");
                }
            }
        }


        public String FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
