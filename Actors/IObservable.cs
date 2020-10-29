using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Actors
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);

        void Unsubscribe(IObserver observer);

    }

    //co chceme sledovat powerSource 


    


}
