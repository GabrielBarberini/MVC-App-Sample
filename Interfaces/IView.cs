using copatroca.Models;
using copatroca.Views;
using System.Collections.Generic;
using System;

namespace copatroca.Interfaces
{
    internal interface IView<T>
    {
        T Obj { get; set; }
        string toString();
        void show();
    }
}
