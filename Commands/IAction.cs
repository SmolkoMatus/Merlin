using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Commands
{
    public interface IAction<T>
    {
         void Execute(T t);
    }
}
