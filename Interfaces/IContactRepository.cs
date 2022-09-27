using copatroca.Models;

namespace copatroca.Interfaces
{
    internal interface IContactRepository
    {
        void CreateContact(User user, string info);
        void UpdateContact(User user, string info);
        string ReadContact(User user);
    }
}
