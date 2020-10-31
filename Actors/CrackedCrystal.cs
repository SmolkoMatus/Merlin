using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Actors
{
    public class CrackedCrystal : Crystal
    {
        private int remainingUses;
     
        public CrackedCrystal(PowerSource source) : base(source)
        {
           
           
        }
        public CrackedCrystal(PowerSource source, int remainingUses) : this(source , 3)
        {
            this.remainingUses = remainingUses;                
        }

        public override void TurnOn()
        { 
           if(remainingUses > 0)
           {
                base.TurnOn();
                Console.Write("remainingUses"); Console.WriteLine(remainingUses);
           }
            remainingUses--;
        }    
    }
}
