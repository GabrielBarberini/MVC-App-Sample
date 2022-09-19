using System;
using System.IO;
using System.Text;
using copatroca.Interfaces;
 
namespace copatroca.Models { 
    internal class User : IUser {  
        public string Name { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Sticker UserSticker { get; set; }

        public Contact UserContact { get; set; }

        void Create(User newUser) {
        } 
    }
} 
