using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace notionclone.entity
{
    public class ProductTemplate
    {
        public int TemplateId { get; set; }
        public Template Template { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}