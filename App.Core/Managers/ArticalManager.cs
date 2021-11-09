using App.Core.Models;
using App.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Managers
{
    public class ArticleManager
    {
        private readonly Protein4allContext _DbContext;
         public BaseRepo<Articals> ProductRepo;

        public ArticleManager(Protein4allContext DbContext)
        {
            
            _DbContext = DbContext;
            ProductRepo = new BaseRepo<Articals>(DbContext);
        }

        public IQueryable<Articals> GetAllArtical()
        {
            return ProductRepo.GetMany(null,X=>X.Category).OrderBy(x => x.DisplayOrder);
        }
        public IQueryable<Articals> GetArticals(int? CategoryId)
        {
            return ProductRepo.GetMany(X=>X.CategoryId==CategoryId, X => X.Category).OrderBy(x => x.DisplayOrder);
        }
        public void AddArtical(Articals Artical)
        {
            ProductRepo.Add(Artical);
        }
        public Articals GetOne(int Id)
        {
            return ProductRepo.GetOne(x => x.Id == Id);
        }
        public Articals GetArticleDetails(string Url)
        {
            return ProductRepo.GetOne(x=>x.Url == Url);
        }
        public void UpdateArtical(Articals Artical)
        {
            ProductRepo.Edit(Artical);
        }
        public void DeleteArtical(int Id)
        {
            ProductRepo.Delete(Id);
        }
    }
}
