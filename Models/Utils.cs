using System;
using System.Data;
using System.IO;
using System.Text;
using System.ComponentModel.DataAnnotations;
 
namespace copatroca.Models { 
    internal class Utils {  
        public static bool isEmail(string email) {
            var validator = new EmailAddressAttribute();
            return validator.IsValid(email);
        }
    }
} 
