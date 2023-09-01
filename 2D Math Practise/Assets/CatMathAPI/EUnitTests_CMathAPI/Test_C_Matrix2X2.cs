using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_C_Matrix2X2
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
    public void Test_CM2X2_RowGetters()
    {
        C_M2X2 test = new C_M2X2(1, 2, 3, 4);
        Assert.AreEqual(new C_Seq2(1, 2), test.R1);
        Assert.AreEqual(new C_Seq2(3, 4), (test.R2));
    }

    [Test]
    public void Test_CM2X2_ColumnGetters()
    {
        C_M2X2 test = new C_M2X2(1, 2, 3, 4);
        C_Seq2 c1 = test.C1;
        C_Seq2 c2 = test.C2;
        Assert.AreEqual(new C_Seq2(1, 3), c1);
        Assert.AreEqual(new C_Seq2(2, 4), c2);
    }

    [Test]
    public void Test_CM2X2_Multiplication()
    {
        ///[1, 2] [E00, E01]
        ///[3, 4] [E10, E11]
        C_M2X2 a = new C_M2X2(1, 2, 3, 4);
        C_M2X2 b = new C_M2X2(1, 1, 1, 1);
        Debug.Log((a * b).ToString());

    }

    [Test]
    public void Test_CM2X2_ScalarMultiplication()
    {
        C_M2X2 b = new C_M2X2(1, 1, 1, 1);
        Assert.AreEqual(b, 1.0F * b);
        Assert.AreEqual(new C_M2X2(2, 2, 2, 2), 2.0F * b);
    }

    [Test]
    public void Test_C_Matrix2X2SimplePasses()
    {
        // Use the Assert class to test conditions
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

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator Test_C_Matrix2X2WithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
