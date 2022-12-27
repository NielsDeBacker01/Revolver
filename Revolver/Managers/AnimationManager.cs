using Microsoft.Xna.Framework;
using Revolver.Interfaces;
using Revolver.Objects;
using Revolver.Objects.GameObjects;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Managers
{
    internal static class AnimationManager
    {
        public static List<AnimationFrame> PlayerIdle = new List<AnimationFrame>();
        public static List<AnimationFrame> PlayerWalk = new List<AnimationFrame>();
        public static List<AnimationFrame> BanditIdle = new List<AnimationFrame>();
        public static List<AnimationFrame> BanditWalk = new List<AnimationFrame>();
        public static List<AnimationFrame> BlockIdle = new List<AnimationFrame>();
        public static List<AnimationFrame> BulletIdle = new List<AnimationFrame>();
        public static List<AnimationFrame> CactusIdle = new List<AnimationFrame>();
        public static List<AnimationFrame> GoalIdle = new List<AnimationFrame>();
        public static List<AnimationFrame> GunIdle = new List<AnimationFrame>();

        public static AnimationFrame getCurrentFrame(int index, BaseObject requester)
        {
            status animationtype = requester.status;
            int scale = requester.scale;
            AnimationFrame frame = null;
            List<AnimationFrame> selectedList = null;

            //load correct animation
            switch (requester)
            {
                case Player:
                    switch (animationtype)
                    {
                        case status.Idle:
                            selectedList = PlayerIdle;
                            break;
                        case status.Walking:
                            selectedList = PlayerWalk;
                            break;
                        default:
                            break;
                    }
                    break;

                case Bandit:
                    switch (animationtype)
                    {
                        case status.Idle:
                            selectedList = BanditIdle;
                            break;
                        case status.Walking:
                            selectedList = BanditIdle;
                            break;
                        default:
                            break;
                    }
                    break;

                case Block:
                    selectedList = BlockIdle;
                    break;

                case Bullet:
                    selectedList = BulletIdle;
                    break;

                case Cactus:
                    selectedList = CactusIdle;
                    break;

                case Goal:
                    selectedList = GoalIdle;
                    break;

                case Gun:
                    selectedList = GunIdle;
                    break;
            }

            //get the frame from correct animation
            frame = selectedList[index];

            //prepare for next frame
            if (requester is IAnimate animatable)
            {
                if (animatable.currentFrameIndex == selectedList.Count - 1)
                {
                    animatable.currentFrameIndex = 0;
                }
                else
                {
                    animatable.currentFrameIndex++;
                }

                animatable.holdFrame = 60 / selectedList.Count;
            }

            //apply scale to hitboxes and return
            if (scale == 1 || frame == null)
            {
                return frame;
            } else
            {
                AnimationFrame newframe = new AnimationFrame(frame.Hitboxes, frame.frame.X, frame.frame.Y, frame.frame.Width, frame.frame.Height);
                newframe.Hitboxes = frame.Hitboxes.ConvertAll(hbox => new Hitbox(hbox.Box.Width, hbox.Box.Height, hbox.Offset));
                foreach (Hitbox hitbox in newframe.Hitboxes)
                {
                    hitbox.Offset *= 2;
                    Rectangle newBox = hitbox.Box;
                    newBox.Width *= 2;
                    newBox.Height *= 2;
                    hitbox.Box = newBox;
                }
                return newframe;
            }
        }

        public static void Load()
        {
            PlayerIdle.Add(new AnimationFrame(new List<Hitbox>
            {
                new Hitbox(2, 3, new Vector2(1, 2)),
                new Hitbox(6, 5, new Vector2(3, 0)),
                new Hitbox(2, 3, new Vector2(9, 2)),
                new Hitbox(12, 15, new Vector2(0, 5)),
                new Hitbox(3, 7, new Vector2(1, 16)),
                new Hitbox(3, 7, new Vector2(9, 16))
            }, 6, 16, 12, 23));

            PlayerWalk.Add(new AnimationFrame(new List<Hitbox>
            {
                new Hitbox(2, 3, new Vector2(1, 3)),
                new Hitbox(6, 5, new Vector2(3, 1)),
                new Hitbox(2, 3, new Vector2(9, 3)),
                new Hitbox(12, 15, new Vector2(0, 6)),
                new Hitbox(3, 7, new Vector2(1, 17)),
                new Hitbox(3, 7, new Vector2(9, 17))
            }, 6, 52, 12, 24));
            PlayerWalk.Add(new AnimationFrame(new List<Hitbox>
            {
                new Hitbox(2, 3, new Vector2(1, 2)),
                new Hitbox(6, 5, new Vector2(3, 0)),
                new Hitbox(2, 3, new Vector2(9, 2)),
                new Hitbox(12, 15, new Vector2(0, 5)),
                new Hitbox(3, 7, new Vector2(1, 16)),
                new Hitbox(3, 7, new Vector2(9, 16))
            }, 21, 52, 15, 24));
            PlayerWalk.Add(new AnimationFrame(new List<Hitbox>
            {
                new Hitbox(2, 3, new Vector2(1, 2)),
                new Hitbox(6, 5, new Vector2(3, 0)),
                new Hitbox(2, 3, new Vector2(9, 2)),
                new Hitbox(12, 15, new Vector2(0, 5)),
                new Hitbox(3, 7, new Vector2(1, 16)),
                new Hitbox(3, 7, new Vector2(9, 16))
            }, 39, 52, 15, 24));
            PlayerWalk.Add(new AnimationFrame(new List<Hitbox>
            {
                new Hitbox(2, 3, new Vector2(1, 2)),
                new Hitbox(6, 5, new Vector2(3, 0)),
                new Hitbox(2, 3, new Vector2(9, 2)),
                new Hitbox(12, 15, new Vector2(0, 5)),
                new Hitbox(3, 7, new Vector2(1, 16)),
                new Hitbox(3, 7, new Vector2(9, 16))
            }, 57, 52, 12, 24));
            PlayerWalk.Add(new AnimationFrame(new List<Hitbox>
            {
                new Hitbox(2, 3, new Vector2(1, 2)),
                new Hitbox(6, 5, new Vector2(3, 0)),
                new Hitbox(2, 3, new Vector2(9, 2)),
                new Hitbox(12, 15, new Vector2(0, 5)),
                new Hitbox(3, 7, new Vector2(1, 16)),
                new Hitbox(3, 7, new Vector2(9, 16))
            }, 72, 52, 15, 24));
            PlayerWalk.Add(new AnimationFrame(new List<Hitbox>
            {
                new Hitbox(2, 3, new Vector2(1, 2)),
                new Hitbox(6, 5, new Vector2(3, 0)),
                new Hitbox(2, 3, new Vector2(9, 2)),
                new Hitbox(12, 15, new Vector2(0, 5)),
                new Hitbox(3, 7, new Vector2(1, 16)),
                new Hitbox(3, 7, new Vector2(9, 16))
            }, 90, 52, 16, 24));

            BanditIdle.Add(new AnimationFrame(new List<Hitbox>
            {
                new Hitbox(30, 30, new Vector2(0, 0)),
                new Hitbox(20, 10, new Vector2(20, 10))
            }, 0, 0, 30, 30));

            BanditWalk.Add(new AnimationFrame(new List<Hitbox>
            {
                new Hitbox(30, 30, new Vector2(0, 0))
            }, 0, 0, 30, 30));

            BlockIdle.Add(new AnimationFrame(new List<Hitbox>
            {
                new Hitbox(30, 30, new Vector2(0, 0))
            }, 96, 96, 30, 30));

            BulletIdle.Add(new AnimationFrame(new List<Hitbox>
            {
                new Hitbox(10, 5, new Vector2(0, 0))
            }, 0, 0, 10, 5));

            CactusIdle.Add(new AnimationFrame(new List<Hitbox>
            {
                new Hitbox(30, 30, new Vector2(0, 0))
            }, 0, 0, 30, 30));

            GoalIdle.Add(new AnimationFrame(new List<Hitbox>
            {
                new Hitbox(30, 30, new Vector2(0, 0))
            }, 0, 0, 30, 30));

            GunIdle.Add(new AnimationFrame(new List<Hitbox>
            {
                new Hitbox(50, 20, new Vector2(0, 10))
            }, 0, 0, 30, 30));
        }
    }
}
