using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BlogContext BlogContext;

        public UnitOfWork()
        {
            BlogContext = new BlogContext();            
        }
        
        public UnitOfWork(BlogContext BlogContext)
        {
            this.BlogContext = BlogContext;   
        }

        private IRepository<Category> _categories;
        private IRepository<Comments> _comments;
        private IRepository<Page> _pages;
        private IRepository<Post> _post;
        private IRepository<User> _users;


        public IRepository<Category> Categories {
            get
            {
                if(_categories == null)
                    _categories = new GenericRepository<Category>(BlogContext);
                return _categories;
            }
        }

        public IRepository<Comments> Comments
        {
            get
            {
                if (_comments == null)
                    _comments = new GenericRepository<Comments>(BlogContext);
                return _comments;
            }
        }

       
        public IRepository<Page> Pages
        {
            get
            {
                if (_pages == null)
                    _pages = new GenericRepository<Page>(BlogContext);
                return _pages;
            }
        }

        public IRepository<Post> Post
        {
            get
            {
                if (_post == null)
                    _post = new GenericRepository<Post>(BlogContext);
                return _post;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (_users == null)
                    _users = new GenericRepository<User>(BlogContext);
                return _users;
            }
        }

        public void DeleteDB()
        {
            BlogContext.Database.Delete();            
            BlogContext.Database.Create();            
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    BlogContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }        
    }
}

