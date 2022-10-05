using copatroca.Models;
using copatroca.Views;
using System.Collections.Generic;
using System;

namespace copatroca.Interfaces
{
    internal interface IController<T>
    {
        IView<T> Create(T newObj);
        IView<T> Update(T obj);
        IView<T> Delete(T obj);
        IView<T> Read(T obj);
    }
}
