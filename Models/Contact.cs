using System;
using System.IO;
using System.Text;
 
namespace copatroca.Models { 
    internal class Contact {  
        public int UserId { get; set; }
        public string Info { get; set; }
        public Contact(User user)
        {
            this.UserId = user.Id;
        }
    }
} 
