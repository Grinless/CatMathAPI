using NUnit.Framework;

public partial class Test_C_Vec3_Properties
{
    [Test]
    public void Test_C_Vec3SimplePasses()
    {
        Assert.True(true);
    }

    [Test]
    public void Test_C_Vec3ElementSetting()
    {
        C_V3 vec = new C_V3(1.0F, 2.0F, 4.0F);
        Assert.AreEqual(1.0F, vec.x);
        Assert.AreEqual(2.0F, vec.y);
        Assert.AreEqual(4.0F, vec.z);
    }
}
