using copatroca.Models;
using System;
using System.Collections.Generic;

namespace copatroca.Interfaces
{
    internal interface IRepository<T>
    {
        void Create(T AnyObject);
        void Update(T AnyObject);
        void Delete(T AnyObject);
        T Read(T AnyObject);
    }
}
