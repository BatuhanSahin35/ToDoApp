using System;
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
        private ITemplateService _templateService;
        public ProductController(IProductService productService,ITemplateService templateService)
        {
            this._productService = productService;
            this._templateService = templateService;
        }
       
        public IActionResult List(int id){
            var productViewModel = new ProductListViewModel()
            {
                Products = _productService.GetProductsByTemplate(id)
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
            ViewBag.Templates = _templateService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductModel model,int[] templateIds){
            var entity = new Product(){
                Name = model.Name,
                Author = model.Author,
                Evaluation = model.Evaluation,
                ImageUrl = model.ImageUrl
            };
            _productService.Create(entity);
            _productService.Create(entity,templateIds);
            return RedirectToAction("Index","Home");
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