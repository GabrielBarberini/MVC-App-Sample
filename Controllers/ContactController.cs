using System;
using System.IO;
using System.Text;
using copatroca.Interfaces;
using copatroca.Models;
using copatroca.Views;
using copatroca.Repositories;
 
namespace copatroca.Controllers { 
    internal class ContactController : IController<User.Contact> {  
        ContactRepository cDB;

        public ContactController() {
            cDB = new ContactRepository();
        } 

        public IView<User.Contact> Create(User.Contact userContact) {
            User user = new User(){
                UserContact = userContact
            }; 
            UserView uView = new UserView(user);
            return Create(uView);
        }

        public IView<User.Contact> Update(User.Contact userContact) {
            User user = new User(){
                UserContact = userContact
            }; 
            UserView uView = new UserView(user);
            return Update(uView);
        }

        public IView<User.Contact> Create(UserView uView) {
            ContactView view = new ContactView(uView.Obj.UserContact);

            cDB.Create(uView.Obj.UserContact);
            view.Control = true;
            view.Info = $"Contato criado com sucesso!";
            return view;
        } 

        public IView<User.Contact> Update(UserView uView) {
            ContactView view = new ContactView(uView.Obj.UserContact);

            cDB.Update(uView.Obj.UserContact);
            view.Control = true;
            view.Info = $"Contato atualizado com sucesso!";
            return view;
        } 

        public IView<User.Contact> UpdateContactByUserId(UserView uView) {
            ContactView view = new ContactView(uView.Obj.UserContact);

            cDB.UpdateContactByUserId(uView.Obj.UserContact);
            view.Control = true;
            view.Info = $"Contato atualizado com sucesso!";
            return view;
        }

        public IView<User.Contact> Delete(User.Contact contact) {
            ContactView view = new ContactView(contact);

            cDB.Delete(contact);
            view.Control = true;
            view.Info = $"Contato deletado com sucesso!";
            return view;
        } 

        public IView<User.Contact> Read(User.Contact contact) {
            ContactView view = new ContactView(cDB.Read(contact));

            view.Control = true;
            view.Info = $"Contato encontrado!";
            return view;
        } 

        public IView<User.Contact> ReadContactByUserId(UserView uView) {
            ContactView view = new ContactView(cDB.ReadContactByUserId(uView.Obj.UserContact));

            view.Control = true;
            view.Info = $"Contato encontrado!";
            return view;
        } 
    }
} 
