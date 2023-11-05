using NUnit.Framework;

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
    public void Test_CM2X2_Inverse()
    {
        //Test non-zero case. 
        C_M2X2 matrix = new C_M2X2(
            3, 7,
            4, 2
        );

        C_M2X2 inv = matrix.Inverse();
        inv.PrintMatrix();

        Assert.AreEqual(C_M2X2.Identity, matrix * inv);

    }
}