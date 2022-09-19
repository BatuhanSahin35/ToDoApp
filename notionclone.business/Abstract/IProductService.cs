using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using notionclone.entity;
namespace notionclone.business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        List<Product> GetAll();
        List<Product> GetSearchResult(string searchString);
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
    }
}