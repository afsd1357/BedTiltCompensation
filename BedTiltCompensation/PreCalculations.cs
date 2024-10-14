using BedTiltCompensation.Objects3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BedTiltCompensation
{
    /*Aiming for the most central rotation axis to minimize max travel length.
         * We choose the point with middle z-value, 
         * we move the center/middle points z-value to 0,
         * so we have to move the rest of the points in the same direction
         */
    internal class PreCalculations
    {
        double AcceptableDeviation = 0.001; //from all measured points to be measured to 0 at z
        int AmmountOfPoints = 3; // could make another constructor that takes a List of points

        Point3D P1;
        Point3D P2;
        Point3D P3;
        
        double CenterOffset; //move value stored in CeterOffset
        Point3D[] SortedPointArray;
        public PreCalculations(Point3D p1, Point3D p2, Point3D p3)
        {
            this.P1 = p1;
            this.P2 = p2;
            this.P3 = p3;
            this.SortedPointArray = new Point3D[AmmountOfPoints];
            if (BedIsLevel(p1.Z, p2.Z, p3.Z))
            {
                Console.WriteLine("Bed is level!");
            }else
            {
                Console.WriteLine("Bed is not level");
            }
            ChooseCenterPoint();
            SortedPointArray[0].Z -= CenterOffset;
            SortedPointArray[2].Z -= CenterOffset;

            
        }

 /*Don't know if there is any kind of acceptable deviation 
 * but i thought it might help with testing
 */
    private bool BedIsLevel(double z1, double z2, double z3) //
        {
            double ad = AcceptableDeviation; //to shorten name
            bool isLevel = (ad - Math.Abs(z1) > 0
                && ad - Math.Abs(z2) > 0
                && ad - Math.Abs(z2) > 0); //if all points are 0 or within the acceptable deviation return true

            return isLevel;
        }
        private void ChooseCenterPoint() // identify center point, and assign the others to [0] and [2]
        {
            double z1 = P1.Z;
            double z2 = P2.Z;
            double z3 = P3.Z;

            if (z1 <= z2 && z1 >= z3)
            {
                this.SortedPointArray[0] = P2;
                this.SortedPointArray[1] = P1;
                this.SortedPointArray[2] = P3;
                CenterOffset = P1.Z;
            }
            else if (z2 <= z1 && z2 >= z3)
            {
                this.SortedPointArray[0] = P1;
                this.SortedPointArray[1] = P2;
                this.SortedPointArray[2] = P3;
                CenterOffset = P2.Z;
            }
            else
            {
                this.SortedPointArray[0] = P1;
                this.SortedPointArray[1] = P3;
                this.SortedPointArray[2] = P2;
                CenterOffset = P3.Z;
            }

        }// Definitly needs to get optimized
        public Point3D[] GetSortedPoints()
        {
            return this.SortedPointArray;
        }
    }
}
