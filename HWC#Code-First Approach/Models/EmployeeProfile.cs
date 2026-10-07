using System;
using System.Collections.Generic;
using System.Text;

namespace HWC_Code_First_Approach.Models
{
    public class EmployeeProfile
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int EmployeeId { get; set; }
        //1 : 1
        public Employee Employee { get; set; }
    }
}
