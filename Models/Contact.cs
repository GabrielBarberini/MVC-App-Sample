using System;
using System.IO;
using System.Text;
 
namespace copatroca.Models { 
    internal class Contact { 
        public int User_Id { get; set; }
        public string Info { get; set; }
        public Contact(User user, string Info) {
            this.User_Id = user.Id;
            this.Info = Info;
        }
    }
} 
