using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_C_Seq3
{
    C_Seq3 instA;

    [SetUp]
    public void Setup()
    {
        instA = new C_Seq3(1.0F, 2.0F, 5.0F);
    }

    [Test]
    public void Test_C_Seq3SimplePasses()
    {
        //Set to pass as baseline. 
        Assert.True(true);
    }

    [Test]
    public void Test_C_Seq3Creation()
    {
        //Test the setup initalization. 
        Assert.AreEqual(1.0F, instA.E0);
        Assert.AreEqual(2.0F, instA.E1);
        Assert.AreEqual(5.0F, instA.E2);
        Assert.AreNotEqual(2.0F, instA.E2);
        Assert.AreNotEqual(1.0F, instA.E1);
        Assert.AreNotEqual(5.0F, instA.E0);

        //Reinitalise & re-test.
        instA = new C_Seq3(3.0F, 4.0F, 8.0F);
        Assert.AreEqual(3.0F, instA.E0);
        Assert.AreEqual(4.0F, instA.E1);
        Assert.AreEqual(8.0F, instA.E2);
        Assert.AreNotEqual(4.0F, instA.E2);
        Assert.AreNotEqual(3.0F, instA.E1);
        Assert.AreNotEqual(8.0F, instA.E0);
    }

    [Test]
    public void Test_C_Seq3Shorthand_Zero()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq3(0, 0, 0), C_Seq3.Zero);
    }

    [Test]
    public void Test_C_Seq3Shorthand_SeqX()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq3(1, 0, 0), C_Seq3.SeqX);
    }

    [Test]
    public void Test_C_Seq3Shorthand_SeqY()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq3(0, 1, 0), C_Seq3.SeqY);
    }

    [Test]
    public void Test_C_Seq3Shorthand_SeqZ()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq3(0, 0, 1), C_Seq3.SeqZ);
    }

    [Test]
    public void Test_CSeq3_Equality()
    {
        C_Seq3 a = new C_Seq3(1, 2, 3);
        C_Seq3 b = new C_Seq3(1, 2, 3);

        Assert.AreEqual(a, b);
    }

    [Test]
    public void Test_CSeq3_Inequality()
    {
        C_Seq3 a = new C_Seq3(1, 2, 3);
        C_Seq3 b = new C_Seq3(2, 2, 2);

        Assert.AreNotEqual(a, b);
    }
}
