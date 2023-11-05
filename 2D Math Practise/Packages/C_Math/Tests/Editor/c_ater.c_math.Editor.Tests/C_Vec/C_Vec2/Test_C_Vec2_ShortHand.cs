using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_CVec2_Shorthand
{
    [Test]
    public void Test_C_Vec2_One()
    {
        Assert.True(new C_V2(1.0F, 1.0F) == C_V2.One);
    }

    [Test]
    public void Test_C_Vec2_Zero()
    {
        Assert.True(new C_V2(0.0F, 0.0F) == C_V2.Zero);
    }

    [Test]
    public void Test_C_Vec2_Right()
    {
        Assert.True(new C_V2(1.0F, 0.0F) == C_V2.Right);
    }

    [Test]
    public void Test_C_Vec2_Left()
    {
        Assert.True(new C_V2(-1.0F, 0.0F) == C_V2.Left);
    }

    [Test]
    public void Test_C_Vec2_Up()
    {
        Assert.True(new C_V2(0.0F, 1.0F) == C_V2.Up);
    }

    [Test]
    public void Test_C_Vec2_Down()
    {
        Assert.True(new C_V2(0.0F, -1.0F) == C_V2.Down);
    }

    [Test]
    public void Test_C_Vec2_PosInfin()
    {
        Assert.True(new C_V2(float.PositiveInfinity, float.PositiveInfinity) !=
            C_V2.PositiveInfinity);
    }

    [Test]
    public void Test_C_Vec2_NegInfin()
    {
        Assert.True(new C_V2(float.NegativeInfinity, float.NegativeInfinity) !=
            C_V2.NegativeInfinity);
    }
}