using System;
using System.IO;
using System.Text;
using copatroca.Models;

namespace copatroca.Interfaces {
    internal interface IUserRepository {
        void CreateUser(User newUser);
        void UpdateUser(User updateUser);
        //void Delete(User user);
        User ReadUser(string userEmail);
    } 
} 
