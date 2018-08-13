 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.UnitOfWork;
using DAL.Interfaces;
using Ninject.Modules;

namespace BLL.Ninject
{
    
    public class LogicBinder : NinjectModule// конфигурация IoC-контейнера
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();

        }
    }

}
