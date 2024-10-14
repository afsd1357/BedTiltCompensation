// See https://aka.ms/new-console-template for more information

using BedTiltCompensation.Objects3D;
using System;

namespace BedTiltCompensation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point3D p1 = new Point3D(4.4, 3, 0.01);
            Point3D p2 = new Point3D(4.4, -3, 0.02);
            Point3D p3 = new Point3D(-5, 0, -0.03);
            BedTiltCompensation BTC = new BedTiltCompensation(p1, p2, p3);
            BTC.PrepareTiltCompensation();

            Point3D p4 = new Point3D(2.5, 2.5, 0);

            Console.WriteLine("rotating p4: ");
            p4.toString();
            Console.WriteLine("\n");
            BTC.ApplyTiltCompensation(p4).toString();

        }
    }
}