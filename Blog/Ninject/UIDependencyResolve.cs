using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfaces;
using BLL.Logics;

namespace Blog.Ninject
{
    public static class UIDependencyResolve<T>
    {
        public static dynamic ResolveDependency()
        {
            if (typeof(T) == typeof(IUserLogic))
                return new UserLogic();
            else if (typeof(T) == typeof(IPageLogic))
                return new PageLogic();
            else if (typeof(T) == typeof(IPostLogic))
                return new PostLogic();
            else return null;
        }

    }
}
