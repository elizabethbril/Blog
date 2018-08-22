using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class PageModel
    {
        public int PageId { get; set; }
        public string Title { get; set; }
        public string PagesContent { get; set; }
        SqlDateTime Create_time = DateTime.Now;

        public virtual UserModel UserDetail { get; set; }
    }
}