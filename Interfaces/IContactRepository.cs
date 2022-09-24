using copatroca.Models;

namespace copatroca.Interfaces
{
    internal interface IContactRepository
    {
        void Create(Contact newContact);
        void Update(Contact updateContact);
        Contact Read(string userEmail);


    }
}
