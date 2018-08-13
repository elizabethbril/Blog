using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public enum UserType { Administrator, Manager, User }
    public class UserDTO
    {
             
            public UserDTO() { }
            public UserDTO(string Name, UserType UserType, string Surname, string Login, string Password) 
            {
                this.Name = Name;
                this.UserType = UserType;
                this.Surname = Surname; 
                this.Login = Login;
                this.Password = Password;
            }
            public int Id { get; set; }

            public string Name { get; set; }
            public string Surname { get; set; }
            public UserType UserType { get; set; }            
            public string Login { get; set; }
            public string Password { get; set; }
            public virtual List<PostDTO> Posts { get; set; }
            public virtual List<CommentsDTO> Comments { get; set; }
            //public UserDTO() { }

            //public UserDTO(string Name, string Email, string Password, int RoleId)
            //{
            //    this.Name = Name;
            //    this.Email = this.Email;
            //    this.Password = Password;
            //    this.RoleId = RoleId;
            //}

            //public int Id { get; set; }
            //public string Name { get; set; }
            //public string Email { get; set; }
            //public string Password { get; set; }
            //public DateTime Create_time { get; set; }
            //public DateTime Update_Time { get; set; }
            //public DateTime Last_Login { get; set; }
            //public int RoleId { get; set; }
            //virtual public RoleDTO RoleDetails { get; set; }
            //virtual public IEnumerable<RoleDTO> IENUMRoleDetails { get; set; }
        }
}
