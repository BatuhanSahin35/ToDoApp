using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public List<Product> GetProductsByCategory(int id)
        {
            using(var context = new NotionContext()){
                var products = context.Products.AsQueryable()
                                                .Include(i=>i.ProductTemplates)
                                                .ThenInclude(i=>i.Template)
                                                .Where(i=>i.ProductTemplates.Any(a=>a.TemplateId==id));
                return products.ToList();
            }
        }

        public void Create(Product entity, int[] templateIds)
        {
            using(var context = new NotionContext()){
                var product = context.Products.Include(i=>i.ProductTemplates).FirstOrDefault(i=>i.ProductId==entity.ProductId);

                if(product!=null){
                    product.Name=entity.Name;
                    product.Author=entity.Author;
                    product.Evaluation=entity.Evaluation;
                    product.ImageUrl=entity.ImageUrl;

                    product.ProductTemplates = templateIds.Select(catId => new ProductTemplate(){
                        ProductId = entity.ProductId,
                        TemplateId = catId
                    }).ToList();
                    context.SaveChanges();
                }
            }
        }
    }
}