using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using notionclone.webui.Data;
using notionclone.webui.Models;

namespace notionclone.webui.ViewComponents
{
    public class TemplatesViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTemplate = RouteData?.Values["id"];
            return View(TemplateRepository.Templates);
        }
    }
}