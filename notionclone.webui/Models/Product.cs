using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace notionclone.webui.Models
{
    public class Product
    {

        
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Evaluation { get; set; }

        public string Yorumlar { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        
        [Required]
        public int? TemplateId { get; set; }
    }
}