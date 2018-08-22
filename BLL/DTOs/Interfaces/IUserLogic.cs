using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IUserLogic
    {
        void AddUser(UserDTO NewUser);
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO GetUser(int Id);
        void DeleteUser(int Id);
        void EditUser(int Id, UserDTO User);
        UserDTO Login(string Login, string Password);
           
        void AddComment(int UserId, int PostId, CommentsDTO comment);
        
        
    }
}
