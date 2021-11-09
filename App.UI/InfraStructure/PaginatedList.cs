using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.UI.InfraStructure
{
    public class PaginatedList<T>:List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginatedList(List<T> Items,int PageIndex,int PageSize,int Count)
        {
            this.PageIndex = PageIndex;
            TotalPages = (int)Math.Ceiling(Count /(double)PageSize);
            this.AddRange(Items);
        }

        public bool PerviousPage
        {
            get { return (PageIndex > 1); }
        }
        public bool NextPage
        {
            get { return (PageIndex < TotalPages); }
        }
        public static PaginatedList<T> GetData(IQueryable<T>Source,int PageIndex ,int PageSize)
        {
            var count =Source.Count();
            var Itmes = Source.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            return new PaginatedList<T>(Itmes,PageIndex,PageSize,count);
        }
    }
}
