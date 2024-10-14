using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BedTiltCompensation.Objects3D;
using BedTiltCompensation.Objects3D.Concepts3D;

namespace BedTiltCompensation
{
    class BedTiltCompensation
    {
        //Normal Vector of a perfectly level bed
        Vector3D BaseNormalVector = 
            new Vector3D(new Position3D(0, 0, 1)); 
        //initial 3 points
        Point3D P1;
        Point3D PMiddle;
        Point3D P3;

        Rotation? Rotater; //nullable because it was a last minute fix
        public BedTiltCompensation(Point3D p1, Point3D p2, Point3D p3)
        {
            PreCalculations p = new PreCalculations(p1, p2, p3);
            Point3D[] SPA = p.GetSortedPoints(); // Sorted so the start

            this.P1 = SPA[0];
            this.PMiddle = SPA[1]; //identified center point
            this.P3 = SPA[2];

            Console.WriteLine("sorted Points: " + P1.Z + ", " + PMiddle.Z + ", " + P3.Z);
        }

        public void PrepareTiltCompensation()
        {
            //create 2 vectors forming the span of the tilt plan
            Vector3D v1 = new Vector3D(P1.SubtractCoordinates(PMiddle));
            Vector3D v2 = new Vector3D(P3.SubtractCoordinates(PMiddle));

            //get normal vector of plan of tilted bed
            Vector3D tiltedNormalVector = new Vector3D(v1.CrossProduct(v2));

            
            this.Rotater = new Rotation(tiltedNormalVector, this.BaseNormalVector, PMiddle);
            Console.WriteLine("Ready to compensate!");
        }
        public Point3D ApplyTiltCompensation(Point3D p)
        {
            if(Rotater != null)
            {
                return Rotater.MovePoint(p);
            }
            return new Point3D(0, 0, 0);
        }
    }
}
