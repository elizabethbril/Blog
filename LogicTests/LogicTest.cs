using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using DAL.UnitOfWork;
using BLL.Logics;
using BLL.DTOs;
using Ninject;
using Ninject.Modules;

namespace LogicTests
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        public void AddPost()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var PostLogic = new PostLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new UserDTO("Liza", UserType.Manager, "Bril", "Login", "Password"));
            UserLogic.Login("Login", "Password");
            PostLogic.Add(new PostDTO("Title", "Content", "Tag", "CategoryName"));

            Assert.AreEqual(PostLogic.GetAll().Count(), 1);
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].Title, "Title");
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].Content, "Content");
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].Tags, "Tag");
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].CategoryName, "CategoryName");
        }

        [TestMethod]
        public void DeletePost()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var PostLogic = new PostLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new UserDTO("Liza", UserType.Manager, "Bril", "Login", "Password"));
            UserLogic.Login("Login", "Password");
            PostLogic.Add(new PostDTO("Title", "Content", "Tag", "CategoryName"));

            Assert.AreEqual(PostLogic.GetAll().Count(), 1);
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].Title, "Title");
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].Content, "Content");
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].Tags, "Tag");
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].CategoryName, "CategoryName");

            PostLogic.DeletePost(1);

            Assert.IsTrue(PostLogic.GetAll().Count() == 0);
            Assert.IsTrue(UoW.Object.Post.GetAll().Count == 0);
        }

        [TestMethod]
        public void AddCommentToPost()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var PostLogic = new PostLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new UserDTO("Liza", UserType.Manager, "Bril", "Login", "Password"));
            UserLogic.Login("Login", "Password");
            PostLogic.Add(new PostDTO("Title", "Content", "Tag", "CategoryName"));
            PostLogic.AddComment(PostLogic.GetAll().ToList()[0].Id, new CommentsDTO("Great Post", 0, true));

            Assert.AreEqual(UoW.Object.Comments.GetAll().Count(), 1);
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].Comments[0].Comment_Content, "Great Post");
            Assert.IsTrue(PostLogic.GetAll().ToList()[0].Comments[0].Publish == true);
            Assert.IsTrue(PostLogic.GetAll().ToList()[0].Comments[0].Post.Id == PostLogic.GetAll().ToList()[0].Id);
        }

        [TestMethod]
        public void EditPost()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var PostLogic = new PostLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new UserDTO("Liza", UserType.Manager, "Bril", "Login", "Password"));
            UserLogic.Login("Login", "Password");
            PostLogic.Add(new PostDTO("Title", "Content", "Tag", "CategoryName"));

            var Post = PostLogic.GetAll().ToList()[0];

            Assert.AreEqual(PostLogic.GetAll().Count(), 1);
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].Title, "Title");
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].Content, "Content");
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].Tags, "Tag");
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].CategoryName, "CategoryName");

            Post.Title = "Programming";
            Post.CategoryName = "C#";

            PostLogic.EditPost(Post.Id, Post);

            Post = PostLogic.GetAll().ToList()[0];

            Assert.AreEqual(PostLogic.GetAll().Count(), 1);
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].Title, "Programming");
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].Content, "Content");
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].Tags, "Tag");
            Assert.AreEqual(PostLogic.GetAll().ToList()[0].CategoryName, "C#");
        }

        [TestMethod]
        public void SearchByTag()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var PostLogic = new PostLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new UserDTO("Liza", UserType.Manager, "Bril", "Login", "Password"));
            UserLogic.Login("Login", "Password");
            PostLogic.Add(new PostDTO("Title", "Content", "Tag", "CategoryName"));
            PostLogic.Add(new PostDTO("Title1", "Content1", "Tag1", "CategoryName1"));
            PostLogic.Add(new PostDTO("Title2", "Content2", "Tag2", "CategoryName2"));
            PostLogic.Add(new PostDTO("Title3", "Content3", "Tag3", "CategoryName3"));
            PostLogic.Add(new PostDTO("Title4", "Content4", "Tag4", "CategoryName4"));

            Assert.IsTrue(PostLogic.GetAll().Count() == 5);
            
            Assert.AreEqual(PostLogic.SearchByTag("Tag1").ToList()[0].Tags, "Tag1");
            Assert.AreEqual(PostLogic.SearchByTag("Tag4").ToList()[0].Tags, "Tag4");            
        }

        [TestMethod]
        public void FindByCategory()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var PostLogic = new PostLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new UserDTO("Liza", UserType.Manager, "Bril", "Login", "Password"));
            UserLogic.Login("Login", "Password");
            PostLogic.Add(new PostDTO("Title", "Content", "Tag", "C#"));
            PostLogic.Add(new PostDTO("Title1", "Content1", "Tag1", "C++"));
            PostLogic.Add(new PostDTO("Title2", "Content2", "Tag2", "Java"));
            PostLogic.Add(new PostDTO("Title3", "Content3", "Tag3", "Python"));
            PostLogic.Add(new PostDTO("Title4", "Content4", "Tag4", "JS"));

            Assert.IsTrue(PostLogic.GetAll().Count() == 5);

            Assert.AreEqual(PostLogic.FindByCategory("C#").ToList()[0].CategoryName, "C#");
            Assert.AreEqual(PostLogic.FindByCategory("C++").ToList()[0].CategoryName, "C++");
            Assert.AreEqual(PostLogic.FindByCategory("JS").ToList()[0].CategoryName, "JS");
            Assert.AreEqual(PostLogic.FindByCategory("Java").ToList()[0].CategoryName, "Java");
        }

        [TestMethod]
        public void AddPage()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var PageLogic = new PageLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new UserDTO("Liza", UserType.Manager, "Bril", "Login", "Password"));
            UserLogic.Login("Login", "Password");
            PageLogic.Add(new PageDTO("New page", "Content"));

            Assert.AreEqual(PageLogic.PageIEnum().Count(), 1);
            Assert.AreEqual(PageLogic.PageIEnum().ToList()[0].Title, "New page");
            Assert.AreEqual(PageLogic.PageIEnum().ToList()[0].PagesContent, "Content");            
        }

        [TestMethod]
        public void DeletePage()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var PageLogic = new PageLogic(UoW.Object);
            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new UserDTO("Liza", UserType.Manager, "Bril", "Login", "Password"));
            UserLogic.Login("Login", "Password");
            PageLogic.Add(new PageDTO("New page", "Content"));

            Assert.AreEqual(PageLogic.PageIEnum().Count(), 1);
            Assert.AreEqual(PageLogic.PageIEnum().ToList()[0].Title, "New page");
            Assert.AreEqual(PageLogic.PageIEnum().ToList()[0].PagesContent, "Content");

            PageLogic.DeletePage(1);

            Assert.IsTrue(UoW.Object.Pages.GetAll().Count == 0);
        }

        [TestMethod]
        public void AddUser()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new UserDTO("Liza", UserType.User, "Bril", "Login", "Password"));

            Assert.IsTrue(UserLogic.GetAllUsers().Count() == 1);
            Assert.AreEqual(UserLogic.GetAllUsers().ToList()[0].Name, "Liza");
            Assert.AreEqual(UserLogic.GetAllUsers().ToList()[0].Surname, "Bril");
            
            Assert.AreEqual(UserLogic.GetAllUsers().ToList()[0].UserType, UserType.User);
            Assert.AreEqual(UserLogic.GetAllUsers().ToList()[0].Login, "Login");
            Assert.AreEqual(UserLogic.GetAllUsers().ToList()[0].Password, "Password");
        }

        [TestMethod]
        public void DeletUser()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new UserDTO("Liza", UserType.User, "Bril", "Login", "Password"));

            Assert.IsTrue(UserLogic.GetAllUsers().Count() == 1);

            UserLogic.DeleteUser(1);

            Assert.IsTrue(UserLogic.GetAllUsers().Count() == 0);
        }

        [TestMethod]
        public void LoggingIn()
        {
            var UoW = new Mock<UnitOfWork>();
            UoW.Object.DeleteDB();

            var UserLogic = new UserLogic(UoW.Object);

            UserLogic.AddUser(new UserDTO("Liza", UserType.User, "Bril", "Login", "Password"));

            Assert.AreEqual(UserLogic.Login("Login", "Password").Id, UserLogic.GetAllUsers().ToList()[0].Id);
        }


    }
}
