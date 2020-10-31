using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Actors
{
    public class CrackedCrystal : Crystal
    {
        private int remainingUses;
     
        public CrackedCrystal(PowerSource source) : this(source, 3)
        {
           
           
        }
        public CrackedCrystal(PowerSource source, int remainingUses) : base(source)
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
