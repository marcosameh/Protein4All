using App.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Repositories
{
    public class CategoryRepo : BaseRepo<ProductCategory> 
    {
        public CategoryRepo(Protein4allContext DbContext):base(DbContext)
        {
            
        }
        public void Update(ProductCategory newcategory)
        {
            var OldCategory = this.GetOne(x => x.Id == newcategory.Id);
            OldCategory.IsActive = newcategory.IsActive;
            OldCategory.Name = newcategory.Name;
            Save();
            
        }
    }
}
