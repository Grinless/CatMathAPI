using NUnit.Framework;
using UnityEngine;

public class Test_C_M3X3_Operators
{
    [Test]
    public void Test_C_Matrix3X3_RowAccessors()
    {
        C_M3X3 m = new C_M3X3(
            1, 2, 3, 
            4, 5, 6, 
            7, 8, 9
            );

        Debug.Log(m.R1.ToString());
        Debug.Log(m.R2.ToString());
        Debug.Log(m.R3.ToString());

        Assert.AreEqual(new C_Seq3(1,2,3), m.R1);
        Assert.AreEqual(new C_Seq3(4,5,6), m.R2);
        Assert.AreEqual(new C_Seq3(7,8,9), m.R3);
    }

    [Test]
    public void Test_C_Matrix3X3_ColumnAccessors()
    {
        C_M3X3 m = new C_M3X3(
            1, 2, 3,
            4, 5, 6,
            7, 8, 9
            );

        Debug.Log(m.C1.ToString());
        Debug.Log(m.C2.ToString());
        Debug.Log(m.C3.ToString());

        Assert.AreEqual(new C_Seq3(1, 4, 7), m.C1);
        Assert.AreEqual(new C_Seq3(2, 5, 8), m.C2);
        Assert.AreEqual(new C_Seq3(3, 6, 9), m.C3);
    }

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
