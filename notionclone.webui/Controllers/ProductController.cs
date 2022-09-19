using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using notionclone.business.Abstract;
using notionclone.entity;
using notionclone.webui.Models;

namespace notionclone.webui.Controllers
{
    public class ProductController:Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
       
        public IActionResult List(){
            var productViewModel = new ProductListViewModel()
            {
                Products = _productService.GetAll()
            };

            return View(productViewModel);
        }

         public IActionResult Details(int id){
            if(id==null){
                return NotFound();
            }
            Product product = _productService.GetById((int)id);
            if(product==null){
                return NotFound();
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult CreateProduct(){
            
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductModel model){
            var entity = new Product(){
                Name = model.Name,
                Author = model.Author,
                Evaluation = model.Evaluation,
                ImageUrl = model.ImageUrl
            };
            _productService.Create(entity);
            return RedirectToAction("List");
        }


        [HttpGet]
        public IActionResult Edit(int? id){
            if(id==null){
                return NotFound();
            }
            var entity = _productService.GetById((int)id);
            if(entity==null){
                return NotFound();
            }
            var model = new ProductModel(){
                ProductId = entity.ProductId,
                Name = entity.Name,
                Author = entity.Author,
                Evaluation = entity.Evaluation,
                ImageUrl = entity.ImageUrl
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ProductModel model){

            var entity = _productService.GetById(model.ProductId);
            if(entity==null){
                return NotFound();
            }
            entity.Name = model.Name;
            entity.Author = model.Author;
            entity.Evaluation = model.Evaluation;
            entity.ImageUrl = model.ImageUrl;
            _productService.Update(entity);

            return RedirectToAction("List");
        }


        [HttpPost]
        public IActionResult Delete(int ProductId){
            var entity = _productService.GetById(ProductId);

            if(entity!=null){
                _productService.Delete(entity);
            }
            
            return RedirectToAction("List");
        }

        public IActionResult Search(string q){
            var productViewModel = new ProductListViewModel()
            {
                Products = _productService.GetSearchResult(q)
            };

            return View(productViewModel);
        }
    }
}