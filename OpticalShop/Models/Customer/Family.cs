using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpticalShop.Models.Customer
{
    public class Family
    {
        [Required]
        [DisplayName("Family Name")]
        public string FamilyName { get; set; }

        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Telephone Number")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Telephone numver must be number")]
        public string Tel { get; set; }
    }
}