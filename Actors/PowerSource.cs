using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace Merlin.Actors
{
    public  class PowerSource : AbstractSwitchable, IObservable
    {
        private Animation animationOn;
        private Animation animationOff;
        private List<IObserver> moreObservers = new List<IObserver>();

        public void Subscribe(IObserver observer)
        {       
            this.moreObservers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {         
            this.moreObservers.Remove(observer);
        }

  
        public PowerSource()
        {
            animationOff = new Animation("resources/source_off.png", 64, 23);
            animationOn = new Animation("resources/source_on.png", 64, 23);

            SetAnimation(animationOff);
            animationOff.Start();
            animationOn.Start();
            
            moreObservers = new List<IObserver>();

        }

        public new void Toggle()
        {
            base.Toggle();

            foreach (IObserver observer in this.moreObservers)
            {
                observer.Notify(this.IsOn());
                Console.WriteLine("I am here!");
            }
        }

        public override void Update()
        {
            if (Input.GetInstance().IsKeyPressed(Input.Key.E))
            {
                this.Toggle();
                Console.WriteLine("Pressed key => Change!");
            }
        }

        protected override void UpdateAnimation()
        {
            if (this.IsOn())
            {
                SetAnimation(animationOn);
                animationOn.Start();
            }
            else
            {
                SetAnimation(animationOff);
                animationOff.Start();
            }

        }

    }

}
