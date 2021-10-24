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
