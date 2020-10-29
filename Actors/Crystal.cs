using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Merlin.Actors
{
    public class Crystal : AbstractSwitchable, IObserver
    {
        private Animation animationOn;
        private Animation animationOff;

        //private int counter = 0;
        //private bool isOn = false;
        private bool isPowered = false;
        private PowerSource powerSource;
        
        public Crystal(PowerSource powerSource)
        {
            animationOff = new Animation("resources/crystal_off.png",28,32);
            animationOn = new Animation("resources/crystal_on.png",28,32);

            SetAnimation(animationOff); 
            animationOff.Start();
            animationOn.Start();
            SetPosition(100, 100);

            
             if(powerSource != null)
             {
                powerSource.Subscribe(this); // problem prekonzultovat vypis 2 observerov ?
                
                isPowered = powerSource.IsOn();
                this.powerSource = powerSource;
             }

        }

        public void Notify(bool state)
        {
            isPowered = state;
            Console.WriteLine("Notify from notife!");
            UpdateAnimation();                  
        }
        

        public override void Update()
        {
             Toggle();           
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


        /*
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
        }*/
        /*
        public void TurnOff()
        {
            isOn = false;
            UpdateAnimation();
        }

        public void TurnOn()
        {
            isOn = true;
            UpdateAnimation();
        }*/
        /*
        private void UpdateAnimation()
        {
            if(isPowered && isOn)
            {
                SetAnimation(animationOn);
            }
            else
            {
                SetAnimation(animationOff);
            }
        }*/

        /*
        public bool IsOn()
        {
            return isOn;
        }
        */

    }
}
