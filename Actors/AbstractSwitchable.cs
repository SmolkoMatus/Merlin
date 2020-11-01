using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Actors
{
    public abstract class AbstractSwitchable : AbstractActor, ISwitchable
    {
        private bool isOn = false;
        //private List<bool> isPoweredBefore = new List<bool>();
       // Crystal crystal;
        public void Toggle()
        {
            if (isOn)
            {
                TurnOff();
                //SetAnimation(animationOff);
            }
            else
            {
                TurnOn();
                //  SetAnimation(animationOn);
            }
            //isOn = !isOn;
        }

        public void TurnOff()
        {
            this.isOn = false;
            //isPoweredBefore.Add(this.isOn);
            UpdateAnimation();
        }

        public virtual void TurnOn()
        {

            this.isOn = true;
            //isPoweredBefore.Add(this.isOn);
            UpdateAnimation();
        }

        public bool IsOn()
        {
            return isOn;
        }
        /*
        public bool IsPoweredBefore()
        {
            if(isPoweredBefore.Count > 0)
            {
                return isPoweredBefore[isPoweredBefore.Count - 1]; 
            }
            return false;
        }*/

        protected abstract void UpdateAnimation();
    }
}
