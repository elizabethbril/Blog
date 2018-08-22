using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using BLL.Interfaces;
using BLL.Logics;

namespace Blog.Ninject
{
    public class Binder : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserLogic>().To<UserLogic>();
            Bind<IPageLogic>().To<PageLogic>();
            Bind<IPostLogic>().To<PostLogic>();
        }
    }
}