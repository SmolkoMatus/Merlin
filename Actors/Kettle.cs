using Merlin2d.Game;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Merlin.Actors
{
    public class Kettle : AbstractActor
    {       
        private int counter = 0;
        private int temperature = 20;
        private bool splillKettle = false;

        private Animation animation_kettle_hot = new Animation("resources/kettle_hot.png", 64, 49);
        private Animation animation_kettle_spilled = new Animation("resources/kettle_spilled.png", 64, 49);
        private Animation animation_kettle_cold = new Animation("resources/kettle.png", 64, 49);        

        public Kettle()
        {
            animation_kettle_cold.Start();
            SetAnimation(animation_kettle_cold);
         
        }     

        private void DecreaseTemperature()
        {
            this.temperature =-1;
        }     

        public void IncreaseTemperature(int delta)
        {
            this.temperature += delta;
        }

        //public int Temperature { get; set; } = 30;

        private int GetTemperature()
        {
            return  temperature;
        }

        public override void Update()
        {
            if(splillKettle == true)
            {
                temperature = 21;
            }
            counter++;
            if(counter % 120 == 0)
            {
                IncreaseTemperature(-1);
                
                Console.Write("DecT");Console.WriteLine(temperature);

            if(GetTemperature() < 60 && 20 < GetTemperature())
                {
                    SetAnimation(animation_kettle_cold);
                    animation_kettle_cold.Start();

                }
            }
            if (GetTemperature() > 60)
            {
                SetAnimation(animation_kettle_hot);
                animation_kettle_hot.Start();

            }
            if (GetTemperature() > 100)
            {
                SetAnimation(animation_kettle_spilled);
                animation_kettle_spilled.Start();

                splillKettle = true;
            }
        }
    }
}
