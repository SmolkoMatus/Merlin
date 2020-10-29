using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Merlin.Commands
{
     public class Fall<T> : IAction<T> where T : IActor
     {
       
        public void Execute(T t)
        {
           if (t.IsAffectedByPhysics())
            {
                Move move = new Move(t, 1, 0, 1);
                move.Execute();
            }

        }
    }
}
