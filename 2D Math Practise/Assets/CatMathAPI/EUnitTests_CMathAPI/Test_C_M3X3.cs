using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_C_M3X3_Operators
{
    [Test]
    public void Test_C_Matrix3X3_Equality()
    {
        C_M3X3 m = new C_M3X3(
            1, 0, 0,
            0, 1, 0,
            0, 0, 1
            );
        C_M3X3 i = C_M3X3.Identity;
        Debug.Log(m.ToString());
        Debug.Log(i.ToString());
        Assert.IsTrue(m == i);
    }

    [Test]
    public void Test_C_Matrix3X3_Inequality()
    {
        C_M3X3 m = new C_M3X3(
            1, 0, 1,
            0, 1, 0,
            1, 0, 1
            );

        Assert.IsTrue(m != C_M3X3.Identity);
    }
}

public class Test_C_M3X3
{
    [Test]
    public void Test_C_Matrix3X3SimplePasses()
    {

    }

    [Test]
    public void Test_C_Matrix3X3_TestDeterminant()
    {
        C_M3X3 testM = new C_M3X3(
            1, 4, 8,
            6, 7, 2,
            3, 9, 4
            );

        Assert.AreEqual(202, testM.Determinant());
    }


}
