using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalShop.Core.Domain
{
    public class Product : EntityBase
    {
        public ICollection<Lense> _lenseItems;
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string LenseId { get; set; }
        public double Sph { get; set; }

        public double Cyl { get; set; }

        public double Axis { get; set; }

        public double Add { get; set; }
        public string Coating { get; set; }
        public string Tint { get; set; }
        public string ProductImage { get; set; }
        public int    InStock { get; set; }

        public virtual ICollection<Lense> LenseItems
        {
            get { return _lenseItems ?? (_lenseItems = new List<Lense>()); }
            set { _lenseItems = value; }
        }
    }
}
