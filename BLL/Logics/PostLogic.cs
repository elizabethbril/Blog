using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.UnitOfWork;
using DAL.Entities;
using BLL.DTOs;
using BLL.Interfaces;
using AutoMapper;
using BLL.Ninject;
using DAL.Interfaces;

namespace BLL.Logics
{
    public class PostLogic: IPostLogic
    {
        IUnitOfWork UoW;
        public PostLogic(IUnitOfWork UoW)
        {
            PostLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostDTO, Post>();
                cfg.CreateMap<CommentsDTO, Comments>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<Comments, CommentsDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
            }).CreateMapper();
            this.UoW = UoW;
        }

        IMapper PostLogicMapper;


        public PostLogic()
        {
            PostLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PostDTO, Post>();
                cfg.CreateMap<CommentsDTO, Comments>();
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<Comments, CommentsDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
            }).CreateMapper();
            UoW = LogicDependencyResolver.ResolveUoW();
        }

        public void Add(PostDTO NewPost)
        {
            if (UserLogic.CurrentUser == null || UserLogic.CurrentUser.UserType != DTOs.UserType.Manager)
                throw new Exception("Function availible only for managers");
            UoW.Post.Add(PostLogicMapper.Map<PostDTO, Post>(NewPost));
        }

        public void DeletePost(int Id)
        {
            if (UserLogic.CurrentUser == null || UserLogic.CurrentUser.UserType != DTOs.UserType.Manager)
                throw new Exception("Function availible only for managers");
            UoW.Post.Delete(Id);
        }

        public void AddComment(int PostId, CommentsDTO NewComment)
        {
            if (UserLogic.CurrentUser == null || UserLogic.CurrentUser.UserType != DTOs.UserType.Manager)
                throw new Exception("Function availible only for managers");
            Post post = UoW.Post.GetAll(x => x.Id == PostId, x => x.Comments).FirstOrDefault();
            Comments comments = PostLogicMapper.Map<CommentsDTO, Comments>(NewComment);
            comments.Post = post;
            post.Comments.Add(comments);
            UoW.Post.Modify(post.Id, post);
        }

        //public void AddCategory(int PostId, CategoryDTO NewCategory)
        //{
        //    if (UserLogic.CurrentUser == null || UserLogic.CurrentUser.UserType != DTOs.UserType.Manager)
        //        throw new Exception("Function availible only for managers");
        //    Post post = UoW.Post.GetAll(x => x.Id == PostId, x => x.CategoryDetails).FirstOrDefault();
        //    Category category = PostLogicMapper.Map<CategoryDTO, Category>(NewCategory);
        //    category.Post = post;
        //    post.CategoryDetails.Add(category);
        //    UoW.Post.Modify(post.Id, post);
        //}
        public void EditPost(int Id, PostDTO Post)
        {
            if (UserLogic.CurrentUser == null || UserLogic.CurrentUser.UserType != DTOs.UserType.Manager)
                throw new Exception("Function availible only for managers");
            Post post = UoW.Post.Get(Id);
            post = PostLogicMapper.Map<PostDTO, Post>(Post);
            UoW.Post.Modify(Id, post);
        }

        public IEnumerable<PostDTO> SearchByTag(string Tag)
        {
            return PostLogicMapper.Map<IEnumerable<Post>, List<PostDTO>>(UoW.Post.GetAll(t => t.Tags == Tag));     
        }

        public IEnumerable<PostDTO> GetAll()
        {
            return PostLogicMapper.Map<IEnumerable<Post>, List<PostDTO>>(UoW.Post.GetAll());
        }

        public IEnumerable<PostDTO> FindByCategory(string SearchCategory)
        {
            return PostLogicMapper.Map<IEnumerable<Post>, List<PostDTO>>(UoW.Post.GetAll(t => t.CategoryName == SearchCategory));
        }


        //public void AddImage(int PostId, ImageDTO NewImage)
        //{
        //    if (UserLogic.CurrentUser == null || UserLogic.CurrentUser.UserType != DTOs.UserType.Manager)
        //        throw new Exception("Function availible only for managers");
        //    Post post = UoW.Post.GetAll(x => x.Id == PostId, x => x.Images).All();            
        //    Category category = PostLogicMapper.Map<CategoryDTO, Category>(NewCategory);
        //    category.Post = post;
        //    post.CategoryDetails.Add(category);
        //    UoW.Post.Modify(post.Id, post);
        //}
        
    }
}
