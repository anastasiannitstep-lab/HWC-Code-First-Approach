using System;
using System.Collections.Generic;
using System.Text;

namespace HWC_Code_First_Approach.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // 1 : N
        public ICollection<Employee>? Employees { get; set; }
    }
}
