using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using notionclone.data.Abstract;
using notionclone.entity;

namespace notionclone.data.Concrete.EfCore
{
    public class SQLProductRepository : SQLGenericRepository<Product, NotionContext>, IProductRepository
    {
        public List<Product> GetSearchResult(string searchString)
        {
            using(var context = new NotionContext()){
                var products = context.Products.Where(i=>i.Name.Contains(searchString.ToLower())||i.Author.Contains(searchString.ToLower())).AsQueryable();             
                return products.ToList();
            }
        }
    }
}