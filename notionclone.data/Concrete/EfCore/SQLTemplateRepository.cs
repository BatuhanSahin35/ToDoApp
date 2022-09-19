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
        
    }
}