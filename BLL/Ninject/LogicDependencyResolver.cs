using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.UnitOfWork;
using DAL.Interfaces;

namespace BLL.Ninject
{
    public static class LogicDependencyResolver
    {
        static UnitOfWork UoW;

        static LogicDependencyResolver()
        {
            UoW = new UnitOfWork();
        }

        public static IUnitOfWork ResolveUoW()
        {
            return UoW;
        }
    }
}
