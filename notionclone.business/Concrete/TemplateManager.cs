using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using notionclone.business.Abstract;
using notionclone.data.Abstract;
using notionclone.entity;

namespace notionclone.business.Concrete
{
    public class TemplateManager : ITemplateService
    {
        private ITemplateRepository _templateRepository;
        public TemplateManager(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }
        public void Create(Template entity)
        {
            _templateRepository.Create(entity);
        }

        public void Delete(Template entity)
        {
            throw new NotImplementedException();
        }

        public List<Template> GetAll()
        {
            return _templateRepository.GetAll();
        }

        public Template GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Template entity)
        {
            throw new NotImplementedException();
        }
    }
}