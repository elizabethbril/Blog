using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PageDTO
    {
        public PageDTO() { }
        public PageDTO(string Title, string PagesContent)
        {
            this.Title = Title;
            this.PagesContent = PagesContent;
        }

        public int PageId { get; set; }        
        public string Title { get; set; }       
        public string PagesContent { get; set; }
        public DateTime Create_Time { get; set; }
        public DateTime Update_Time { get; set; }

        
        public virtual UserDTO UserDetail { get; set; }
    }
}
