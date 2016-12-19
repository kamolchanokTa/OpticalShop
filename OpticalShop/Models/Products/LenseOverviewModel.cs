using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticalShop.Models.Products
{
    public class LenseOverviewModel
    {
        public string SelectedBrand { get; set; }

        public List<SelectListItem> Brands { get; set; }

        public List<LenseModel> Lenses { get; set; }

        public List<SelectListItem> FamiliesLense { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public List<SelectListItem> Process { get; set; }

        public List<SelectListItem> Indexs { get; set; }

        public List<SelectListItem> Materials { get; set; }

        public List<SelectListItem> Chromatics { get; set; }

        public string SelectedFamiliesLense { get; set; }

        public string SelectedCategories { get; set; }

        public string SelectedProcess { get; set; }

        public string SelectedIndexs { get; set; }

        public string SelectedMaterials { get; set; }

        public string SelectedChromatics { get; set; }

        public LenseModel Lense { get; set; }

        public int InStock { get; set; }
    }
}