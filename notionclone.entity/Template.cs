using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace notionclone.entity
{
    public class Template
    {
        public int TemplateId { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductTemplate> ProductTemplates { get; set; }
    }
}