using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string CategoryName { get; set; }
        SqlDateTime Create_time = DateTime.Now;
        public virtual PostModel Post { get; set; }
    }
}