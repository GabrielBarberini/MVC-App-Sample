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
            UserView view;

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

        public IView<User> Update(User user) {
            UserView view = new UserView(uDB.Read(user));

            uDB.Update(user);
            view.Control = true;
            view.Info = $"Usuário {user.Id} atualizado com sucesso!";
            return view;
        } 

        public IView<User> Delete(User user) {
            UserView view = new UserView(user);

            uDB.Delete(user);
            view.Control = true;
            view.Info = $"Usuário {user.Name}, {user.Id} deletado com sucesso!";
            return view;
        } 

        public IView<User> Read(User user) {
            UserView view = new UserView(uDB.Read(user));
            view.Obj.UserContact = cDB.ReadContactByUserId(view.Obj.UserContact);

            view.Control = true;
            view.Info = $"Usuário {user.Id}, encontrado!";
            return view;
        } 

        public IView<User> ReadUserByEmail(User user) {
            UserView view = new UserView(uDB.ReadUserByEmail(user));
            view.Obj.UserContact = cDB.ReadContactByUserId(view.Obj.UserContact);

            view.Control = true;
            view.Info = $"Usuário {user.Email}, encontrado!";
            return view;
        } 
    }
} 
