using NUnit.Framework;
using UnityEngine;

public class Test_C_M2X2_UtilityFunctions
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
