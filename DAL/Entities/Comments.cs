using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Comments
    {
        public int Id { get; set; }
        public string Comment_Content { get; set; }       
        SqlDateTime Create_time = DateTime.Now;        
        public int PostId { get; set; }        
        public bool Publish { get; set; }       
        public virtual Post Post { get; set; }
        public virtual User UserDetails { get; set; }
    }
}
