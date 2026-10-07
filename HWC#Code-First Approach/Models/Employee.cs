using System;
using System.Collections.Generic;
using System.Text;

namespace HWC_Code_First_Approach.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int CompanyId { get; set; }
        // N : 1
        public Company Company { get; set; }

        // 1 : 1
        public EmployeeProfile Profile { get; set; }

        // N : N
        public ICollection<Project> Projects { get; set; }
    }
}
