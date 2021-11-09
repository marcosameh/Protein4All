using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.Models;
using App.Core.Repositories;

namespace App.Core.Managers
{
    
    public class ArticleCategoryManager
    {
       
        public BaseRepo<ArticleCategory> ArticleCategoryRepo;
        private  Protein4allContext _Protein4AllContext { get; }
        public ArticleCategoryManager( Protein4allContext protein4AllContext)
        {
            
            _Protein4AllContext = protein4AllContext;
            ArticleCategoryRepo = new BaseRepo<ArticleCategory>(protein4AllContext);
        }
        public IQueryable<ArticleCategory> GetAllCategories()
        {
            return ArticleCategoryRepo.GetAll().OrderBy(x=>x.DisplayOrder);
        }
        public IQueryable<ArticleCategory> GetActiveCategories()
        {
            return ArticleCategoryRepo.GetMany(null,x=>x.Articals).OrderBy(x => x.DisplayOrder);
        }
        public void AddCategory(ArticleCategory category)
        {
            ArticleCategoryRepo.Add(category);
        }
        public ArticleCategory GetOne(int Id)
        {
            return ArticleCategoryRepo.GetOne(x => x.Id == Id);
        }
        public void UpdateCategory(ArticleCategory category)
        {
            ArticleCategoryRepo.Edit(category);
        }
        public void DeleteCategory(int Id)
        {
            ArticleCategoryRepo.Delete(Id);
        }

    }
}
