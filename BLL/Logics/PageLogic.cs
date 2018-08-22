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
    public class PageLogic: IPageLogic
    {
        IUnitOfWork UoW;

        public PageLogic(IUnitOfWork UoW)
        {
            PageLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PageDTO, Page>();
                cfg.CreateMap<Page, PageDTO>();
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<PostDTO, PostDTO>();
            }).CreateMapper();
            this.UoW = UoW;
        }

        IMapper PageLogicMapper;

        public PageLogic()
        {
            PageLogicMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PageDTO, Page>();
                cfg.CreateMap<Page, PageDTO>();
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<PostDTO, Post>();
            }).CreateMapper();
            UoW = LogicDependencyResolver.ResolveUoW();
        }

        public void Add(PageDTO item)
        {
            if (UserLogic.CurrentUser == null || UserLogic.CurrentUser.UserType != DTOs.UserType.Manager)
                throw new Exception("Function availible only for managers");
            UoW.Pages.Add(PageLogicMapper.Map<PageDTO, Page>(item));
        }

        public IEnumerable<PageDTO> PageIEnum()
        {
            return PageLogicMapper.Map<IEnumerable<Page>, List<PageDTO>>(UoW.Pages.GetAll());
        }

        public void DeletePage(int Id)
        {
            if (UserLogic.CurrentUser == null || UserLogic.CurrentUser.UserType != DTOs.UserType.Manager)
                throw new Exception("Function availible only for managers");
            UoW.Pages.Delete(Id);
        }

    }
}
