using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using notionclone.business.Abstract;
using notionclone.data.Abstract;
using notionclone.entity;

namespace notionclone.webui.Controllers
{
    public class HomeController:Controller
    {
        private ITemplateService _templateService;
        public HomeController(ITemplateService templateService)
        {
            this._templateService = templateService;
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
        [HttpGet]
        public IActionResult AddTemplate(){
            return View();
        }
        [HttpPost]
        public IActionResult AddTemplate(Template t){
            var entity = new Template(){
                Name = t.Name,
                Description = t.Description
            };
            _templateService.Create(entity);
            return RedirectToAction("Index");
        }
        
    }
}