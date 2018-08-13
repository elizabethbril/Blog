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
        private IRepository<Image> _images;
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

        public IRepository<Image> Images
        {
            get
            {
                if (_images == null)
                    _images = new GenericRepository<Image>(BlogContext);
                return _images;
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

        




        //private BlogContext context = new BlogContext();

        //private EFCategoryRepository categoryRepository;
        //private EFCommentRepository commentRepository;
        //private EFImageRespository imageRespository;
        //private EFPageRepository pageRepository;
        //private EFPostRepository postRepository;
        //private EFRoleRepository roleRepository;
        //private EFUserRepository userRepository;
        //private EFWidgetRepository widgetRepository;


        //public EFCategoryRepository Category
        //{
        //    get
        //    {
        //        if (categoryRepository == null)
        //            categoryRepository = new EFCategoryRepository(context);
        //        return categoryRepository;
        //    }
        //}

        //public EFCommentRepository Comment
        //{
        //    get
        //    {
        //        if (commentRepository == null)
        //            commentRepository = new EFCommentRepository(context);
        //        return commentRepository;
        //    }
        //}

        //public EFImageRespository Image
        //{
        //    get
        //    {
        //        if (imageRespository == null)
        //            imageRespository = new EFImageRespository(context);
        //        return imageRespository;
        //    }
        //}

        //public EFPageRepository Page
        //{
        //    get
        //    {
        //        if (pageRepository == null)
        //            pageRepository = new EFPageRepository(context);
        //        return pageRepository;
        //    }
        //}

        //public EFPostRepository Post
        //{
        //    get
        //    {
        //        if (postRepository == null)
        //            postRepository = new EFPostRepository(context);
        //        return postRepository;
        //    }
        //}

        //public EFRoleRepository Role
        //{
        //    get
        //    {
        //        if (roleRepository == null)
        //            roleRepository = new EFRoleRepository(context);
        //        return roleRepository;
        //    }
        //}

        //public EFUserRepository User
        //{
        //    get
        //    {
        //        if (userRepository == null)
        //            userRepository = new EFUserRepository(context);
        //        return userRepository;
        //    }
        //}

        //public EFWidgetRepository Widget
        //{
        //    get
        //    {
        //        if (widgetRepository == null)
        //            widgetRepository = new EFWidgetRepository(context);
        //        return widgetRepository;
        //    }
        //}

        //public void Save()
        //{
        //    context.SaveChanges();
        //}

        //private bool disposed = false;

        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            context.Dispose();
        //        }
        //        this.disposed = true;
        //    }
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}



    }
}

