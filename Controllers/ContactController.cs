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

        public IView<User.Contact> Create(User.Contact contact) {
            ContactView view = new ContactView(contact);

            cDB.Create(contact);
            view.Control = true;
            view.Info = $"Contato criado com sucesso!";
            return view;
        } 

        public IView<User.Contact> Update(User.Contact contact) {
            ContactView view = new ContactView(contact);

            cDB.Update(contact);
            view.Control = true;
            view.Info = $"Contato atualizado com sucesso!";
            return view;
        } 

        public IView<User.Contact> UpdateContactByUserId(User.Contact contact) {
            ContactView view = new ContactView(contact);

            cDB.UpdateContactByUserId(contact);
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

        public IView<User.Contact> ReadContactByUserId(User.Contact contact) {
            ContactView view = new ContactView(cDB.ReadContactByUserId(contact));

            view.Control = true;
            view.Info = $"Contato encontrado!";
            return view;
        } 
    }
} 
