using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Actors
{
    public class CrackedCrystal : Crystal
    {
        private int remainingUses;
        private Animation animationCrackedCrystalOn;
        private Animation animationCrackedCrystalOff;


        public CrackedCrystal(PowerSource source) : this(source, 3)
        {
           
            animationCrackedCrystalOn = new Animation("resources/crystal_on.png", 28, 32);
            animationCrackedCrystalOff = new Animation("resources/crystal_off.png", 28, 32);
            SetAnimation(animationCrackedCrystalOff);
            animationCrackedCrystalOff.Start();
            animationCrackedCrystalOn.Start();
            SetPosition(150, 100);
        }


        public CrackedCrystal(PowerSource source, int remainingUses) : base(source)
        {
            this.remainingUses = remainingUses;
            
        }

        public override void TurnOn()
        { 
           if(remainingUses-- > 0)
            {
                //base.TurnOn();
                Console.Write("remainingUses"); Console.WriteLine(remainingUses);
            }
        }    
    }
}
