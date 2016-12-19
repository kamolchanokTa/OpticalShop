using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalShop.Core.Domain
{
    public class Customer : EntityBase
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string Tel { get; set; }
        public string Mobile { get; set; }
        public string Allergy { get; set; }
        public string LeftSph { get; set; }
        public string LeftCyl { get; set; }
        public string LeftAxis { get; set; }
        public string LeftAdd { get; set; }
        public string RightSph { get; set; }
        public string RightCyl { get; set; }
        public string RightAxis { get; set; }
        public string RightAdd { get; set; }
        public string PD { get; set; }
        public string PH { get; set; }
        public string Prism { get; set; }
}
}
