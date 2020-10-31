using Merlin.Actors;
using Merlin.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actors;

using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Collections.Generic;


namespace Merlin
{
    class Program
    {
        static void Main(string[] args)
        {
            GameContainer container = new GameContainer("Remorseless winter", 1024, 768);
            //code here 

            container.SetMap("resources/maps/map01.tmx");

            Gravity gravity = new Gravity(container.GetWorld());
            container.GetWorld().SetPhysics(gravity);

            Kettle kettle = new Kettle();
            kettle.SetPosition(200, 240);
            Stove stove = new Stove();
            stove.SetPosition(200, 285);
            IActor player = new Player();
            player.SetPosition(250, 200);
            ((Stove)stove).AddKettle((Kettle)kettle);
            stove.AddWood();
            stove.AddWood();
            stove.AddWood();
            stove.RemoveWood();

            container.GetWorld().AddActor(kettle);
            container.GetWorld().AddActor(stove);
            container.GetWorld().AddActor(player);
            /*Actor actor = kettle;

            if(powerSource is IObservable && Actor is IObserver)
            {
                (IObservable)powerSource.Subscribe((IObserver)actor);
            }*/          
          
            PowerSource source = new PowerSource();
            source.SetPosition(100, 150);
            Crystal crystal = new Crystal((PowerSource)source);
            crystal.SetPosition(100, 100);

            CrackedCrystal crackedCrystal = new CrackedCrystal((PowerSource)source);
            crackedCrystal.SetPosition(150,100);

            IActor enemy = new Enemy(player);
            enemy.SetPosition(250, 500);
            player.SetPhysics(true);
            enemy.SetPhysics(true);

            container.GetWorld().AddActor(crackedCrystal);
            container.GetWorld().AddActor(source);
            container.GetWorld().AddActor(crystal);
            container.GetWorld().AddActor(enemy);

            //((IObservable)source).Subscribe((IObserver)crystal); - pre pridavani dalsieho observera na kontrolu 
  
            List<IActor> actors = new List<IActor>();            
            actors.Add(source);
            actors.Add(crystal);
            actors.Add(kettle);
            actors.Add(stove);
            //actor = actors.Find(a => a.GetName()); //select single entry
            //Console.WriteLine(actor);

            foreach (IActor actor in actors)
            {
                Console.WriteLine(actor.GetType());
            }


            //run game with current settings
            container.Run();
        }
    }

}
