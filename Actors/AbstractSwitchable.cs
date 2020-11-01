using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Actors
{
    public abstract class AbstractSwitchable : AbstractActor, ISwitchable
    {
        private bool isOn = false;

        public void Toggle()
        {
            if (isOn)
            {
                TurnOff();

            }
            else
            {
                TurnOn();

            }

        }

        public void TurnOff()
        {
            this.isOn = false;
           
            UpdateAnimation();
        }

        public virtual void TurnOn()
        {

            this.isOn = true;

            UpdateAnimation();
        }

        public bool IsOn()
        {
            return isOn;
        }
       
        protected abstract void UpdateAnimation();
    }
}
