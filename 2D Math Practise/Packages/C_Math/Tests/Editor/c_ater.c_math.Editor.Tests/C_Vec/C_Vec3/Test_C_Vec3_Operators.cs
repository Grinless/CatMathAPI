using NUnit.Framework;

public class Test_C_Vec3_Operators
{
    [Test]
    public void Test_C_Vec3_AdditionCVec3()
    {

        ///Expand this unit test with more cases. 
        Assert.AreEqual(new C_V3(0.0F, 0.0F, 0.0F),
            new C_V3(0.0F, -1.0F, -2.0F) + new C_V3(0.0F, 1.0F, 2.0F));

        Assert.AreEqual(new C_V3(0.0F, 2.0F, 4F),
            new C_V3(0.0F, 1.0F, 1.0F) + new C_V3(0.0F, 1.0F, 3.0F));

        Assert.AreEqual(new C_V3(1.0F, 1.0F, 6.5F),
            new C_V3(1.0F, 0.0F, 3.25F) + new C_V3(0.0F, 1.0F, 3.25F));
    }

    [Test]
    public void Test_C_Vec3_SubtractionCVec3()
    {
        ///Expand this unit test with more cases. 
        Assert.True(new C_V3(0.0F, 0.0F, 0.0F) == C_V3.Zero - C_V3.Zero);

        Assert.True(new C_V3(0.0F, -1.0F, 0.0F) == C_V3.Zero - C_V3.Up);

        Assert.True(new C_V3(1.0F, -1.0F, 0.0F) == C_V3.Right - C_V3.Up);
    }

    [Test]
    public void Test_C_Vec3_MultiplicationCVec3()
    {
        ///Expand this unit test with more cases. 

        Assert.AreEqual(new C_V3(0.0F, -1.0F, 0.5f),
            new C_V3(0.0F, -1.0F, 0.5F) * new C_V3(0.0F, 1.0F, 1.0F));

        Assert.AreEqual(new C_V3(0.0F, 1.0F, 3.0F),
            new C_V3(0.0F, 1.0F, 1.0F) * new C_V3(0.0F, 1.0F, 3.0F));

        Assert.AreEqual(new C_V3(0.0F, 0.0F, 0.0F),
            new C_V3(1.0F, 0.0F, 2.0F) * new C_V3(0.0F, 1.0F, 0.0F));
    }

    [Test]
    public void Test_C_Vec3_MultiplicationFloatCVec3()
    {
        ///Expand this unit test with more cases. 
        Assert.AreEqual(new C_V3(0.0F, 2.0F, 4.0F), 2.0F * new C_V3(0.0F, 1.0F, 2.0F));

        Assert.AreEqual(new C_V3(0.0F, 3.0F, 9.0F), 3.0F * new C_V3(0.0F, 1.0F, 3.0F));

        Assert.AreEqual(new C_V3(0.0F, 4.0F, 12.0F), 4.0F * new C_V3(0.0F, 1.0F, 3.0F));
    }

    [Test]
    public void Test_C_Vec3_MultiplicationIntCVec3()
    {
        Assert.AreEqual(new C_V3(0.0F, 2.0F, 2.0F), 2 * new C_V3(0.0F, 1.0F, 1.0F));

        Assert.AreEqual(new C_V3(0.0F, 3.0F, 6.0F), 3 * new C_V3(0.0F, 1.0F, 2.0F));

        Assert.AreEqual(new C_V3(0.0F, 4.0F, 8.0F), 4 * new C_V3(0.0F, 1.0F, 2.0F));
    }

    [Test]
    public void Test_C_Vec3_Equals()
    {
        C_V3 a = new C_V3(0.0F, 1.0F, 0.0F);
        C_V3 b = new C_V3(0.0F, 1.0F, 0.0F);

        Assert.AreEqual(a.x == b.x && a.y == b.y, a == b);

        a = new C_V3(1.0F, 1.0F, 1.0F);
        b = new C_V3(1.0F, 1.0F, 1.0F);
        Assert.AreEqual(a.x == b.x && a.y == b.y, a == b);

        a = new C_V3(0.0F, 4.0F, 2.0F);
        b = new C_V3(1.0F, 1.0F, 2.0F);
        Assert.AreEqual(a.x == b.x && a.y == b.y, a == b);
    }

    [Test]
    public void Test_C_Vec3_NotEquals()
    {
        C_V3 a = new C_V3(1.0F, 1.0F, 1.0F);
        C_V3 b = new C_V3(0.0F, 1.0F, 0.0F);

        Assert.AreEqual(!(a.x != b.x && a.y != b.y), a != b);

        a = new C_V3(1.0F, 0.0F, 0.0F);
        b = new C_V3(1.0F, 1.0F, 0.0F);
        Assert.AreEqual(!(a.x != b.x && a.y != b.y), a != b);

        a = new C_V3(1.0F, 4.0F, 0.0F);
        b = new C_V3(1.0F, 4.0F, 0.0F);
        Assert.AreEqual(!(a.x != b.x && a.y != b.y), a == b);
    }
}
