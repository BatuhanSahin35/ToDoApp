using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using notionclone.business.Abstract;
using notionclone.data.Abstract;
using notionclone.data.Concrete.EfCore;
using notionclone.entity;

namespace notionclone.business.Concrete
{
    public class ProductManager : IProductService
    {

        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            _productRepository=productRepository;
        }
        public void Create(Product entity)
        {
            _productRepository.Create(entity);
        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public List<Product> GetSearchResult(string searchString)
        {
            return _productRepository.GetSearchResult(searchString);
        }

        public void Update(Product entity)
        {
            
            _productRepository.Update(entity);
        }
    }
}