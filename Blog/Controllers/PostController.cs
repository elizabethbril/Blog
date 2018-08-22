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
    public class PostController : ApiController
    {
        public PostController()
        {
            PostLogic = UIDependencyResolve<IPostLogic>.ResolveDependency();
        }
        public PostController(IPostLogic HotelLogic)
        {
            this.PostLogic = HotelLogic;
        }

        IPostLogic PostLogic;

        IMapper PostControllerMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PostDTO, PostModel>();
            cfg.CreateMap<CommentsDTO, CommentsModel>();
            cfg.CreateMap<CategoryDTO, CategoryModel>();
            cfg.CreateMap<PostModel, PostDTO>();
            cfg.CreateMap<CommentsModel, CommentsDTO>();
            cfg.CreateMap<CategoryModel, CategoryDTO>();
        }).CreateMapper();

        // GET api/<controller>
        public IEnumerable<PostModel> Get()
        {
            return PostControllerMapper.Map<IEnumerable<PostDTO>, IEnumerable<PostModel>>(PostLogic.GetAll());
        }

        // POST api/<controller>

        public void Post([FromBody]PostModel Post)
        {
            PostLogic.Add(PostControllerMapper.Map<PostModel, PostDTO>(Post));
        }

        // PUT api/<controller>/5
        public void Put(int PostId, [FromBody]CommentsModel Comments)
        {
            PostLogic.AddComment(PostId, PostControllerMapper.Map<CommentsModel, CommentsDTO>(Comments));
        }

        // PUT api/<controller>/5
        public void Put(int PostId, [FromBody]CategoryModel Category)
        {
            PostLogic.AddCategory(PostId, PostControllerMapper.Map<CategoryModel, CategoryDTO>(Category));
        }

        // PUT api/<controller>/5
        public void Put(int Id, [FromBody]PostModel Post)
        {
            PostLogic.EditPost(Id, PostControllerMapper.Map<PostModel, PostDTO>(Post));
        }

        // DELETE api/<controller>/5
        public void Delete(int Id)
        {
            PostLogic.DeletePost(Id);
        }
    }
}
