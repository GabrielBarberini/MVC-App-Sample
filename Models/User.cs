using System;
using System.Data;
using System.IO;
using System.Text;
using copatroca.Interfaces;
 
namespace copatroca.Models { 
    internal class User{  
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Contact contact { get; set; };

        public User() {
            this.contact = new Contact(this, "No info");
            this.Id = null;
        }

        public void ToString() {
            Console.WriteLine($"Id = {Id}\nNome = {Name}\nEmail = {Email}");
        }

        private class Contact {
            public string Info { get; set; }

            public Contact(User user, string Info) {
                this.userId = user.Id;
                this.Info = Info;
            }
        }
    }
} 
