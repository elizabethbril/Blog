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
        //public DateTime CreateTime { get; set; }
        //public int UserId { get; set; }
        public string Tags { get; set; }
        public string CategoryName { get; set; }
        //public int Frequence { get; set; }
        public virtual User UserDetails { get; set; }
        //public string CategoryName { get; set; }
        //public virtual List<Image> Images { get; set; }
        public virtual List<Comments> Comments { get; set; }
        public virtual List<Category> CategoryDetails { get; set; }
    }
}
