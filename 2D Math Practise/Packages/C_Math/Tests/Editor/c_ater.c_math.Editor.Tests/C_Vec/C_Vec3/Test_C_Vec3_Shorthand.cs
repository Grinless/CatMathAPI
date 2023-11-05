using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.TestTools;

public class Test_C_Vec3_Shorthand
{
    [Test]
    public void Test_C_Vec3_One()
    {
        Assert.True(new C_V3(1.0F, 1.0F, 1.0F) == C_V3.One);
    }

    [Test]
    public void Test_C_Vec3_Zero()
    {
        Assert.True(new C_V3(0.0F, 0.0F, 0.0F) == C_V3.Zero);
    }

    [Test]
    public void Test_C_Vec3_Right()
    {
        Assert.True(new C_V3(1.0F, 0.0F, 0.0F) == C_V3.Right);
    }

    [Test]
    public void Test_C_Vec3_Left()
    {
        Assert.True(new C_V3(-1.0F, 0.0F, 0.0F) == C_V3.Left);
    }

    [Test]
    public void Test_C_Vec3_Up()
    {
        Assert.True(new C_V3(0.0F, 1.0F, 0.0F) == C_V3.Up);
    }

    [Test]
    public void Test_C_Vec3_Down()
    {
        Assert.True(new C_V3(0.0F, -1.0F, 0.0F) == C_V3.Down);
    }

    [Test]
    public void Test_C_Vec3_FWD()
    {
        Assert.AreEqual(new C_V3(0.0F, 0.0F, 1.0F), C_V3.Forward);
    }

    [Test]
    public void Test_C_Vec3_BCK()
    {
        Assert.True(new C_V3(0.0F, 0.0F, -1.0F) == C_V3.Backward);
    }

    [Test]
    public void Test_C_Vec3_PosInfin()
    {
        Assert.True(new C_V3(
            float.PositiveInfinity,
            float.PositiveInfinity,
            float.PositiveInfinity) !=
            C_V3.PositiveInfinity);
    }

    [Test]
    public void Test_C_Vec3_NegInfin()
    {
        Assert.True(new C_V3(
            float.NegativeInfinity,
            float.NegativeInfinity,
            float.NegativeInfinity
            ) !=
            C_V3.NegativeInfinity);
    }
}
