using System;
using System.IO;
using System.Text;
using copatroca.Models;

namespace copatroca.Interfaces {
    internal interface IUserRepository {
        void Create(User newUser);
        void Update(User updateUser);
        //void Delete(User user);
        User Read(string userEmail);
    } 
} 
