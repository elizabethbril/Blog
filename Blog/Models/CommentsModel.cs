using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class CommentsModel
    {
        public int Id { get; set; }
        public string Comment_Content { get; set; }
        SqlDateTime Create_time = DateTime.Now;
        public int PostId { get; set; }
        public bool Publish { get; set; }
        public virtual PostModel Post { get; set; }
        virtual public UserModel UserDetails { get; set; }
    }
}