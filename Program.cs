using System;
using System.IO;
using System.Text;
using copatroca.Models;
using copatroca.Repositories;
 
namespace copatroca { 
    internal class Program {  
        static void Main(string[] args) {
            Sticker sticker = new Sticker() {
                StickerCode = "A2 B3 C0 D1"
            };

            Contact contact = new Contact() {
                Info = "4002-8922"
            };

            User user = new User() { 
                Name = "Marcos",
                Password = "marcos123",
                Email = "marcos@galdino.joao",
                UserSticker = sticker,
                UserContact = contact
            }; 

            string option;
            do {
                option = Console.ReadLine();
                switch (option) {
                    case "0":
                        break;
                    case "1";
                        break;
                    case "2";
                        break;
                    default:
                        break;
                } 
            } while (option != "0"); 

        } 
    } 
} 
