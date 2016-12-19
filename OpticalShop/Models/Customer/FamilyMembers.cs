using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticalShop.Models.Customer
{
    public class FamilyMembers
    {
        public Family Family { get; set; }

        public List<FamilyMember> Familymembers { get; set; }
    }
}