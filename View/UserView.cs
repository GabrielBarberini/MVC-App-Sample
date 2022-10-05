using System;
using copatroca.Models;
using copatroca.Interfaces;

namespace copatroca.Views {
    internal class UserView : IView<User> {
        public bool Control { get; set; } = false;
        public string Info { get; set; }
        public User Obj { get; set; }

        public UserView(User user) {
            Obj = user;
        } 

        public string toString() {
            return $"\nName: {Obj.Name}\nEmail: {Obj.Email}\nInfo: {Obj.UserContact.Info}";
        } 

        public void show() {
            Console.WriteLine(Info);
        } 
    }
}
