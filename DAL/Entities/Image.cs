using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string Imagepath { get; set; }
        public int Size { get; set; }

        //public DateTime Create_time { get; set; }

        public int UserId { get; set; }
        public virtual User UserDetails { get; set; }
    }
}
