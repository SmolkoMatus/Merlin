using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Actors
{
    public interface ISwitchable
    {
        void Toggle();

        void TurnOn();

        void TurnOff();

        bool IsOn();

    }
}
