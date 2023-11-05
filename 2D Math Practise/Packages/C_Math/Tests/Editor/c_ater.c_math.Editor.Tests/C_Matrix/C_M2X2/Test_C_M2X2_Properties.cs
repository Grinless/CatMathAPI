using NUnit.Framework;

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
