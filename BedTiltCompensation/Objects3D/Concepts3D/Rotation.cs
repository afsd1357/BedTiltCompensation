using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BedTiltCompensation.Objects3D.Concepts3D
{
    internal class Rotation
    {
        // Axis we rotate any point at angle around
        // Found by: https://www.houseofmath.com/encyclopedia/numbers-and-quantities/vectors/three-dimensions/intersections/how-to-find-the-intersection-between-two-planes

        public Line3D Axis;
        public Vector3D UnitVector;
        public double RotationAngle;
        public Point3D LineDistanceFromOrion; // See MovePoint() bellow
        public Rotation(Vector3D tiltedNormalVector, Vector3D BaseNormalVector, Point3D pointOnIntersection)
        {
            //to shorten the names and adjust possible "right hand left hand" issues
            Vector3D TNV = EnsureDirection(tiltedNormalVector);
            Vector3D BNV = BaseNormalVector;
            Point3D POI = pointOnIntersection;

            this.Axis = new Line3D(TNV, BNV, POI);
            this.UnitVector = new Vector3D (BNV.CrossProduct(TNV).GetUnitVector());
            this.RotationAngle = EnsureAngle(BNV.AngleBetween2Vectors(TNV));
            this.LineDistanceFromOrion = POI;
        }
        // The angle should be 
        private Vector3D EnsureDirection(Vector3D v)
        {
            if (v.Z > 0)
            {
                return v;
            }
            else 
            { 
                return new Vector3D(v.Inverse());
            }
        }
        private double EnsureAngle(double angle) //convert to smallest possible angle
        {
            
            if (angle < Math.PI)
            {
                Console.WriteLine("angle in degrees: " + angle / Math.PI * 180);
                return angle;
            }
            else
            {
                Console.WriteLine("angle in degrees: " + angle / Math.PI * 180);
                return 2 * Math.PI - angle;
            }
        }

        //We must rotate the point around a unit vector
        //We must also rotate the point around the intersection line
        //So we move the point the same direction as the line would
        //have to be moved to get to orion (LineDistanceFromOrion)
        //Then we rotate the point, and move it back 
        public Point3D MovePoint(Point3D p)
        {
            p.SubtractCoordinates(LineDistanceFromOrion);
            p = RotatePoint(p);
            p.AddCoordinates(LineDistanceFromOrion);

            return p;
        }
        // https://en.wikipedia.org/wiki/Rodrigues%27_formula
        private Point3D RotatePoint(Point3D p)
        {
            //split the equation into sections to make it more readable
            Position3D s1 = p.MultiplyByScalar(Math.Cos(RotationAngle));
            Position3D s2 = UnitVector.CrossProduct(p).MultiplyByScalar(Math.Sin(RotationAngle));
            Position3D s3 = UnitVector.MultiplyByScalar(UnitVector.DotProduct(p));
            s3 = s3.MultiplyByScalar(1-Math.Cos(RotationAngle));

            return new Point3D(s1.AddCoordinates(s2).AddCoordinates(s3));
        }
    }
}
