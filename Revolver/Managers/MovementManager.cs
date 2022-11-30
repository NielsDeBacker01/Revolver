using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Revolver.Controls.Movement;
using Revolver.Interface;
using System.Collections.Generic;

namespace Revolver.Managers
{
    internal class MovementManager
    {
        public static void Move(IMovable gameObject, GameTime gameTime, List<IMovable> gameObjects)
        {
            if (gameObject.Movement is not NoMovement)
            {
                //get input
                Vector2 direction = gameObject.Movement.InputReader.ReadInput();

                //time Update
                if (direction.X == 0 || direction.X != gameObject.Facing.X)
                {
                    gameObject.Movement.RunManager.TimeRunning = 0;
                }
                else
                {
                    gameObject.Movement.RunManager.TimeRunning += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                if (direction.Y == 0 && !gameObject.Movement.JumpManager.IsJumping)
                {
                    gameObject.Movement.JumpManager.AirTime = 0;
                }
                else
                {
                    gameObject.Movement.JumpManager.AirTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                //facing update 
                Vector2 newFacing = gameObject.Facing;
                if (direction.X != 0)
                {
                    newFacing.X = direction.X;
                }
                gameObject.Facing = newFacing;

                Vector2 Speed;
                //dash
                Speed.X = gameObject.Movement.RunManager.CalculateRun();

                //jump logic
                if (CollisionManager.IsTouchingGround(gameObject))
                {
                    //startsJump
                    if (direction.Y == -1)
                    {
                        Speed.Y = gameObject.Movement.JumpManager.CalculateJump() * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        gameObject.Movement.JumpManager.IsJumping = true;
                    }

                    //onGround
                    else
                    {
                        Speed.Y = 0;
                        gameObject.Movement.JumpManager.IsJumping = false;
                    }
                }
                else
                {
                    //jumping
                    if (gameObject.Movement.JumpManager.IsJumping)
                    {
                        Speed.Y = gameObject.Movement.JumpManager.CalculateJump() * (float)gameTime.ElapsedGameTime.TotalSeconds;
                        direction.Y = -1;
                    }

                    //falling
                    else
                    {
                        Speed.Y = gameObject.Weight * gameObject.Movement.GravityStrength;
                        direction.Y = 1;
                    }
                }

                //result
                Vector2 afstand = direction * Speed;

                //collissionChecks
                afstand = CollisionManager.MovementCollisionChecks(gameObject, afstand, gameObjects);

                //apply result
                gameObject.MinPosition += afstand;
            }
        }
    }
}