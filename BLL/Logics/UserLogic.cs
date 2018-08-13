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
    public class UserLogic: IUserLogic
    {
        static UserLogic()
        {
            CurrentUser = null;
        }

        IUnitOfWork UoW;

        public UserLogic(IUnitOfWork UoW)        
        {
            UserLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<PostDTO, Post>();
                cfg.CreateMap<Page, PageDTO>();
                cfg.CreateMap<PageDTO, Page>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<CommentsDTO, Comments>();
                cfg.CreateMap<Comments, CommentsDTO>();
                cfg.CreateMap<ImageDTO, Image>();
                cfg.CreateMap<Image, ImageDTO>();

            }).CreateMapper();
            this.UoW = UoW;
            PostToDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
            }).CreateMapper();
        }


        IMapper UserLogicMapper;        
        IMapper PostToDTO;
        public static UserDTO CurrentUser;
   
        public UserLogic()
        {
            UserLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<PostDTO, Post>();
                cfg.CreateMap<Page, PageDTO>();
                cfg.CreateMap<PageDTO, Page>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<CommentsDTO, Comments>();
                cfg.CreateMap<Comments, CommentsDTO>();
                cfg.CreateMap<ImageDTO, Image>();
                cfg.CreateMap<Image, ImageDTO>();
            }).CreateMapper();
            PostToDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
            }).CreateMapper();
            UoW = LogicDependencyResolver.ResolveUoW();
        }

        public void AddUser(UserDTO NewUser)
        {
            if (UoW.Users.GetAll(u => u.Login == NewUser.Login).Count() != 0)
                throw new Exception("Entered login is already taken");
            UoW.Users.Add(UserLogicMapper.Map<UserDTO, User>(NewUser));
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            //UoW.DeleteDB();
            return UserLogicMapper.Map<IEnumerable<User>, List<UserDTO>>(UoW.Users.GetAll());
        }
       
        public UserDTO GetUser(int Id)
        {
            return UserLogicMapper.Map<User, UserDTO>(UoW.Users.GetAll(u => u.Id == Id).FirstOrDefault());
        }

        public void DeleteUser(int Id)
        {
            UoW.Users.Delete(Id);
        }

        public void EditUser(int Id, UserDTO User)
        {
            UoW.Users.Modify(Id, UserLogicMapper.Map<UserDTO, User>(User));
        }

        public UserDTO Login(string Login, string Password)
        {
            UserDTO user = UserLogicMapper.Map<User, UserDTO>(UoW.Users.GetAll(u => u.Login == Login && u.Password == Password).FirstOrDefault());
            if (user == null)
                throw new Exception("Invalid login or password");
            CurrentUser = user;
            return user;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public void AddComment(int UserId, int PostId, CommentsDTO comment)
        {
            if (CurrentUser == null)
                throw new Exception("Login to left a comment");
            Post post = UoW.Post.GetAll(x => x.Id == PostId, x => x.Comments).FirstOrDefault();
            Comments comments = UserLogicMapper.Map<CommentsDTO, Comments>(comment);
            comments.Post = post;
            post.Comments.Add(comments);
            UoW.Post.Modify(post.Id, post);
        }


        
    }
}
