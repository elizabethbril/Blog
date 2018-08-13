using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        //public DateTime Create_time { get; set; }
        SqlDateTime Create_time = DateTime.Now;
        public virtual Post Post { get; set; }
    }
}
