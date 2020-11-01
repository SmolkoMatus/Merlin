using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text;

namespace Merlin.Actors
{
    public class Crystal : AbstractSwitchable, IObserver
    {
        private Animation animationOn;
        private Animation animationOff;
        private bool isPowered = false;
        private bool wasPoweredBefore = false;
        private PowerSource powerSource;
        
        public Crystal(PowerSource powerSource)
        {
            animationOff = new Animation("resources/crystal_off.png",28,32);
            animationOn = new Animation("resources/crystal_on.png",28,32);

            SetAnimation(animationOff); 
            animationOff.Start();
            animationOn.Start();
            
             if (powerSource != null)
             {
                powerSource.Subscribe(this);
                
                isPowered = powerSource.IsOn();
                this.powerSource = powerSource;
             }
            
        }
        public void Notify(bool state)
        {
            isPowered = state;
           // Console.WriteLine("Notify from notife!");

            UpdateAnimation();                  
        }
        
        public override void Update()
        {            
            if (isPowered)
            {
                TurnOn();
                wasPoweredBefore = true;
            }
            else
            {
                TurnOff();
                wasPoweredBefore = false;
            }
            //Toggle();
        }       
        protected override void UpdateAnimation()
        {
            if (isPowered && IsOn())
            {
                SetAnimation(animationOn);
            }
            else
            {
                SetAnimation(animationOff);
            }
        }

        public  bool WasPoweredBefore()
        {
            return wasPoweredBefore;
        }

    }
}
