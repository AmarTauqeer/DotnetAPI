using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAPI.Models
{
    public class UserComplete
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public bool Active { get; set; }
        
        public UserComplete()
        {
            if (FirstName == null)
            {
                FirstName="";
            }
            if (LastName == null)
            {
                LastName="";
            }
            if (Email == null)
            {
                Email="";
            }
            if (Gender == null)
            {
                Gender="";
            }
            if (JobTitle == null)
            {
                JobTitle="";
            }
            if (Department == null)
            {
                Department="";
            }
        }
    }
}