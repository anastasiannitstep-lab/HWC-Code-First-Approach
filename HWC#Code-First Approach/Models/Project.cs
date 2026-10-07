using System;
using System.Collections.Generic;
using System.Text;

namespace HWC_Code_First_Approach.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // N : N
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
