using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
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
        Assert.AreEqual(new C_V2(-1.0F / denom, 0.0F / denom), c1);

        c1 = new C_V2(-0.5F, 0.5F);
        c1.Unitize();
        denom = Mathf.Sqrt((-0.5F) * (-0.5F) + 0.5F * 0.5F);
        Assert.AreEqual(new C_V2(-0.5F / denom, 0.5F / denom), c1);
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
    public void Test_C_Vec2_AngleBetweenRad()
    {
        C_V2 a = new C_V2(0.0F, -1.0F);
        C_V2 b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(Mathf.Acos(-1), C_V2.AngleBetweenRad(a, b));

        a = new C_V2(0.0F, 1.0F);
        b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(Mathf.Acos(1), C_V2.AngleBetweenRad(a, b));

        a = new C_V2(1.0F, 0.0F);
        b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(Mathf.Acos(0.0F), C_V2.AngleBetweenRad(a, b));

        a = new C_V2(-1.0F, 0.0F);
        b = new C_V2(0.0F, -1.0F);
        Assert.AreEqual(Mathf.Acos(0.0F), C_V2.AngleBetweenRad(a, b));

        a = new C_V2(2.5F, 2.5F).Unitized;
        b = new C_V2(1.0F, 0.0F).Unitized;
        Assert.AreEqual(0.707106769F, C_V2.DotProduct(a, b));
    }

    [Test]
    public void Test_C_Vec2_AngleBetweenDeg()
    {
        C_V2 a = new C_V2(0.0F, -1.0F);
        C_V2 b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(180.0F, C_V2.AngleBetweenDeg(a, b), "Test A");

        a = new C_V2(0.0F, 1.0F);
        b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(0.0F, C_V2.AngleBetweenDeg(a, b), "Test B");

        a = new C_V2(1.0F, 0.0F);
        b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(90.0F, C_V2.AngleBetweenDeg(a, b), "Test C");

        a = new C_V2(-1.0F, 0.0F);
        b = new C_V2(0.0F, -1.0F);
        Assert.AreEqual(90.0F, C_V2.AngleBetweenDeg(a, b), "Test D");

        a = new C_V2(-1.0F, 0.0F);
        b = new C_V2(1.0F, 0.0F);
        Assert.AreEqual(180.0F, C_V2.AngleBetweenDeg(a, b), "Test D");

        a = new C_V2(0.0F, -1.0F);
        b = new C_V2(0.0F, 1.0F);
        Assert.AreEqual(180.0F, C_V2.AngleBetweenDeg(a, b), "Test D");
    }

    [Test]
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

    //TODO: Expand this test and split into two tests. 
    [Test]
    public void Test_C_Vec2_VectorProjection()
    {
        C_V2 a = new C_V2(4, 3);
        C_V2 b = new C_V2(12, 9);

        Assert.AreEqual(new C_V2(4, 3), C_V2.ProjectionAB(a, b));
        Assert.AreEqual(5, C_V2.ProjectionABMagnitude(a, b));
    }
}