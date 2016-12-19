using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpticalShop.Models.Bill
{
    public class BillViewModel
    {
        public List<BillModel> BillModels { get; set; }

        public DateTime? SearchStartDate { get; set; }

        [DataType(DataType.Text)]
        public string SearchStartDateText
        {
            get
            {
                return SearchStartDate.Value.ToShortDateString();
            }
            set
            {
                SearchStartDate = Convert.ToDateTime(value);
            }
        }

        public DateTime? SearchFinishDate { get; set; }

        [DataType(DataType.Text)]
        public string SearchFinishDateText
        {
            get
            {
                return SearchFinishDate.Value.ToShortDateString();
            }
            set
            {
                SearchFinishDate = Convert.ToDateTime(value);
            }
        }
    }
}