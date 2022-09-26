using copatroca.Models;

namespace copatroca.Interfaces
{
    internal interface IContactRepository
    {
        void CreateContact(User user);
        void UpdateContact(User user);
        Contact ReadContact(User user);
    }
}
