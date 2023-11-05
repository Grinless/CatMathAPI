using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.TestTools;

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