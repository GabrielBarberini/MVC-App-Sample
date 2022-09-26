using System;
using System.IO;
using System.Text;
using copatroca.Models;
using copatroca.Repositories;
 
namespace copatroca { 
    internal class Program {  
        static void Main(string[] args) {

            ContactRepository _contact = new();
            UserRepository _user = new();
            
            Console.WriteLine("1 - Adicionar Usuario");
            Console.WriteLine("2 - Ler Usuario");
            
            
            string option;
            do {
                option = Console.ReadLine();
                switch (option) {
                    case "1":
                        Console.Write("Nome: "); string name = Console.ReadLine();
                        Console.Write("Email: "); string email = Console.ReadLine();
                        Console.Write("Senha: "); string password = Console.ReadLine();
                        Console.Write("Informacao de contato (livre)"); string Info = Console.ReadLine();

                        User user = new User()
                        {
                            Name = name,
                            Email = email,
                            Password = password,
                        };

                        //Contact contact = new(user, Info);

                        //_contact.Create(contact);
                        _user.Create(user);

                        Console.WriteLine("Usuario adicionado");

                        Console.WriteLine("1 - Remover Usuario");
                        Console.WriteLine("2 - Sair");
                        string resp = Console.ReadLine();

                        if(resp == "1")
                        {
                            _user.Delete(user);
                            Console.WriteLine("Usuario Deletado");
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case "2":
                        Console.Write("Email: "); string emailSearch = Console.ReadLine();
                        _user.Read(emailSearch).ToString();
                        break;
                    default:
                        break;
                } 
            } while (option != "0"); 

        } 
    } 
} 
