using NUnit.Framework;
using UnityEngine;

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
