using App.Core.Models;
using App.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Managers
{
    public class ProductManager
    {
        private readonly Protein4allContext _DbContext;
         public BaseRepo<Product> ProductRepo;

        public ProductManager(Protein4allContext DbContext)
        {
            
            _DbContext = DbContext;
            ProductRepo = new BaseRepo<Product>(DbContext);
        }

        public IQueryable<Product> GetAllProduct()
        {
            return ProductRepo.GetMany(null,x=>x.Category).OrderBy(x => x.DisplayOrder);
        }
        public IQueryable<Product> GetActiveProduct()
        {
            return ProductRepo.GetMany(x => x.IsActive,x => x.Category).OrderBy(x => x.DisplayOrder);
        }
        public IQueryable<Product> GetProduct(int? CategoryId)
        {
            return ProductRepo.GetMany(x=>x.CategoryId==CategoryId.Value, x => x.Category).OrderBy(x => x.DisplayOrder);
        }
        public Product GetProduct(string Url)
        {
            return ProductRepo.GetOne(x => x.Url == Url, x => x.Category);
        }
        public IQueryable<Product> GetRelatedProduct(Product product)
        {
            return ProductRepo.GetMany(x => x.Id != product.Id && x.IsActive && x.CategoryId == product.CategoryId).OrderBy(x => x.DisplayOrder);
        }
        public IQueryable<Product> GetProductByName(string name)
        {
            return ProductRepo.GetMany(x => x.Title.Contains(name), x => x.Category).OrderBy(x => x.DisplayOrder);
        }
        public IQueryable<Product> SearchProducts(int CategoryId,String name)
        {
            return ProductRepo.GetMany(x => x.CategoryId==CategoryId&& x.Title.Contains(name), x => x.Category).OrderBy(x => x.DisplayOrder);
        }


        // }
        public void AddProduct(Product product)
        {
            ProductRepo.Add(product);
        }
        public Product GetOne(int Id)
        {
            return ProductRepo.GetOne(x => x.Id == Id);
        }
        public void UpdateProduct(Product product)
        {
            ProductRepo.Edit(product);
        }
        public void DeleteProduct(int Id)
        {
            ProductRepo.Delete(Id);
        }
    }
}
