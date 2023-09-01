using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

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

public class Test_C_M2X2_Properties
{
    [Test]
    public void Test_CM2X2_RowGetters()
    {
        C_M2X2 test = new C_M2X2(1, 2, 3, 4);
        Assert.AreEqual(new C_Seq2(1, 2), test.R1);
        Assert.AreEqual(new C_Seq2(3, 4), test.R2);
    }

    [Test]
    public void Test_CM2X2_ColumnGetters()
    {
        C_M2X2 test = new C_M2X2(1, 2, 3, 4);
        Assert.AreEqual(new C_Seq2(1, 3), test.C1);
        Assert.AreEqual(new C_Seq2(2, 4), test.C2);
    }
}

public class Test_C_M2X2_UntilityFunctions
{
    [Test]
    public void Test_CM2X2_Elements()
    {
        ///[1, 2] [E00, E01]
        ///[3, 4] [E10, E11]
        C_M2X2 test = new C_M2X2(1, 2, 3, 4);
        Debug.Log(test.ToString());

    }

    [Test]
    public void Test_CM2X2_Copy()
    {
        C_M2X2 orignal = new C_M2X2(1, 2, 3, 4);
        C_M2X2 copyTar = new C_M2X2(0, 0, 0, 0);
        C_M2X2.Copy(copyTar, ref orignal);
        Assert.AreEqual(orignal, copyTar);
        Assert.AreEqual(C_M2X2.Zero, orignal);

        orignal = new C_M2X2(1, 2, 3, 4);
        copyTar = new C_M2X2(1, 1, 1, 1);
        C_M2X2.Copy(copyTar, ref orignal);
        Assert.AreEqual(orignal, copyTar);
        Assert.AreEqual(new C_M2X2(1, 1, 1, 1), orignal);
    }
}

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
