using System;
using System.IO;
using System.Text;
using copatroca.Models;
using copatroca.Repositories;

namespace copatroca { 
    internal class Program {  
        static void Main(string[] args) {
            run();
        } 
            
        static int run() { 
            string option;
            ContactRepository _contactDB = new();
            UserRepository _userDB = new();

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
                        Console.Write("Informacao de contato (Opcional): "); string Info = Console.ReadLine();

                        User user = new User()
                        {
                            Name = name,
                            Email = email,
                            Password = password,
                            UserContact = new User.Contact(Info)
                        };

                        try { 
                            _userDB.CreateUser(user);
                        } catch (Exception ex) {
                            Console.WriteLine(ex.GetType().Name);
                            Console.WriteLine(ex.Message);
                            break;
                        } 

                        Console.WriteLine("\nUsuario adicionado!\n");
                        break;

                    case "2":
                        Console.WriteLine("Email: "); string emailSearch = Console.ReadLine();
                        try { 
                            user = _userDB.ReadUser(emailSearch);
                        } catch (Exception ex) {
                            Console.WriteLine(ex.GetType().Name);
                            Console.WriteLine(ex.Message);
                            break;
                        } 

                        string contactInfo = _contactDB.ReadContact(user);
                        Console.WriteLine($"\nNome: {user.Name}");
                        Console.WriteLine($"Email: {user.Email}");
                        Console.WriteLine($"Contato: {contactInfo}");
                        break;

                    case "3":
                        Console.WriteLine("\nInsira o email...");
                            string loginEmail = Console.ReadLine();

                            if (Utils.isEmail(loginEmail)) {
                                try {
                                    user = _userDB.ReadUser(loginEmail);
                                } catch (Exception ex) {
                                    Console.WriteLine(ex.GetType().Name);
                                    Console.WriteLine(ex.Message);
                                    break;
                                }
                            }
                            else {
                                Console.WriteLine("\nEmail inválido, por favor insira um email no formato email@dominio.com\n");
                                break;
                            }

                            Console.WriteLine("Insira a senha...");
                            string loginPassword = Console.ReadLine();

                            if (user.Password == loginPassword) {
                                run(user);
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

        static int run(User user) {
            Console.WriteLine("\nLogin efetuado com sucesso!\n");

            string option;
            ContactRepository _contactDB = new();
            UserRepository _userDB = new();

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
                        Console.Write("Nome: "); string name = Console.ReadLine();
                        Console.Write("Email: "); string email = Console.ReadLine();
                        while (!Utils.isEmail(email)) {
                            Console.Write("\nEmail inválido, por favor insira um email no formato email@dominio.com\n"); 
                            Console.Write("Email: "); email = Console.ReadLine();
                        } 
                        Console.Write("Senha: "); string password = Console.ReadLine();

                        user.Name = name;
                        user.Email = email;
                        user.Password = password;

                        try {
                            _userDB.UpdateUser(user);
                        } catch (Exception ex) {
                            Console.WriteLine(ex.GetType().Name);
                            Console.WriteLine(ex.Message);
                            break;
                        } 
                        Console.WriteLine("\nUsuario editado com sucesso!\n");
                        break;

                    case "2":
                        Console.Write("Info: "); string info = Console.ReadLine();

                        try {
                            _contactDB.UpdateContact(user, info);
                        } catch (Exception ex) {
                            Console.WriteLine(ex.GetType().Name);
                            Console.WriteLine(ex.Message);
                            break;
                        } 
                        Console.WriteLine("\nInfo editada com sucesso!\n");
                        break;

                    case "3":
                        try {
                            _userDB.DeleteUser(user);
                        } catch (Exception ex) {
                            Console.WriteLine(ex.GetType().Name);
                            Console.WriteLine(ex.Message);
                            break;
                        } 
                        Console.WriteLine("\nConta deletada com sucesso!\n");
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

