using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        SqlDateTime Create_time = DateTime.Now;
        public string Tags { get; set; }
        public string CategoryName { get; set; }
        public virtual UserModel UserDetails { get; set; }
        public virtual List<CommentsModel> Comments { get; set; }
        public virtual List<CategoryModel> CategoryDetails { get; set; }
    }
}