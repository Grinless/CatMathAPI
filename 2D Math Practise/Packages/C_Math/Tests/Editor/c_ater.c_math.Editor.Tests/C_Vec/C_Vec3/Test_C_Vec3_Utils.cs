using NUnit.Framework;
using UnityEngine;

public partial class Test_C_Vec3_Utils
{
    C_V3 vec;

    [SetUp]
    public void Setup()
    {
        vec = new C_V3(1.0F, 2.0F, 4.0F);
    }

    [Test]
    public void Test_C_Vec3SimplePasses()
    {
        Assert.True(true);
    }

    [Test]
    public void Test_C_Vec3Init()
    {
        Assert.AreNotEqual(null, vec);
    }

    [Test]
    public void Test_C_Vec3ElementSetting()
    {
        C_V3 vec = new C_V3(1.0F, 2.0F, 4.0F);
        Assert.AreEqual(1.0F, vec.x);
        Assert.AreEqual(2.0F, vec.y);
        Assert.AreEqual(4.0F, vec.z);
    }

    [Test]
    public void Test_C_Vec3_Prop_Normalized()
    {
        ///RHS negative. 
        C_V3 c1 = new C_V3(-1.0F, 0.0F, 4.0F).Normalized;
        float denom = Mathf.Sqrt(((-1) * (-1)) + (0 * 0) + (4.0F * 4.0F));
        Assert.AreEqual(-1.0F / denom, c1.x);
        Assert.AreEqual(0.0F / denom, c1.y);
        Assert.AreEqual(4.0F / denom, c1.z);

        c1 = new C_V3(-0.5F, 0.5F, 4.0F).Normalized;
        denom = Mathf.Sqrt((-0.5F) * (-0.5F) + 0.5F * 0.5F + (4.0F * 4.0F));
        Assert.AreEqual(-0.5F / denom, c1.x);
        Assert.AreEqual(0.5F / denom, c1.y);
        Assert.AreEqual(4.0F / denom, c1.z);
    }
}