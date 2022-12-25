using Microsoft.Xna.Framework;
using Revolver.Controls.Movement;
using Revolver.Objects;
using Revolver.Objects.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Revolver.Managers
{
    internal class CollisionManager
    {
        public static Vector2 MovementCollisionChecks(Movable gameObject, Vector2 movement, List<BaseObject> gameObjects)
        {
            //checks collision with screen borders
            movement += ApplyCollision(gameObject, movement);
            //checks collision with other game objects
            foreach (var gObject in gameObjects.ToList())
            {
                if (gameObject != gObject)
                {
                    movement += ApplyCollision(gameObject, movement, gObject);
                }
                // checks if gameObject was frozen due to a interaction -> other NoMovement gameobjects already got filtered in movementManager
                if (gameObject.Movement is NoMovement)
                {
                    return Vector2.Zero;
                }
            }
            return movement;
        }

        public static Vector2 ApplyCollision(Movable g1, Vector2 movement, BaseObject g2 = null)
        {
            Vector2 greatestCorrection = Vector2.Zero;
            foreach (Hitbox hitbox1 in g1.Hitboxes)
            {
                Vector2 correction = Vector2.Zero;
                float x1 = g1.MinPosition.X + hitbox1.Offset.X + movement.X;
                float y1 = g1.MinPosition.Y + hitbox1.Offset.Y + movement.Y;
                if (g2 == null)
                {
                    if (x1 + hitbox1.Box.Width > 800)
                    {
                        correction.X -= (x1 + hitbox1.Box.Width) % 800;
                    }
                    if (x1 < 0)
                    {
                        correction.X -= x1;
                    }

                    if (y1 < 0)
                    {
                        correction.Y -= y1;
                    }
                    if (y1 + hitbox1.Box.Height > 485)
                    {
                        correction.Y -= (y1 + hitbox1.Box.Height) % 485;
                    }

                    if (Math.Abs(correction.X) > Math.Abs(greatestCorrection.X))
                    {
                        greatestCorrection.X = correction.X;
                    }
                    if (Math.Abs(correction.Y) > Math.Abs(greatestCorrection.Y))
                    {
                        greatestCorrection.Y = correction.Y;
                    }
                }
                else
                {
                    foreach (Hitbox hitbox2 in g2.Hitboxes)
                    {
                        float x2 = g2.MinPosition.X + hitbox2.Offset.X;
                        float y2 = g2.MinPosition.Y + hitbox2.Offset.Y;
                        if ((x2 <= x1 && x1 < x2 + hitbox2.Box.Width) || (x1 <= x2 && x2 < x1 + hitbox1.Box.Width))
                        {
                            if ((y2 <= y1 && y1 < y2 + hitbox2.Box.Height) || (y1 <= y2 && y2 < y1 + hitbox1.Box.Height))
                            {
                                if (g1.InteractWith(g2))
                                {
                                    correction = Vector2.Zero;
                                    if (movement.X != 0)
                                    {
                                        //left approach
                                        if (x1 - movement.X + hitbox1.Box.Width <= x2)
                                        {
                                            correction.X = x2 - (x1 + hitbox1.Box.Width);
                                        }
                                        //right approach
                                        else if (x2 + hitbox2.Box.Width <= x1 - movement.X)
                                        {
                                            correction.X = x2 + hitbox2.Box.Width - x1;
                                        }
                                    }

                                    if (movement.Y != 0 && IsCollidingWithObject(g1, g2))
                                    {
                                        //top approach
                                        if (y1 - movement.Y <= y2)
                                        {
                                            correction.Y = y2 - (y1 + hitbox1.Box.Height);
                                        }
                                        //bottom approach
                                        else if (y2 + hitbox2.Box.Height <= y1 - movement.Y)
                                        {
                                            correction.Y = y2 + hitbox2.Box.Height - y1;
                                        }
                                    }

                                    if (Math.Abs(correction.X) > Math.Abs(greatestCorrection.X))
                                    {
                                        greatestCorrection.X = correction.X;
                                    }
                                    if (Math.Abs(correction.Y) > Math.Abs(greatestCorrection.Y))
                                    {
                                        greatestCorrection.Y = correction.Y;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return greatestCorrection;
        }

        public static bool IsCollidingWithBoundaries(BaseObject gameObject)
        {
            foreach (Hitbox hitbox in gameObject.Hitboxes)
            {
                float x1 = gameObject.MinPosition.X + hitbox.Offset.X;
                float y1 = gameObject.MinPosition.Y + hitbox.Offset.Y;
                if (x1 + hitbox.Box.Width >= ScreenManager.ScreenWidth || x1 <= 0 || y1 <= 0 || y1 + hitbox.Box.Height >= ScreenManager.ScreenHeight)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsCollidingWithObject(BaseObject g1, BaseObject g2)
        {
            foreach (Hitbox hitbox1 in g1.Hitboxes)
            {
                float x1 = g1.MinPosition.X + hitbox1.Offset.X;
                float y1 = g1.MinPosition.Y + hitbox1.Offset.Y;

                foreach (Hitbox hitbox2 in g2.Hitboxes)
                {
                    float x2 = g2.MinPosition.X + hitbox2.Offset.X;
                    float y2 = g2.MinPosition.Y + hitbox2.Offset.Y;
                    if ((x2 <= x1 && x1 < x2 + hitbox2.Box.Width) || (x1 <= x2 && x2 < x1 + hitbox1.Box.Width))
                    {
                        if ((y2 <= y1 && y1 <= y2 + hitbox2.Box.Height) || (y1 <= y2 && y2 <= y1 + hitbox1.Box.Height))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsColliding(Movable GameObject, List<BaseObject> gameObjects, Vector2 addition = new Vector2())
        {
            //apply potential movement
            Movable updatedGameObject = GameObject;
            updatedGameObject.MinPosition += addition;

            //checks collision with screen borders
            if (IsCollidingWithBoundaries(updatedGameObject))
            {
                return true;
            }

            //checks collision with other game objects
            foreach (var gObject in gameObjects)
            {
                if (updatedGameObject != gObject)
                {
                    if (IsCollidingWithObject(updatedGameObject, gObject))
                    {
                        if (updatedGameObject.InteractWith(gObject))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsTouchingGround(BaseObject gameObject)
        {
            if (gameObject.MaxPosition.Y == 485)
            {
                return true;
            }
            foreach (Block block in GameStateManager.gameObjects.OfType<Block>().ToList())
            {
                if (IsCollidingWithObject(gameObject, block))
                {
                    foreach (Hitbox hitbox in gameObject.Hitboxes)
                    {
                        if (gameObject.MinPosition.Y + hitbox.Box.Height + hitbox.Offset.Y == block.MinPosition.Y)
                        {

                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}