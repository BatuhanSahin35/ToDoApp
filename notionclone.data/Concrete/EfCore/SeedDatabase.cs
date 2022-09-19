using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using notionclone.entity;

namespace notionclone.data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new NotionContext();
            if(context.Database.GetPendingMigrations().Count()==0)
            {
                if(context.Templates.Count()==0)
                {
                    context.Templates.AddRange(Templates);
                }
                if(context.Products.Count()==0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductTemplates);
                }
            }
            context.SaveChanges();
        }
        private static Template[] Templates={
            new Template(){Name="Books",Description="Product"},
            new Template(){Name="Movies",Description="Movies"},
            new Template(){Name="Music",Description="Music"},
        };
        private static Product[] Products={
            new Product(){Name="Suç ve Ceza",Author="Dostoyevski",Evaluation="iyi kitap",Yorumlar="yorum sayfası 1",ImageUrl="suc-ve-ceza.jpg"},
            new Product(){Name="1984",Author="George Orwell",Evaluation="iyi kitap",Yorumlar="yorum sayfası 2",ImageUrl="1984.jpg"},
            new Product(){Name="Dava",Author="Franz Kafka",Evaluation="iyi kitaptır",Yorumlar="yorum sayfası 3",ImageUrl="dava.jpg"},

        };

        private static ProductTemplate[] ProductTemplates={
            new ProductTemplate(){Product=Products[0],Template=Templates[0]},
            new ProductTemplate(){Product=Products[1],Template=Templates[0]},
            new ProductTemplate(){Product=Products[2],Template=Templates[0]}
        };
    }
}