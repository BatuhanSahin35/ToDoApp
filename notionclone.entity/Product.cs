using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace notionclone.entity
{
    public class Product
    {
        public int ProductId { get; set; }


        public string Name { get; set; }

       public string Author { get; set; }


        public string Evaluation { get; set; }

        public string? Yorumlar { get; set; }

        public string ImageUrl { get; set; }

        public List<ProductTemplate> ProductTemplates { get; set; }
        
    }
}