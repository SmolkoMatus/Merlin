using Merlin2d.Game.Actors;
using Merlin2d.Game;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.Tracing;
using Microsoft.VisualBasic;
using Raylib_cs;
using System.ComponentModel;

namespace Merlin.Actors
{

    public class Stove : AbstractActor
    {
        private int counter = 0;
        private int counterLog = 0;
        private Animation animation_stove_cold = new Animation("resources/stove_cold.png", 64, 34);
        private Animation animation_stove_hot = new Animation("resources/stove.png", 64, 34);
        private Kettle kettle = null;
        

        public Stove()
        {
            animation_stove_cold.Start();
            SetAnimation(animation_stove_cold);
          
                 
           
        }
        public void AddKettle(Kettle kettle)
        {
            if (this.kettle == null)
            {
                this.kettle = kettle;
            }
            
        }
        
        public void AddWood()
        {
            if(counterLog <= 3)
            {
                counterLog++;
            }
        }

        public void RemoveWood()
        {
            if(counterLog >= 0)
            {
                counterLog--;
            }
        }

        public override void Update()
        {
            if(counterLog == 0)
            {     
                SetAnimation(animation_stove_cold);
        
            }
            else if(counterLog >= 1)
            {
                SetAnimation(animation_stove_hot);
              
                animation_stove_hot.Start();
            }
            counter++;           
            if (counter % 60 == 0)
            {                
                //Console.Write("CounterLog:");Console.WriteLine(counterLog.ToString());               
                kettle.IncreaseTemperature(counterLog);                                
            }
        }       
    }
}
