using NUnit.Framework;

public partial class Test_CVec2_Properties
{
    [Test]
    public void Test_C_Vec2SimplePasses()
    {
        Assert.True(true);
    }

    [Test]
    public void Test_C_Vec2ElementSetting()
    {
        C_V2 vec = new C_V2(1.0F, 2.0F);
        Assert.AreEqual(1.0F, vec.x);
        Assert.AreEqual(2.0F, vec.y);
    }

}
