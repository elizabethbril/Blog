using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IPageLogic
    {
        void Add(PageDTO item);
        IEnumerable<PageDTO> PageIEnum();
        void DeletePage(int Id);
    }
}
