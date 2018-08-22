﻿using System;
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
   
    }
}
