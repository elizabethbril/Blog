using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
   public class CategoryDTO
    {
        public CategoryDTO() { }
        public CategoryDTO(string CategoryName, int PostId)
        {
            this.CategoryName = CategoryName;
            this.PostId = PostId;
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int PostId { get; set; }
        public DateTime Create_time { get; set; }
        public virtual PostDTO Post { get; set; }
    }
}
