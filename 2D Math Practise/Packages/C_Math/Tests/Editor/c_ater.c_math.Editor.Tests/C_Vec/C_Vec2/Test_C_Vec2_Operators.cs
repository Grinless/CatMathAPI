using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine.TestTools;

public class Test_CVec2_Operators
{
    [Test]
    public void Test_C_Vec2_AdditionCVec2()
    {

        Assert.AreEqual(new C_V2(0.0F, 0.0F),
            new C_V2(0.0F, -1.0F) + new C_V2(0.0F, 1.0F));

        Assert.AreEqual(new C_V2(0.0F, 2.0F),
            new C_V2(0.0F, 1.0F) + new C_V2(0.0F, 1.0F));

        Assert.AreEqual(new C_V2(1.0F, 1.0F),
            new C_V2(1.0F, 0.0F) + new C_V2(0.0F, 1.0F));
    }

    [Test]
    public void Test_C_Vec2_AdditionPoint2D()
    {

        Assert.True(new C_V2(0.0F, 0.0F) ==
            new C_P2D(0.0F, -1.0F) + new C_P2D(0.0F, 1.0F));

        Assert.True(new C_V2(0.0F, 2.0F) ==
            new C_P2D(0.0F, 1.0F) + new C_P2D(0.0F, 1.0F));

        Assert.True(new C_V2(1.0F, 1.0F) ==
            new C_P2D(1.0F, 0.0F) + new C_P2D(0.0F, 1.0F));
    }

    [Test]
    public void Test_C_Vec2_SubtractionCVec2()
    {
        Assert.True(new C_V2(0.0F, 0.0F) == C_V2.Zero - C_V2.Zero);

        Assert.True(new C_V2(0.0F, -1.0F) == C_V2.Zero - C_V2.Up);

        Assert.True(new C_V2(1.0F, -1.0F) == C_V2.Right - C_V2.Up);
    }

    [Test]
    public void Test_C_Vec2_MultiplicationCVec2()
    {

        Assert.AreEqual(new C_V2(0.0F, -1.0F),
            new C_V2(0.0F, -1.0F) * new C_V2(0.0F, 1.0F));

        Assert.AreEqual(new C_V2(0.0F, 1.0F),
            new C_V2(0.0F, 1.0F) * new C_V2(0.0F, 1.0F));

        Assert.AreEqual(new C_V2(0.0F, 0.0F),
            new C_V2(1.0F, 0.0F) * new C_V2(0.0F, 1.0F));
    }

    [Test]
    public void Test_C_Vec2_MultiplicationFloatCVec2()
    {
        Assert.AreEqual(new C_V2(0.0F, 2.0F), 2.0F * new C_V2(0.0F, 1.0F));

        Assert.AreEqual(new C_V2(0.0F, 3.0F), 3.0F * new C_V2(0.0F, 1.0F));

        Assert.AreEqual(new C_V2(0.0F, 4.0F), 4.0F * new C_V2(0.0F, 1.0F));
    }

    [Test]
    public void Test_C_Vec2_MultiplicationIntCVec2()
    {
        Assert.AreEqual(new C_V2(0.0F, 2.0F), 2 * new C_V2(0.0F, 1.0F));

        Assert.AreEqual(new C_V2(0.0F, 3.0F), 3 * new C_V2(0.0F, 1.0F));

        Assert.AreEqual(new C_V2(0.0F, 4.0F), 4 * new C_V2(0.0F, 1.0F));
    }

    [Test]
    public void Test_C_Vec2_Equals()
    {
        C_V2 a = new C_V2(0.0F, 1.0F);
        C_V2 b = new C_V2(0.0F, 1.0F);

        Assert.AreEqual(a.x == b.x && a.y == b.y, a == b);

        a = new C_V2(1.0F, 1.0F);
        b = new C_V2(1.0F, 1.0F);
        Assert.AreEqual(a.x == b.x && a.y == b.y, a == b);

        a = new C_V2(0.0F, 4.0F);
        b = new C_V2(1.0F, 1.0F);
        Assert.AreEqual(a.x == b.x && a.y == b.y, a == b);
    }

    [Test]
    public void Test_C_Vec2_NotEquals()
    {
        C_V2 a = new C_V2(1.0F, 1.0F);
        C_V2 b = new C_V2(0.0F, 1.0F);

        Assert.AreEqual(!(a.x != b.x && a.y != b.y), a != b);

        a = new C_V2(1.0F, 0.0F);
        b = new C_V2(1.0F, 1.0F);
        Assert.AreEqual(!(a.x != b.x && a.y != b.y), a != b);

        a = new C_V2(1.0F, 4.0F);
        b = new C_V2(1.0F, 4.0F);
        Assert.AreEqual(!(a.x != b.x && a.y != b.y), a == b);
    }
}
