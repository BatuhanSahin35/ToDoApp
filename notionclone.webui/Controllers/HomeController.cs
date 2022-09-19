using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using notionclone.business.Abstract;
using notionclone.data.Abstract;

namespace notionclone.webui.Controllers
{
    public class HomeController:Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            this._productService = productService;
        }
        public IActionResult Index(int? id){

            //  var products=ProductRepository.Products;
            //  if(id!=null){
            //      products=products.Where(i=>i.TemplateId==id).ToList();
            //  }



            //  var model = new ProductViewModel(){
                
            //      Products=products
            //  };
            // var productViewModel = new ProductListViewModel()
            // {
            //     Products = _productService.GetAll()
            // };
            // return View(productViewModel);
            return View();
        }
        
    }
}