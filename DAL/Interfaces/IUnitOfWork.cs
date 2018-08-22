using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;


namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Comments> Comments { get; }
        IRepository<Page> Pages { get; }
        IRepository<Post> Post { get; }
        IRepository<User> Users { get; }
        
        void DeleteDB();
    }    
}
