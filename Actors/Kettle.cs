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

        Animation animation_kettle_hot = new Animation("resources/kettle_hot.png", 64, 49);
        Animation animation_kettle_spilled = new Animation("resources/kettle_spilled.png", 64, 49);
        Animation animation_kettle_cold = new Animation("resources/kettle.png", 64, 49);        

        public Kettle()
        {
            animation_kettle_cold.Start();
            SetAnimation(animation_kettle_cold);
            SetPosition(200,240);
            
        }     

        public void DecreaseTemperature(int delta)
        {
            this.temperature += delta;
        }     

        public void IncreaseTemperature(int delta)
        {
            this.temperature += delta;
        }

        //public int Temperature { get; set; } = 30;


        public int GetTemperature()
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
                    SetPosition(200, 240);
                }
            }
            if (GetTemperature() > 60)
            {
                SetAnimation(animation_kettle_hot);
                animation_kettle_hot.Start();
                SetPosition(200, 240);
            }
            if (GetTemperature() > 100)
            {
                SetAnimation(animation_kettle_spilled);
                animation_kettle_spilled.Start();
                SetPosition(200, 240);
                splillKettle = true;
            }
        }
    }
}
