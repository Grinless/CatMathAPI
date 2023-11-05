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

public class Test_CVec2_Funcs
{
    C_V2 vec;

    [SetUp]
    public void Setup()
    {
        vec = new C_V2(1.0F, 2.0F);
    }

    [Test]
    public void Test_C_Vec2_Set()
    {
        C_V2 vec = new C_V2(1.0F, 2.0F);
        vec.Set(4.0f, 8.0f);
        Assert.AreEqual(new C_V2(4.0F, 8.0F), vec);
    }

    [Test]
    public void Test_C_Vec2_CopyTo()
    {
        C_V2 copyVec = new C_V2(2.0f, 5.0f);
        Assert.AreNotEqual(copyVec, vec);

        //Copy values. 
        C_V2.CopyTo(vec, ref copyVec);
        Assert.AreEqual(new C_V2(1.0F, 2.0F), vec);
    }

    [Test]
    public void Test_C_Vec2_Min()
    {
        Assert.AreEqual(new C_V2(0.5F, 2.0F),
            C_V2.Min(vec, new C_V2(0.5F, 4.0F)));
    }

    [Test]
    public void Test_C_Vec2_Max()
    {
        Assert.AreEqual(new C_V2(1.0F, 4.0F),
            C_V2.Max(vec, new C_V2(0.5F, 4.0F)));
    }

    [Test]
    public void Test_C_Vec2_Clamp()
    {
        C_V2 c1 = C_V2.Clamp(
            new C_V2(-1.0F, 20.0F),
            new C_V2(0.0F, 10.0F)
            );
        Assert.AreEqual(new C_V2(0.0F, 10.0F), c1);


        c1 = C_V2.Clamp(
            new C_V2(-1.0F, 20.0F),
            new C_V2(-0.5F, 1.0F),
            new C_V2(0.0F, 1.0F)
        );
        Assert.AreEqual(new C_V2(-0.5F, 1.0F), c1);
    }

    [Test]
    public void Test_C_Vec2_Abs()
    {
        ///RHS negative. 
        Assert.AreEqual(new C_V2(1.0F, 20.0F), 
            C_V2.Abs(new C_V2(-1.0F, 20.0F)));

        ///LHS negative. 
        Assert.AreEqual(new C_V2(1.0F, 20.0F), 
            C_V2.Abs(new C_V2(1.0F, -20.0F)));

        ///LRHS negative. 
        Assert.AreEqual(new C_V2(1.0F, 20.0F), 
            C_V2.Abs(new C_V2(-1.0F, -20.0F)));

        ///LRHS positive. 
        Assert.AreEqual(new C_V2(1.0F, 20.0F), 
            C_V2.Abs(new C_V2(1.0F, 20.0F)));
    }

    [Test]
    public void Test_C_Vec2_Normalize()
    {
        ///RHS negative. 
        C_V2 c1 = new C_V2(-1.0F, 0.0F);
        c1.Unitize();
        float denom = Mathf.Sqrt((-1) * (-1) + 0 * 0);
        Assert.AreEqual(new C_V2(-1.0F / denom, 0.0F / denom) , c1);

        c1 = new C_V2(-0.5F, 0.5F);
        c1.Unitize();
        denom = Mathf.Sqrt((-0.5F) * (-0.5F) + 0.5F * 0.5F);
        Assert.AreEqual(new C_V2(-0.5F / denom, 0.5F / denom) , c1);
    }

    [Test]
    public void Test_C_Vec2_DotProduct()
    {
        C_V2 a = new C_V2(0.0F, -1.0F);
        C_V2 b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(-1, C_V2.DotProduct(a, b));

        a = new C_V2(0.0F, 1.0F);
        b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(1, C_V2.DotProduct(a, b));

        a = new C_V2(1.0F, 0.0F);
        b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(0.0F, C_V2.DotProduct(a, b));

        a = new C_V2(-1.0F, 0.0F);
        b = new C_V2(0.0F, -1.0F);
        Assert.AreEqual(0.0F, C_V2.DotProduct(a, b));

        a = new C_V2(2.5F, 2.5F);
        b = new C_V2(1.0F, 0.0F);
        Assert.AreEqual(2.5F, C_V2.DotProduct(a, b));
    }

    [Test]
    public void Test_C_Vec2_NormDotProduct()
    {
        C_V2 a = new C_V2(0.0F, -1.0F);
        C_V2 b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(-1, C_V2.NormDotProduct(a, b));

        a = new C_V2(0.0F, 1.0F);
        b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(1, C_V2.NormDotProduct(a, b));

        a = new C_V2(1.0F, 0.0F);
        b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(0.0F, C_V2.NormDotProduct(a, b));

        a = new C_V2(-1.0F, 0.0F);
        b = new C_V2(0.0F, -1.0F);
        Assert.AreEqual(0.0F, C_V2.NormDotProduct(a, b));

        a = new C_V2(2.5F, 2.5F);
        b = new C_V2(1.0F, 0.0F);
        Assert.AreEqual(0.707106769F, C_V2.NormDotProduct(a, b));
    }

    [Test]
    public void Test_C_Vec2_AngleBetween()
    {
        C_V2 a = new C_V2(0.0F, -1.0F);
        C_V2 b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(Mathf.Acos(-1), C_V2.AngleBetween(a, b));

        a = new C_V2(0.0F, 1.0F);
        b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(Mathf.Acos(1), C_V2.AngleBetween(a, b));

        a = new C_V2(1.0F, 0.0F);
        b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(Mathf.Acos(0.0F), C_V2.AngleBetween(a, b));

        a = new C_V2(-1.0F, 0.0F);
        b = new C_V2(0.0F, -1.0F);
        Assert.AreEqual(Mathf.Acos(0.0F), C_V2.AngleBetween(a, b));

        a = new C_V2(2.5F, 2.5F).Unitized;
        b = new C_V2(1.0F, 0.0F).Unitized;
        Assert.AreEqual(0.707106769F, C_V2.DotProduct(a, b));
    }

    public void Test_C_Vec2_CrossProduct()
    {
        C_V2 a = new C_V2(4, 3);
        C_V2 b = new C_V2(12, 9);

        float aCrossB = a.x * b.y + a.y * b.x;

        Assert.AreEqual(aCrossB, C_V2.CrossProduct(a, b));

        a = new C_V2(5, 6);
        b = new C_V2(15, 12);

        aCrossB = a.x * b.y + a.y * b.x;

        Assert.AreEqual(aCrossB, C_V2.CrossProduct(a, b));
    }
}

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
            new C_Point2D(0.0F, -1.0F) + new C_Point2D(0.0F, 1.0F));

        Assert.True(new C_V2(0.0F, 2.0F) ==
            new C_Point2D(0.0F, 1.0F) + new C_Point2D(0.0F, 1.0F));

        Assert.True(new C_V2(1.0F, 1.0F) ==
            new C_Point2D(1.0F, 0.0F) + new C_Point2D(0.0F, 1.0F));
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
