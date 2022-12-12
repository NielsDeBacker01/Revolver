using Microsoft.Xna.Framework;
using Revolver.Controls.Movement;
using Revolver.Controls.Reader;
using Revolver.Objects;
using Revolver.Objects.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Revolver.Managers
{
    internal static class InteractionManager
    {
        public static bool Interaction(BaseObject g1, BaseObject g2) 
        {
            HashSet<Tag> oldTags1 = new(g1.Tags);
            HashSet<Tag> oldTags2 = new(g2.Tags);

            bool[] values1 = InteractionCheck(g1, g2);
            HashSet<Tag> newTags1 = new(g1.Tags);
            HashSet<Tag> newTags2 = new(g2.Tags);
            g1.Tags = new(oldTags1);
            g2.Tags = new(oldTags2);

            bool[] values2 = InteractionCheck(g2, g1);
            g1.Tags = new(newTags1);
            g2.Tags = new(newTags2);

            bool g1Kill = values1[0];
            bool g2Kill = values2[0];
            bool doCollision = values1[1] && values2[1];

            //kill scenarios
            if (g1Kill)
            {
                if (g1 is Player player1)
                {
                    player1.MinPosition = new Vector2(1, 1);
                    player1.Movement.ResetMovement();
                }
                else
                {
                    GameStateManager.gameObjects.Remove(g1);
                }
            }
            if (g2Kill)
            {
                if (g2 is Player player2)
                {
                    player2.MinPosition = new Vector2(1, 1);
                    player2.Movement.ResetMovement();
                }
                else
                {
                    GameStateManager.gameObjects.Remove(g2);
                }
            }

            return doCollision;
        }

        private static bool[] InteractionCheck(BaseObject g1, BaseObject g2)
        {
            bool g1Kill = false;
            bool doCollision = true;

            //kill mortal with deadly
            if (g2.Tags.Contains(Tag.Deadly))
            {
                //Kill mortals
                if (g1.Tags.Contains(Tag.Mortal))
                {
                    //immunities
                    if (!(g1 is Bandit && g2 is Cactus) && !(g2 is Bullet bullet && bullet.Origin == g1))
                    {
                        g1Kill = true;
                        doCollision = false;
                    }
                }
                //Kill immortals
                else
                {
                    if ((g1 is Player && g2 is Cactus) || (g1 is Bullet bullet && bullet.Origin != g2))
                    {
                        g1Kill = true;
                        doCollision = false;
                    }
                }
            }

            //class specific scenarios
            if (g1 is Player player)
            {
                if (player.Tags.Contains(Tag.Deadly) && g2 is not Gun)
                {
                    player.Movement = new PlayerMovement();
                    player.Tags.Add(Tag.Mortal);
                    player.Tags.Remove(Tag.Deadly);
                }
                if (g2 is Gun gun && gun.GunContent == null && g1.Tags.Contains(Tag.Loadable) && g1 is Movable movableObject)
                {
                    gun.GunContent = movableObject;
                    gun.GunContent.Movement = new NoMovement
                    {
                        InputReader = new KeyboardReader()
                    };
                    gun.GunContent.MinPosition = gun.MinPosition;
                    gun.ShootCooldown = 0.10f;
                    gun.GunContent.Tags.Remove(Tag.Loadable);
                    gun.GunContent.Tags.Remove(Tag.Mortal);
                } 
                doCollision = false;
            }
            else if(g1 is Bullet)
            {
                doCollision = false;
            }

            return new bool[] { g1Kill, doCollision };
        }
    }
}
