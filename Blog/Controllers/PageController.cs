using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BLL.DTOs;
using Blog.Models;
using AutoMapper;
using BLL.Interfaces;
using Blog.Ninject;

namespace Blog.Controllers
{
    public class PageController : ApiController
    {
        public PageController()
        {
            this.PageLogic = UIDependencyResolve<IPageLogic>.ResolveDependency();
        }
        public PageController(IPageLogic PageLogic)
        {
            this.PageLogic = PageLogic;
        }

        IPageLogic PageLogic;

        IMapper PageControllerMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PageDTO, PageModel>();
            cfg.CreateMap<PageModel, PageDTO>();
            cfg.CreateMap<PostModel, PostDTO>();
            cfg.CreateMap<PostDTO, PostModel>();           
        }).CreateMapper();

        // GET api/<controller>
        public IEnumerable<PageModel> Get()
        {
            return PageControllerMapper.Map<IEnumerable<PageDTO>, IEnumerable<PageModel>>(PageLogic.PageIEnum());
        }

        // POST api/<controller>
        public void Post([FromBody]PageModel Page)
        {
            PageLogic.Add(PageControllerMapper.Map<PageModel, PageDTO>(Page));
        }

        // DELETE api/<controller>/5
        public void Delete(int Id)
        {
            PageLogic.DeletePage(Id);            
        }

    }
}
