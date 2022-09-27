using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace notionclone.webui.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage="Name zorunlu bir alan.")]  
        public string Name { get; set; }
        [Required(ErrorMessage="Author zorunlu bir alan.")]
       public string Author { get; set; }
        [Required(ErrorMessage="Evaluation zorunlu bir alan.")]
        public string Evaluation { get; set; }

        public string Yorumlar { get; set; }
        [Required(ErrorMessage="ImageUrl zorunlu bir alan.")]
        public string ImageUrl { get; set; }
    }
}