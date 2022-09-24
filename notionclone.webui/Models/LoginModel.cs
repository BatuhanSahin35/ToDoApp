using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace notionclone.webui.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username alanı boş geçilemez")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password alanı boş geçilemez")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}