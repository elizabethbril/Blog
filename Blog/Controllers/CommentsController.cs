using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BLL.DTOs;
using Blog.Models;
using AutoMapper;
using BLL.Interfaces;
using Blog.Ninject;

namespace Blog.Controllers
{
    public class CommentsController : ApiController
    {

        public CommentsController()
        {
            this.UserLogic = UIDependencyResolve<IUserLogic>.ResolveDependency();
        }

        IUserLogic UserLogic;

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]Wrap wrap)
        {
            UserLogic.AddComment(wrap.UserId, wrap.PostId, wrap.Comment);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {            
        }


        public class Wrap
        {
            public int UserId { get; set; }
            public int PostId { get; set; }
            public CommentsDTO Comment { get; set; }            
        }

    }
}





