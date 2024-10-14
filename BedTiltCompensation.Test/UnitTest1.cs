using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BedTiltCompensation.Objects3D;
using BedTiltCompensation.Objects3D.Concepts3D;
using Xunit;


namespace BedTiltCompensation.Test
{
    public class UnitTest1
    {
        [Fact]
        public void PositionTest()
        {
            
            Point3D p123 = new Point3D(1, 2, 3);
            Point3D pDecimal = new Point3D(0.4, 0.0001, 5);
            Point3D pZero = new Point3D(0, 0, 0);
            Point3D p1 = new Point3D(1, 1, 1);

            var multRestult = pZero.CrossProduct(pDecimal);
            Assert.Equal(pDecimal, multRestult);

            multRestult = p123.CrossProduct(pDecimal);

            Point3D multScalarResult = (Point3D) p1.MultiplyByScalar(2);

            Assert.Equal(multScalarResult, pZero);
            

        }
    }
}