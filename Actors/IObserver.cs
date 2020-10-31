using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Actors
{

    public interface IObserver
    {
        void Notify(bool isOn);
    }
}
