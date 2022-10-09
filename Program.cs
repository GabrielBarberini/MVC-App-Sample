using System;
using System.IO;
using System.Text;
using copatroca.Models;
using copatroca.Repositories;
using copatroca.Controllers;
using copatroca.Views;
using System.Collections.Generic;

namespace copatroca { 
    internal class Program {  
        static void Main(string[] args) {
            run();
        } 
            
        static int run() { 
            string option;
            User user;
            User.Contact userContact;
            ContactView contactView;
            UserView userView;
            UserController userController = new();
            ContactController contactController = new();

            do {
                Console.WriteLine("\nSelecione uma opção:");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Adicionar Usuario");
                Console.WriteLine("2 - Ler Usuario");
                Console.WriteLine("3 - Fazer login");

                option = Console.ReadLine();
                switch (option) {
                    case "0":
                        break;
                    case "1":
                        Console.Write("Nome: "); string name = Console.ReadLine();
                        Console.Write("Email: "); string email = Console.ReadLine();
                        while (!Utils.isEmail(email)) {
                            Console.Write("\nEmail inválido, por favor insira um email no formato email@dominio.com\n"); 
                            Console.Write("Email: "); email = Console.ReadLine();
                        } 
                        Console.Write("Senha: "); string password = Console.ReadLine();
                        Console.Write("Informacao de contato (Opcional): "); string info = Console.ReadLine();

                        userView = (UserView) userController.Create(newName: name, newEmail: email, newPassword: password); userView.show();
                        
                        if (!(String.IsNullOrEmpty(info))) { 
                            userView.Obj.UserContact.Info = info; 
                            contactView = (ContactView) contactController.UpdateContactByUserId(userView);
                            contactView.show();
                        } 
                        break;

                    case "2":
                        Console.WriteLine("Email: "); string registeredEmail = Console.ReadLine();
                        while (!Utils.isEmail(registeredEmail)) {
                            Console.Write("\nEmail inválido, por favor insira um email no formato email@dominio.com\n"); 
                            Console.Write("Email: "); registeredEmail = Console.ReadLine();
                        } 

                        userView = (UserView) userController.ReadUserByEmail(registeredEmail);
                        contactView = (ContactView) contactController.ReadContactByUserId(userView);

                        Console.WriteLine(userView.toString());
                        break;

                    case "3":
                        Console.WriteLine("Insira o email: "); string loginEmail = Console.ReadLine();
                        while (!Utils.isEmail(loginEmail)) {
                            Console.Write("\nEmail inválido, por favor insira um email no formato email@dominio.com\n"); 
                            Console.Write("Email: "); loginEmail = Console.ReadLine();
                        } 

                        userView = (UserView) userController.ReadUserByEmail(loginEmail);

                        Console.WriteLine("Insira a senha...");
                        string loginPassword = Console.ReadLine();
                        if (!String.IsNullOrEmpty(loginPassword) && userView.Obj.Password == loginPassword) {
                            run(userView);
                        }
                        else
                            Console.WriteLine("\nCredenciais inválidas ou usuário não existente");
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!\n");
                        break;
                } 
            } while (option != "0"); 

            Console.WriteLine("\nOk! Tchauzinho!");
            return(0);
        } 

        static int run(UserView uView) {
            string option;
            User.Contact userContact;
            ContactView contactView;
            UserView userView;
            UserController userController = new();
            ContactController contactController = new();

            Console.WriteLine("\nLogin efetuado com sucesso!\n");

             do {
                Console.WriteLine("\nSelecione uma opção");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Editar Usuário");
                Console.WriteLine("2 - Editar Info");
                Console.WriteLine("3 - Deletar Conta");

                option = Console.ReadLine();
                switch (option) {
                    case "0":
                        break;
                    case "1":
                        Console.Write("Nome: "); string newName = Console.ReadLine();
                        Console.Write("Email: "); string newEmail = Console.ReadLine();
                        while (!Utils.isEmail(newEmail)) {
                            Console.Write("\nEmail inválido, por favor insira um email no formato email@dominio.com\n"); 
                            Console.Write("Email: "); newEmail = Console.ReadLine();
                        } 
                        Console.Write("Senha: "); string newPassword = Console.ReadLine();

                        userView = (UserView) userController.Update(id: uView.Obj.Id, name: newName, email: newEmail, password: newPassword);
                        userView.show();
                        break;

                    case "2":
                        Console.Write("Info: "); string info = Console.ReadLine();
                        uView.Obj.UserContact.Info = info;

                        contactView = (ContactView) contactController.Update(uView);
                        contactView.show();
                        break;

                    case "3":
                        userView = (UserView) userController.Delete(uView); userView.show();
                        option = "0";
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida!\n");
                        break;
                } 
            } while (option != "0"); 

             Console.WriteLine("\nDeslogando...\n");
             return(0);
        } 
    } 
} 

