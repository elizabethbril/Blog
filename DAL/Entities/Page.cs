using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Page
    {
        [Key]
        public int PageId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is required")]
        public string PagesContent { get; set; }
        SqlDateTime Create_time = DateTime.Now;
        
        public virtual User UserDetail { get; set; }

        public Page() { }
        public Page(string Title, string PagesContent)
        {
            this.Title = Title;
            this.PagesContent = PagesContent;
        }
    }
}
