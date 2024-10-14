using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BedTiltCompensation.Objects3D
{
    internal class Line3D
    {
        Point3D Point; //the point in the intersection line
        Vector3D DirectionVector;
        
        public Line3D(Vector3D v1, Vector3D v2, Point3D p) 
        {
            this.Point = p; 
            this.DirectionVector = new Vector3D(v1.CrossProduct(v2));
        }
    }
}
