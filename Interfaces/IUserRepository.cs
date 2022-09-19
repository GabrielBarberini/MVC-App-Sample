using System;
using System.IO;
using System.Text;
using copatroca.Models;

namespace copatroca.Interfaces {
    internal interface IUserRepository {
        void Create(User newUser);
        void Update(User user);
        //void Delete(User user);
        //void Read(User user);
    } 
} 
