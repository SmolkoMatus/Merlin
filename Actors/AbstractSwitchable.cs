﻿using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Actors
{
    public abstract class AbstractSwitchable : AbstractActor , ISwitchable
    {
        private bool isOn = false;

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

        public override void Update()
        {
            
        }
        protected abstract void UpdateAnimation();
    }
}
