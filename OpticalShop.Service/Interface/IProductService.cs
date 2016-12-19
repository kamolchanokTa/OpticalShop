using OpticalShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalShop.Service.Interface
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();

        IEnumerable<Lense> GetLense();

        void InsertProduct(Product product);

        void InsertLense(Lense lense);

        void DeleteProduct(string productId);

        void DeleteLense(string lenseId);

    }
}
