using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using NUnit.Framework;
using UnityEngine.TestTools;

public class Test_C_M2X2_MathProperties
{
    [Test]
    public void Test_CM2X2_Determinant()
    {
        //Test zero case. 
        C_M2X2 matrix = new C_M2X2(
            2, 4,
            8, 16
            );

        Assert.AreEqual(0, matrix.Determinant);

        //Test non-zero case. 
        matrix = new C_M2X2(
            3, 7,
            4, 2
            );

        Assert.AreEqual(-22, matrix.Determinant);

    }

    [Test]
    public void Test_CM2X2_Adjoint()
    {
        //Test zero case. 
        C_M2X2 matrix = new C_M2X2(
            2, 4,
            8, 16
            );

        C_M2X2 adj = new C_M2X2(
            16, -4,
            -8, 2
            );

        Assert.AreEqual(adj, matrix.Adjoint);
    }
}
