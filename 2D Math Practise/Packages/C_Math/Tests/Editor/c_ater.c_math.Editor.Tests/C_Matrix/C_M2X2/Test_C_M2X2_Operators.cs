using NUnit.Framework;

public class Test_C_M2X2_Operators
{
    [Test]
    public void Test_CM2X2_Equality()
    {
        C_M2X2 orignal = new C_M2X2(0, 0, 0, 0);
        C_M2X2 copyTar = new C_M2X2(0, 0, 0, 0);
        Assert.True(orignal == copyTar);

        orignal = new C_M2X2(1, 1, 1, 1);
        copyTar = new C_M2X2(1, 1, 1, 1);
        Assert.True(orignal == copyTar);

        copyTar = new C_M2X2(0, 1, 0, 1);
        Assert.IsFalse(orignal == copyTar);
    }

    [Test]
    public void Test_CM2X2_Inequality()
    {
        C_M2X2 orignal = new C_M2X2(0, 0, 0, 0);
        C_M2X2 copyTar = new C_M2X2(1, 0, 1, 0);
        Assert.True(orignal != copyTar);

        orignal = new C_M2X2(1, 1, 1, 1);
        copyTar = new C_M2X2(1, 1, 1, 2);
        Assert.True(orignal != copyTar);

        copyTar = new C_M2X2(0, 1, 0, 1);
        Assert.IsFalse(orignal == copyTar);
    }

    [Test]
    public void Test_CM2X2_Addition()
    {
        C_M2X2 orignal = new C_M2X2(0, 0, 0, 0);
        C_M2X2 copyTar = new C_M2X2(1, 0, 1, 0);
        Assert.AreEqual(new C_M2X2(1, 0, 1, 0), orignal + copyTar);

        orignal = new C_M2X2(0, 0, 0, 0);
        copyTar = new C_M2X2(-1, 0, -1, 0);
        Assert.AreEqual(new C_M2X2(-1, 0, -1, 0), orignal + copyTar);

        orignal = new C_M2X2(5, 3, 2, 1);
        copyTar = new C_M2X2(1, 3, 1, 4);
        Assert.AreEqual(new C_M2X2(6, 6, 3, 5), orignal + copyTar);
    }

    [Test]
    public void Test_CM2X2_Subtraction()
    {
        C_M2X2 orignal = new C_M2X2(0, 0, 0, 0);
        C_M2X2 copyTar = new C_M2X2(1, 0, 1, 0);
        Assert.AreEqual(new C_M2X2(-1, 0, -1, 0), orignal - copyTar);

        orignal = new C_M2X2(0, 0, 0, 0);
        copyTar = new C_M2X2(-1, 0, -1, 0);
        Assert.AreEqual(new C_M2X2(1, 0, 1, 0), orignal - copyTar);

        orignal = new C_M2X2(5, 3, 2, 1);
        copyTar = new C_M2X2(1, 3, 1, 4);
        Assert.AreEqual(new C_M2X2(4, 0, 1, -3), orignal - copyTar);
    }

    [Test]
    public void Test_CM2X2_ScalarMultiplication()
    {
        C_M2X2 b = new C_M2X2(1, 1, 1, 1);
        Assert.AreEqual(b, 1.0F * b);
        Assert.AreEqual(new C_M2X2(2, 2, 2, 2), 2.0F * b);
    }

    [Test]
    public void Test_C_Matrix2X2_Multiplication()
    {
        C_M2X2 a = new C_M2X2(1, 2, 3, 4);
        C_M2X2 b = new C_M2X2(1, 1, 1, 1);
        a.PrintMatrix();
        b.PrintMatrix();

        Assert.AreEqual(new C_M2X2(3, 3, 7, 7), a * b);
    }
}
