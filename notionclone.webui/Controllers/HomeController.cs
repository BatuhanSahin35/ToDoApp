using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using notionclone.webui.Data;
using notionclone.webui.Models;

namespace notionclone.webui.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index(int? id){

            var products=ProductRepository.Products;
            if(id!=null){
                products=products.Where(i=>i.TemplateId==id).ToList();
            }



            var model = new ProductViewModel(){
                
                Products=products
            };
            return View(model);
        }
        
    }
}