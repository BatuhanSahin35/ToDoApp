using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using notionclone.entity;

namespace notionclone.data.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        List<Product> GetSearchResult(string searchString);
    }
}