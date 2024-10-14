using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BedTiltCompensation.Objects3D.Concepts3D
{
    public class Position3D //Takes care of the positional coordinates 
    {
        public double X, Y, Z;
        public Position3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        //Following methods are for any 3D on 3D coordinate set equations 
        //They will all take in another Position3D and return a 3D position or double
        //All equations are calculated as if this set is left of the operator, and the parameter set(p2), on the right
        public Position3D AddCoordinates(Position3D p2)
        {
            Position3D newPos = new Position3D(X + p2.X, Y + p2.Y, Z + p2.Z);
            return newPos;
        }

        public Position3D SubtractCoordinates(Position3D p2)
        {
            Position3D newPos = new Position3D(X - p2.X, Y - p2.Y, Z - p2.Z);
            return newPos;
        }

        public Position3D MultiplyByScalar(double scalar) //Multiplies x, y, z by scalar
        {
            Position3D newPos = new Position3D(X * scalar, Y * scalar, Z * scalar);
            return newPos;
        }


        public double DotProduct(Position3D p2)
        {
            return X * p2.X + Y * p2.Y + Z * p2.Z;
        }

        public Position3D CrossProduct(Position3D p2)
        {
            double x = Y * p2.Z - Z * p2.Y;
            double y = Z * p2.X - X * p2.Z;
            double z = X * p2.Y - Y * p2.X;

            return new Position3D(x, y, z);
        }

        public double AngleBetween2Vectors(Position3D p2)
        {

            return Math.Acos(this.DotProduct(p2)
                / (this.GetVectorLength() * p2.GetVectorLength()));
        }

        //following methods are for single coordinate set operations
        public Position3D Inverse()
        {
            return new Position3D(-X, -Y, -Z);
        }
        public Position3D GetUnitVector()
        {
            double denominator = GetVectorLength();
            double x = X / denominator;
            double y = Y / denominator;
            double z = Z / denominator;
            return new Position3D(x, y, z);
        }
        public double GetVectorLength()
        {
            
            return Math.Sqrt(Math.Pow(X,2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
        }

        //a ToString method

        public void toString()
        {
            Console.WriteLine("X: " + X + " Y: " + Y + " Z: " + Z);
        }
    }
}
