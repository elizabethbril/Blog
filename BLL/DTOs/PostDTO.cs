using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PostDTO
    {
        public PostDTO() { }
        public PostDTO(string Title, string Content, string Tags, string CategoryName)
        {
            this.Title = Title;
            this.Content = Content;
            this.Tags = Tags;
            this.CategoryName = CategoryName;        
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public int UserId { get; set; }
        public string Tags { get; set; }
        public string CategoryName { get; set; }
        public int Frequence { get; set; }
        public virtual List<CommentsDTO> Comments { get; set; }
        public virtual List<CategoryDTO> Categories { get; set; }
        public virtual UserDTO UserDetails { get; set; }
        public virtual IEnumerable<CategoryDTO> CategoryDetails { get; set; }
    }
}