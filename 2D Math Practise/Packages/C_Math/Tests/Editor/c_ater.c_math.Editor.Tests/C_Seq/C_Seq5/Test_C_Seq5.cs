using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_C_Seq5
{
    C_Seq5 instA;

    [SetUp]
    public void Setup()
    {
        instA = new C_Seq5(1.0F, 2.0F, 3.0F, 4.0F, 5.0F);
    }

    [Test]
    public void Test_C_Seq4SimplePasses()
    {
        //Set to pass as baseline. 
        Assert.True(true);
    }

    [Test]
    public void Test_C_Seq5Creation()
    {
        //Test the setup initalization. 
        Assert.AreEqual(1.0F, instA.E0);
        Assert.AreEqual(2.0F, instA.E1);
        Assert.AreEqual(3.0F, instA.E2);
        Assert.AreEqual(4.0F, instA.E3);
        Assert.AreEqual(5.0F, instA.E4);
        Assert.AreNotEqual(1.0F, instA.E4);
        Assert.AreNotEqual(2.0F, instA.E3);
        Assert.AreNotEqual(1.0F, instA.E2);
        Assert.AreNotEqual(4.0F, instA.E1);
        Assert.AreNotEqual(5.0F, instA.E0);
    }

    [Test]
    public void Test_C_Seq5GetElement()
    {
        //Test the setup initalization. 
        Assert.AreEqual(1.0F, instA.GetElement(0));
        Assert.AreEqual(2.0F, instA.GetElement(1));
        Assert.AreEqual(3.0F, instA.GetElement(2));
        Assert.AreEqual(4.0F, instA.GetElement(3));
        Assert.AreEqual(5.0F, instA.GetElement(4));
        Assert.AreNotEqual(1.0F, instA.GetElement(4));
        Assert.AreNotEqual(2.0F, instA.GetElement(3));
        Assert.AreNotEqual(1.0F, instA.GetElement(2));
        Assert.AreNotEqual(4.0F, instA.GetElement(1));
        Assert.AreNotEqual(5.0F, instA.GetElement(0));
    }
}