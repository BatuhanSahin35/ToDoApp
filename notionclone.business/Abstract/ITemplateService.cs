using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using notionclone.entity;

namespace notionclone.business.Abstract
{
    public interface ITemplateService
    {
        Template GetById(int id);
        List<Template> GetAll();
        void Create(Template entity);
        void Update(Template entity);
        void Delete(Template entity);
    }
}