using NUnit.Framework;
using UnityEngine;

public class Test_C_M2X2_MathFunctions
{
    [Test]
    public void Test_CM2X2_Transpose()
    {
        C_M2X2 orignal = new C_M2X2(
            1, 2,
            3, 4
            );
        C_M2X2.Transpose(ref orignal);
        C_M2X2 expectedOutput = new C_M2X2(
            1, 3,
            2, 4
            );

        Assert.AreEqual(expectedOutput, orignal);
    }

    [Test]
    public void Test_CM2X2_Adjoint()
    {
        //Test non-zero case. 
        C_M2X2 matrix = new C_M2X2(
            1, 2,
            3, 4
        );

        Debug.Log(matrix);

        C_M2X2 adj = matrix.Adjoint;
        C_M2X2 expected = new C_M2X2(
                4, -2,
                -3, 1);

        Assert.AreEqual(expected, adj);
    }

    [Test]
    public void Test_CM2X2_Inverse()
    {
        //Test non-zero case. 
        C_M2X2 matrix = new C_M2X2(
            1, 4,
            6, 8
        );

        C_M2X2 inverse = matrix.Inverse();
        C_M2X2 expected = new C_M2X2(
                -0.5F, 0.25F,
                0.375F, -0.0625F);

        Assert.AreEqual(expected, inverse);
    }
}