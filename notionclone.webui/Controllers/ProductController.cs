using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using notionclone.webui.Data;
using notionclone.webui.Models;

namespace notionclone.webui.Controllers
{
    public class ProductController:Controller
    {
        public IActionResult Details(int id){
            
            return View(ProductRepository.GetProductById(id));
        }
        public IActionResult List(int? id){
            var products=ProductRepository.Products;
            if(id!=null){
                products=products.Where(i=>i.TemplateId==id).ToList();
            }
            
            var model = new ProductViewModel(){
                
                Products=products
            };
            return View(model);
        }

        public IActionResult Index(){
            var product = new Product{Name = "matrix",Evaluation="this is a matrix",ImageUrl="resim"};
            // ViewData["Product"]=product;
            // ViewData["Template"] = "Films";
            // ViewBag.Product = product;
            ViewBag.Template = "Films";

            return View(product);
        }
        [HttpGet]
        public IActionResult Create(){
            
            return View(new Product());
        }
        [HttpPost]
        public IActionResult Create(Product p){
            if(ModelState.IsValid){
                ProductRepository.AddProduct(p);
                return RedirectToAction("List");
            }
            return View(p);

        }
        [HttpGet]
        public IActionResult Edit(int id){
            return View(ProductRepository.GetProductById(id));
        }
        [HttpPost]
        public IActionResult Edit(Product p){

            ProductRepository.EditProduct(p);
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Delete(int ProductId){
            ProductRepository.DeleteProduct(ProductId);
            return RedirectToAction("List");
        }
    }
}