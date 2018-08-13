using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;


namespace BLL.Interfaces
{
    public interface IPostLogic
    {
        void Add(PostDTO NewPost);
        void AddComment(int PostId, CommentsDTO NewComment);
        void EditPost(int Id, PostDTO Post);
        //void AddCategory(int PostId, CategoryDTO NewCategory);
        //void AddImage(int PostId, ImageDTO Image);
        IEnumerable<PostDTO> SearchByTag(string Tag);
        IEnumerable<PostDTO> GetAll();
        IEnumerable<PostDTO> FindByCategory(string SearchCategory);

        void DeletePost(int Id);
    }
}
