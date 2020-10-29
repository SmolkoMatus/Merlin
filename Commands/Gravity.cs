using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Merlin.Commands
{
    public class Gravity : IPhysics
    {
        private IWorld world;


        public Gravity(IWorld world)
        {
            SetWorld(world);
        }
        
       // private IAction<AbstractActor> fall = new Fall<IActor>(1);
        public void Execute()
        {

            List<IActor> actors = world.GetActors().Where((IActor a) => a.IsAffectedByPhysics()).ToList();

            Fall<AbstractActor> fall = new Fall<AbstractActor>();

            //world.GetActors().Where(x => x.IsAffectedByPhysics()).ToList().ForEach(x => fall.Execute(x));
            foreach (AbstractActor a in actors)
            {
                //new Move(actor, 1, 0, 1).Execute(); 
                fall.Execute(a);
            }
        }
        
        public void SetWorld(IWorld world)
        {
            this.world = world;        
        }
    }
}

