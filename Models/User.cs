using System;
using System.Data;
using System.IO;
using System.Text;
using copatroca.Interfaces;
 
namespace copatroca.Models { 
    internal class User {  
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Contact UserContact; 
        public Sticker UserSticker;
        
        public User() { 
            UserContact = new Contact(this);
        } 

        public User(int Id, string Name, string Email, string Password, string Info) {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.Password = Password;
            UserContact = new Contact(this);
            UserContact.Info = Info;
        }
        
        public void ToString() {
            Console.WriteLine($"Id = {Id}\nNome = {Name}\nEmail = {Email}");
        }

        public class Contact {
            public string Info { get; set; }
            public int Id { get; set; }
            public int uId { get; set; }

            public Contact(User user) {
                uId = user.Id;
            }

            public Contact(User user, string info, int id) {
                Id = id;
                uId = user.Id;
                Info = info;
            } 

        }

        public class Sticker {
            public string Code { get; set; }
        } 
    }
} 
