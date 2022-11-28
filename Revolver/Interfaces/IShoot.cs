using Revolver.Interface;
using Revolver.Objects.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revolver.Interfaces
{
    internal interface IShoot
    {
        public float ShootCooldown { get;set; }
    }
}
