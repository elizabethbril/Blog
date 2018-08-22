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
    public class CategoryController : ApiController
    {
        public CategoryController()
        {
            PostLogic = UIDependencyResolve<IPostLogic>.ResolveDependency();
            CategoryControllerMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostDTO, PostModel>();
                cfg.CreateMap<CommentsDTO, CommentsModel>();
                cfg.CreateMap<CategoryDTO, CategoryModel>();
                cfg.CreateMap<PostModel, PostDTO>();
                cfg.CreateMap<CommentsModel, CommentsDTO>();
                cfg.CreateMap<CategoryModel, CategoryDTO>();
            }).CreateMapper();
        }
        IPostLogic PostLogic;

        IMapper CategoryControllerMapper;

      
        public void Post([FromBody]CategoryModel Category)
        {
            int PostId = Category.PostId;
            Category.PostId = new int();
            PostLogic.AddCategory(PostId, CategoryControllerMapper.Map<CategoryModel, CategoryDTO>(Category));
        }
       
    }
}