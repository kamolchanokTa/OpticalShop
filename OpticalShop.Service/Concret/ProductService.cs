using OpticalShop.Core.Domain;
using OpticalShop.Data;
using OpticalShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalShop.Service.Concret
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _productRepository;
        private IRepository<Lense> _lenseRepository;

        public ProductService(IRepository<Product> productRepository, IRepository<Lense> lenseRepository)
        {
            this._productRepository = productRepository;
            this._lenseRepository = lenseRepository;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = this._productRepository.Table.ToList();
            if (products == null)
                throw new NullReferenceException("Cannot find any products");
            return products;
        }

        public IEnumerable<Lense> GetLense()
        {
            var lenses = this._lenseRepository.Table.ToList();
            if (lenses == null)
                throw new NullReferenceException("Cannot find any lenses");
            return lenses;
        }

        public void InsertProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product");
            if (this._productRepository.Table.FirstOrDefault(m => m.Id == product.Id) != null)
                this._productRepository.Update(product);
            else
                this._productRepository.Insert(product);
        }

        public void InsertLense(Lense lense)
        {
            if (lense == null)
                throw new ArgumentNullException("lense");
            if (this._lenseRepository.Table.FirstOrDefault(m =>
                m.Id == lense.Id) != null)
                this._lenseRepository.Update(lense);
            else
                this._lenseRepository.Insert(lense);
        }

        public void DeleteProduct(string productId)
        {
            var product = this._productRepository.GetById(productId);
            if (product == null)
                throw new NullReferenceException("Cannot delete product id : " + product.Id);

            this._productRepository.Delete(product);
        }

        public void DeleteLense(string lenseId)
        {
            var lense = this._lenseRepository.GetById(lenseId);
            if (lenseId == null)
                throw new NullReferenceException("Cannot delete lenseId id : " + lense.Id);

            this._lenseRepository.Delete(lense);
        }
    }
}
