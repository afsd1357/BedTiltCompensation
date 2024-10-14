using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BedTiltCompensation.Objects3D.Concepts3D;

namespace BedTiltCompensation.Objects3D
{
    internal class Vector3D : Position3D
    {

        public Vector3D(Position3D pos) : base(pos.X, pos.Y, pos.Z)
        {

        }


    }
}
