using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using notionclone.webui.Models;

namespace notionclone.webui.Data
{
    public static class TemplateRepository
    {
        private static List<Template> _templates = null;
        static TemplateRepository(){
                _templates = new List<Template>(){
                    //değiştircez
                    new Template(){TemplateId=1,Name="Film",Description="Product"},
                    new Template(){TemplateId=2,Name="Books",Description="Product"},
                    new Template(){TemplateId=3,Name="Game",Description="Product"}
                };
        }
        public static List<Template> Templates{
            get{
                return _templates;
            }
        }
        public static void AddTemplate(Template template)
        {
            _templates.Add(template);
        }
        public static Template GetTemplateById(int id)
        {
            return _templates.FirstOrDefault(i=>i.TemplateId==id);
        }

    }
}