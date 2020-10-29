﻿using Merlin.Commands;
using Merlin2d.Game;
using Merlin2d.Game.Actions;
using Merlin2d.Game.Actors;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Merlin.Actors
{
    public class Player : AbstractActor, IMovable
    {
        Animation animation_MerlinWalking = new Animation("resources/player.png", 64, 58);
        Command moveLeft;
        Command moveRight;
        Command moveUp;
        Command moveDown;
       
        //int playerX;
        //int playerY;
        // bool colision = false;

        public Player()
        {
            animation_MerlinWalking.Start();
            SetAnimation(animation_MerlinWalking);
            SetPosition(250, 200);           
        }

        public override void Update()
        {
            moveLeft = new Move(this, 1, -1, 0);
            moveRight = new Move(this, 1, 1, 0);
            new Jump(this, 3, 10, -7);
            moveDown = new Move(this, 1, 0, 1);

            if (Input.GetInstance().IsKeyDown(Input.Key.LEFT) == true)
            {
                animation_MerlinWalking.Start();
                moveLeft.Execute();
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.RIGHT) == true)
            {
                animation_MerlinWalking.Start();
                moveRight.Execute();
            }
            else if ((Input.GetInstance().IsKeyDown(Input.Key.UP) == true))
            {
                animation_MerlinWalking.Start();
                new Jump(this, 3, 0, 0).Execute();
            }
            else if ((Input.GetInstance().IsKeyDown(Input.Key.UP) == true) && (Input.GetInstance().IsKeyDown(Input.Key.RIGHT) == true))
            {
                animation_MerlinWalking.Start();
                new Jump(this, 3, 10, 1).Execute();
            }
            else if ((Input.GetInstance().IsKeyDown(Input.Key.UP) == true) && (Input.GetInstance().IsKeyDown(Input.Key.LEFT) == true))
            {
                animation_MerlinWalking.Start();
                new Jump(this, 3, 10, -1).Execute();
            }
            else if (Input.GetInstance().IsKeyDown(Input.Key.DOWN) == true)
            {
                animation_MerlinWalking.Start();
                moveDown.Execute();
            }
            else
            {
                animation_MerlinWalking.Stop();
            }            
        }

        public int PlayerCoordinatX
        {
            get
            {
                return GetX();
            }
        }

        public int PlayerCoordinatY
        {
            get
            {
                return GetY(); 
            }
        }

        /*public void SetEnemy(Enemy enemy)
        {

        }*/
    }

}