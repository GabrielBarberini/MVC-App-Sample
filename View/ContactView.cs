using System;
using copatroca.Models;
using copatroca.Interfaces;

namespace copatroca.Views {
    internal class ContactView : IView<User.Contact> {
        public bool Control { get; set; } = false;
        public string Info { get; set; }
        public User.Contact Obj { get; set; }

        public ContactView(User.Contact contact) {
            Obj = contact;
        } 

        public string toString() {
            return $"\nInfo: {Obj.Info}";
        } 

        public void show() {
            Console.WriteLine(Info);
        } 
    }
}
