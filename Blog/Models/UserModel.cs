using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public enum UserType { Administrator, Manager, User }
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public UserType UserType { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual List<PostModel> Posts { get; set; }
        public virtual List<CommentsModel> Comments { get; set; }
    }
}