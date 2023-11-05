using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using C_Math;

public class Test_C_MathF
{
    [Test]
    public void Test_C_RangeConversions()
    {
        Assert.AreEqual(0.5F, C_MathF.ConvertToRange(5.0F, new C_Seq2(0.0F, 10.0F), new C_Seq2(0.0F, 1.0F)));
        Assert.AreEqual(0.5F, C_MathF.ConvertToRange(1.0F, new C_Seq2(0.0F, 2.0F), new C_Seq2(0.0F, 1.0F)));
        Assert.AreEqual(2.0F, C_MathF.ConvertToRange(4.0F, new C_Seq2(0.0F, 8.0F), new C_Seq2(0.0F, 4.0F)));
    }

    [Test]
    public void Test_C_Min()
    {
        Assert.AreEqual( 5.0F, C_MathF.Min( 5.0F,  3.0F));
        Assert.AreEqual( 3.0F, C_MathF.Max( 3.0F,  5.0F));
        Assert.AreEqual( 5.0F, C_MathF.Min(-3.0F,  5.0F));
        Assert.AreEqual( 3.0F, C_MathF.Min( 3.0F, -5.0F));
        Assert.AreEqual(-5.0F, C_MathF.Min(-6.0F, -5.0F));
        Assert.AreEqual(-3.0F, C_MathF.Min(-3.0F, -5.0F));
    }

    [Test]
    public void Test_C_Max()
    {
        Assert.AreEqual( 3.0F, C_MathF.Max( 5.0F,  3.0F));
        Assert.AreEqual( 3.0F, C_MathF.Max( 3.0F,  5.0F));
        Assert.AreEqual(-3.0F, C_MathF.Max(-3.0F,  5.0F));
        Assert.AreEqual(-5.0F, C_MathF.Max(-3.0F, -5.0F));
        Assert.AreEqual(-6.0F, C_MathF.Max(-6.0F, -5.0F));
    }

    [Test]
    public void Test_C_Abs()
    {
        Assert.AreEqual(1.0F, C_MathF.Abs(-1.0F));
        Assert.AreEqual(2.0F, C_MathF.Abs(-2.0F));
        Assert.AreEqual(3.0F, C_MathF.Abs(-3.0F));
        Assert.AreEqual(4.0F, C_MathF.Abs(-4.0F));
        Assert.AreEqual(5.0F, C_MathF.Abs(-5.0F));

        Assert.AreEqual(1.0F, C_MathF.Abs(1.0F));
        Assert.AreEqual(2.0F, C_MathF.Abs(2.0F));
        Assert.AreEqual(3.0F, C_MathF.Abs(3.0F));
        Assert.AreEqual(4.0F, C_MathF.Abs(4.0F));
        Assert.AreEqual(5.0F, C_MathF.Abs(5.0F));
    }

    [Test]
    public void Test_C_Clamp()
    {
        Assert.AreEqual(0.0F, C_MathF.Clamp(-1.0F,  0.0F,  1.0F));
        Assert.AreEqual(1.0F, C_MathF.Clamp( 2.0F,  0.0F,  1.0F));
        Assert.AreEqual(2.0F, C_MathF.Clamp( 2.5F,  1.0F,  2.0F));
        Assert.AreEqual(-2.0F, C_MathF.Clamp( 2.0F, -1.0F, -2.0F));
        Assert.AreEqual(-1.0F, C_MathF.Clamp(-2.0F, -1.0F, -0.5F));

        Assert.AreEqual( 0.0F, C_MathF.Clamp(-1.0F, new C_V2( 0.0F,  1.0F)));
        Assert.AreEqual( 1.0F, C_MathF.Clamp( 2.0F, new C_V2( 0.0F,  1.0F)));
        Assert.AreEqual( 2.0F, C_MathF.Clamp( 2.5F, new C_V2( 1.0F,  2.0F)));
        Assert.AreEqual(-2.0F, C_MathF.Clamp( 2.0F, new C_V2(-1.0F, -2.0F)));
        Assert.AreEqual(-1.0F, C_MathF.Clamp(-2.0F, new C_V2(-1.0F, -0.5F)));

        Assert.AreEqual( 0.0F, C_MathF.Clamp(-1.0F, new C_Seq2( 0.0F,  1.0F)));
        Assert.AreEqual( 1.0F, C_MathF.Clamp( 2.0F, new C_Seq2( 0.0F,  1.0F)));
        Assert.AreEqual( 2.0F, C_MathF.Clamp( 2.5F, new C_Seq2( 1.0F,  2.0F)));
        Assert.AreEqual(-2.0F, C_MathF.Clamp( 2.0F, new C_Seq2(-1.0F, -2.0F)));
        Assert.AreEqual(-1.0F, C_MathF.Clamp(-2.0F, new C_Seq2(-1.0F, -0.5F)));
    }

    [Test]
    public void Test_C_PerpendicularCW()
    {
        Assert.AreEqual(Vector2.down.normalized, C_MathF.PerpendicularCW(Vector2.right.normalized));
        Assert.AreEqual(Vector2.left.normalized, C_MathF.PerpendicularCW(Vector2.down.normalized));
        Assert.AreEqual(Vector2.up.normalized, C_MathF.PerpendicularCW(Vector2.left.normalized));
        Assert.AreEqual(Vector2.right.normalized, C_MathF.PerpendicularCW(Vector2.up.normalized));
    }

    [Test]
    public void Test_C_PerpendicularCCW()
    {
        Assert.AreEqual(Vector2.up.normalized, C_MathF.PerpendicularCCW(Vector2.right.normalized));
        Assert.AreEqual(Vector2.left.normalized, C_MathF.PerpendicularCCW(Vector2.up.normalized));
        Assert.AreEqual(Vector2.down.normalized, C_MathF.PerpendicularCCW(Vector2.left.normalized));
        Assert.AreEqual(Vector2.right.normalized, C_MathF.PerpendicularCCW(Vector2.down.normalized));
    }
}