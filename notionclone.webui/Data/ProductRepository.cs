using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using notionclone.webui.Models;

namespace notionclone.webui.Data
{
    public class ProductRepository
    {
        private static List<Product> _products = null;

        static ProductRepository()
        {
            _products = new List<Product>{
                new Product{ProductId=1,Name="Suç ve Ceza",Author="Dostoyevski",Evaluation="5 Star",Yorumlar="Harika bir kitap",ImageUrl="suc-ve-ceza.jpg",TemplateId=2},
                new Product{ProductId=2,Name="Dava",Author="Franz Kafka",Evaluation="Didn't Read",Yorumlar="Okumadığım bir kitap",ImageUrl="dava.jpg",TemplateId=2},
                new Product{ProductId=3,Name="1984",Author="George Orwell",Evaluation="Great Book",Yorumlar="Süper bir kitap",ImageUrl="1984.jpg",TemplateId=2},
                new Product{ProductId=2,Name="DavaF",Author="Franz Kafka",Evaluation="Didn't Read",Yorumlar="Okumadığım bir kitap",ImageUrl="dava.jpg",TemplateId=1},
                new Product{ProductId=3,Name="1984S",Author="George Orwell",Evaluation="Great Book",Yorumlar="Süper bir kitap",ImageUrl="1984.jpg",TemplateId=3}
            };
        }
        public static List<Product> Products{
            get {
                return _products;
            }        
        }
        public static void AddProduct(Product product)
        {
            _products.Add(product);
        }
        public static void EditProduct(Product product)
        {
            foreach (var p in _products)
            {
                if(p.ProductId==product.ProductId){
                    p.Name=product.Name;
                    p.Author=product.Author;
                    p.Evaluation=product.Evaluation;
                    p.Yorumlar=product.Yorumlar;
                    p.ImageUrl=product.ImageUrl;
                    p.TemplateId=product.TemplateId;
                }
            }
        }
        public static void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if(product!=null){
                _products.Remove(product);
            }
        }
        public static Product GetProductById(int id)
        {
            return _products.FirstOrDefault(i=>i.ProductId==id);
        }
    }
}