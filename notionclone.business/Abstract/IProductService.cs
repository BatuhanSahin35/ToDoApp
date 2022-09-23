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
        List<Product> GetProductsByTemplate(int id);
        void Create(Product entity);
        void Create(Product entity,int[] templateIds);
        void Update(Product entity);
        void Delete(Product entity);
    }
}