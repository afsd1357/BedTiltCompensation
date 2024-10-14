using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BedTiltCompensation.Objects3D.Concepts3D;

namespace BedTiltCompensation.Objects3D
{
    //pretty empty for now, but gives a good idea of what is calculated and when
    public class Point3D : Position3D
    {
        public Point3D(double x, double y, double z) : base(x, y, z) 
        {
        }
        public Point3D(Position3D pos) : base(pos.X, pos.Y, pos.Z)
        {
        }
    }
}
