using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace notionclone.webui.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage="Kullanıcı adı boş geçilemez")]
        public string FirstName { get; set; }
        [Required(ErrorMessage="Kullanıcı soyadı boş geçilemez")]
        public string LastName { get; set; }
        [Required(ErrorMessage="Username boş geçilemez")]
        public string UserName { get; set; }
        [Required(ErrorMessage="Email boş geçilemez")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage="Şifre boş geçilemez")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage="Şifre tekrarı boş geçilemez")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage="Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}