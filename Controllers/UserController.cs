using System;
using System.IO;
using System.Text;
using copatroca.Interfaces;
using copatroca.Models;
using copatroca.Views;
using copatroca.Repositories;
 
namespace copatroca.Controllers { 
    internal class UserController : IController<User> {  
        UserRepository uDB;
        ContactRepository cDB;

        public UserController() {
            uDB = new UserRepository();
            cDB = new ContactRepository();
        } 

        public IView<User> Create(User user) {
            return Create(user.Name, user.Email, user.Password);
        } 
        public IView<User> Update(User user) {
            return Update(user.Id, user.Name, user.Email, user.Password);
        } 
        public IView<User> Delete(User user) {
            UserView uView = new UserView(user);
            return Delete(uView);
        } 
        public IView<User> Read(User user) {
            UserView uView = new UserView(user);
            return Read(uView);
        } 

        public IView<User> Create(string newName, string newEmail, string newPassword) {
            UserView view;
            User user;

            user = new User() {
                Name=newName,
                Email=newEmail,
                Password=newPassword
            }; 

            if (!(String.IsNullOrEmpty(user.Password))) { 
                uDB.Create(user);
                view = new UserView(uDB.ReadUserByEmail(user));
                cDB.Create(view.Obj.UserContact);
                view.Info = $"Usuário {view.Obj.Id} criado com sucesso!";
            } 
            else {
                view = new UserView(user);
                view.Info = "Senha inválida";
            } 
            return view;
        } 

        public IView<User> Update(int id, string name, string email, string password) {
            User user = new User() {
                Id = id,
                Email = email,
                Name = name,
                Password = password
            }; UserView view = new UserView(uDB.Read(user));

            uDB.Update(user);
            view.Control = true;
            view.Info = $"Usuário {user.Id} atualizado com sucesso!";
            return view;
        } 

        public IView<User> Delete(UserView view) {
            uDB.Delete(view.Obj);
            cDB.Delete(view.Obj.UserContact);
            view.Control = true;
            view.Info = $"Usuário {view.Obj.Name}, {view.Obj.Id} deletado com sucesso!";
            return view;
        } 

        public IView<User> Read(UserView uView) {
            UserView view = new UserView(uDB.Read(uView.Obj));
            view.Obj.UserContact = cDB.ReadContactByUserId(view.Obj.UserContact);

            view.Control = true;
            view.Info = $"Usuário {view.Obj.Id}, encontrado!";
            return view;
        } 

        public IView<User> ReadUserByEmail(string email) {
            User user = new User() {
                Email = email
            }; 
            UserView view = new UserView(uDB.ReadUserByEmail(user));
            view.Obj.UserContact = cDB.ReadContactByUserId(view.Obj.UserContact);

            view.Control = true;
            view.Info = $"Usuário {user.Email}, encontrado!";
            return view;
        } 
    }
} 
