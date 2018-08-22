using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        SqlDateTime Create_time = DateTime.Now;
        public string Tags { get; set; }
        public string CategoryName { get; set; }
        public virtual User UserDetails { get; set; }
        public virtual List<Comments> Comments { get; set; }
        public virtual List<Category> CategoryDetails { get; set; }

        public Post(string Title, string Content, string Tags, string CategoryName)
        {
            this.Title = Title;
            this.Content = Content;
            this.Tags = Tags;
            this.CategoryName = CategoryName;
        }

        public Post() { }
    }
}
