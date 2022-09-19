using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using notionclone.business.Abstract;

namespace notionclone.webui.ViewComponents
{
    public class TemplatesViewComponent:ViewComponent
    {
        private ITemplateService _templateService;
        public TemplatesViewComponent(ITemplateService templateService)
        {
            this._templateService = templateService;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTemplate = RouteData?.Values["id"];
            return View(_templateService.GetAll());

        }
    }
}