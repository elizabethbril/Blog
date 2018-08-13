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
        //public DateTime Create_time { get; set; }    
        SqlDateTime Create_time = DateTime.Now;
        //public int UserId { get; set; }
        public int PostId { get; set; }        
        public bool Publish { get; set; }       
        public virtual Post Post { get; set; }
        virtual public User UserDetails { get; set; }
    }
}
