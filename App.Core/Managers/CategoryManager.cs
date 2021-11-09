using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Models;
using App.Core.Repositories;

namespace App.Core.Managers
{
    
    public class CategoryManager
    {
        private CategoryRepo _CategoryRepo;
        private  Protein4allContext _Protein4AllContext { get; }
        public CategoryManager( Protein4allContext protein4AllContext)
        {
            
            _Protein4AllContext = protein4AllContext;
            _CategoryRepo = new CategoryRepo(protein4AllContext);
        }
        public IQueryable<ProductCategory> GetAllCategories()
        {
            return _CategoryRepo.GetAll().OrderBy(x=>x.DisplayOrder);
        }
        public IQueryable<ProductCategory> GetActiveCategories()
        {
            return _CategoryRepo.GetMany(x=>x.IsActive,x=>x.Product).OrderBy(x => x.DisplayOrder);
        }
        public void AddCategory(ProductCategory category)
        {
             _CategoryRepo.Add(category);
        }
        public ProductCategory GetOne(int Id)
        {
            return _CategoryRepo.GetOne(x => x.Id == Id);
        }
        public void UpdateCategory(ProductCategory category)
        {
           _CategoryRepo.Edit(category);
        }
        public void DeleteCategory(int Id)
        {
            _CategoryRepo.Delete(Id);
        }

    }
}
