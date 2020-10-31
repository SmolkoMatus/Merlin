using Merlin.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

namespace Merlin.Actors
{
    public class Player : AbstractActor, IMovable
    {
        Animation animationMerlinWalking = new Animation("resources/player.png", 64, 58);
        Command moveLeft;
        Command moveRight;
        Command moveDown;
        private int counterHop = 2;
        private bool jumpAvaiable = true;
        private int currentHop = 0;
       
        //int playerX;
        //int playerY;
        // bool colision = false;

        public Player()
        {
            animationMerlinWalking.Start();
            SetAnimation(animationMerlinWalking);                   
        }
        public override void Update()
        {
            moveLeft = new Move(this, 1, -1, 0);
            moveRight = new Move(this, 1, 1, 0);
            new Jump(this, 3, 10, -7);
            moveDown = new Move(this, 1, 0, 1);
            animationMerlinWalking.Start();

            if (Input.GetInstance().IsKeyDown(Input.Key.LEFT) == true)
            {                
                if ((Input.GetInstance().IsKeyPressed(Input.Key.SPACE) == true) && (counterHop-- > 0))
                {
                    if (jumpAvaiable && currentHop <= 2) 
                    {
                        moveLeft.Execute();
                        new Jump(this, 3, 10, -1).Execute();
                        currentHop++;
                    }
                    if(currentHop >= 2)
                    {
                        jumpAvaiable = false;
                    }
                }
                else
                {                                      
                    jumpAvaiable = true;
                    counterHop = 2;                    
                    moveLeft.Execute();
                }
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT) == true)
            {
                if ((Input.GetInstance().IsKeyPressed(Input.Key.SPACE) == true) && (counterHop-- > 0))
                {
                    if (jumpAvaiable && currentHop < 2)
                    {
                        moveRight.Execute();
                        new Jump(this, 3, 10, 1).Execute();
                        currentHop++;
                    } 
                    if(currentHop >= 2)
                    {
                        jumpAvaiable = false;
                    }
                }
                else
                {   
                    jumpAvaiable = true;
                    counterHop = 2;
                    moveRight.Execute();                   
                }
            }
           else if ((Input.GetInstance().IsKeyDown(Input.Key.SPACE) == true) && (counterHop-- > 0))
            {
                new Jump(this, 3, 0, 0).Execute();               
            }

            else if (Input.GetInstance().IsKeyDown(Input.Key.DOWN) == true)
            {
                moveDown.Execute();
            }
            else
            {
                currentHop = 0;
                animationMerlinWalking.Stop();
            }            
        }
    }
}
