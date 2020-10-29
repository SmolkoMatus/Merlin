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
            Stove stove = new Stove();
            IActor player = new Player();
            
            ((Stove)stove).AddKettle((Kettle)kettle);
            /*
            //Actor kettle = new Kettle(); ukazka na ten isty objekt 
            //Actor actor = kettle; ukazka na ten isty objekt 
            //kettle.GetTemperature = 20;
            //kettle.MyAwasomeMethod();
            //((Kettle)actor).MyAwasomeMethod(); usseful advice :D 
            */
            container.GetWorld().AddActor(kettle);
            container.GetWorld().AddActor(stove);
            container.GetWorld().AddActor(player);
            /*Actor actor = kettle;

            if(powerSource is IObservable && Actor is IObserver)
            {
                (IObservable)powerSource.Subscribe((IObserver)actor);
            }*/          
          
            PowerSource source = new PowerSource();
            Crystal crystal = new Crystal((PowerSource)source);
            CrackedCrystal crackedCrystal = new CrackedCrystal((PowerSource)source);
            IActor enemy = new Enemy(player);

            player.SetPhysics(true);
            enemy.SetPhysics(true);

            container.GetWorld().AddActor(crackedCrystal);
            container.GetWorld().AddActor(source);
            container.GetWorld().AddActor(crystal);
            container.GetWorld().AddActor(enemy);
            //((IObservable)source).Subscribe((IObserver)crystal); - pre pridavani dalsieho observera na kontrolu 


           // IActor actor;
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
