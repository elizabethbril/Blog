using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
   public class CommentsDTO
    {
        public CommentsDTO() { }
        public CommentsDTO(string Comment_Content, int PostID, bool Publish)
        {
            this.Comment_Content = Comment_Content;
            this.PostId = PostId;
            this.Publish = Publish;
        }
        public int Id { get; set; }
        public string Comment_Content { get; set; }
        public DateTime Create_time { get; set; }        
        //public int UserId { get; set; }
        public int PostId { get; set; }
        public bool Publish { get; set; }
        public virtual PostDTO Post { get; set; }
        public virtual UserDTO UserDetails { get; set; }
    }
}
