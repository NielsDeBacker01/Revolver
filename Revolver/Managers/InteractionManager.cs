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
            else if (g1 is Bullet)
            {
                doCollision = false;
            }

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

            return doCollision;
        }
    }
}
