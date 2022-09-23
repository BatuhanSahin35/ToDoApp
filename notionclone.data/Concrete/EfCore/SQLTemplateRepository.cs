using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using notionclone.data.Abstract;
using notionclone.entity;

namespace notionclone.data.Concrete.EfCore
{
    public class SQLTemplateRepository : SQLGenericRepository<Template,NotionContext>,ITemplateRepository
    {
        //get template id when creating a product
        // public int GetTemplateId(int id){
        //     using(var context = new NotionContext()){
        //         var template = context.Templates.Where(i=>i.TemplateId==id).FirstOrDefault();
        //         return template.TemplateId;
        //     }
        // }
    }
}