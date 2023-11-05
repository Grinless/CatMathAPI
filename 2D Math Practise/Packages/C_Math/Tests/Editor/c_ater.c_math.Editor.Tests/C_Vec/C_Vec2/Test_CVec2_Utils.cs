using NUnit.Framework;
using UnityEngine;

public partial class Test_CVec2_Utils
{
    C_V2 vec;

    [SetUp]
    public void Setup()
    {
        vec = new C_V2(1.0F, 2.0F);
    }

    [Test]
    public void Test_C_Vec2SimplePasses()
    {
        Assert.True(true);
    }

    [Test]
    public void Test_C_Vec2Init()
    {
        Assert.AreNotEqual(null, vec);
    }

    [Test]
    public void Test_C_Vec2ElementSetting()
    {
        C_V2 vec = new C_V2(1.0F, 2.0F);
        Assert.AreEqual(1.0F, vec.x);
        Assert.AreEqual(2.0F, vec.y);
    }

    [Test]
    public void Test_C_Vec2_Prop_Normalized()
    {
        ///RHS negative. 
        C_V2 c1 = new C_V2(-1.0F, 0.0F).Unitized;
        float denom = Mathf.Sqrt((-1) * (-1) + 0 * 0);
        Assert.AreEqual(-1.0F / denom, c1.x);
        Assert.AreEqual(0.0F / denom, c1.y);

        c1 = new C_V2(-0.5F, 0.5F).Unitized;
        denom = Mathf.Sqrt((-0.5F) * (-0.5F) + 0.5F * 0.5F);
        Assert.AreEqual(-0.5F / denom, c1.x);
        Assert.AreEqual(0.5F / denom, c1.y);
    }
}