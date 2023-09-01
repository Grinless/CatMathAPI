using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_C_Seq2
{
    C_Seq2 instA;

    [SetUp]
    public void Setup()
    {
        instA = new C_Seq2(1.0F, 2.0F);
    }


    [Test]
    public void Test_C_Seq2SimplePasses()
    {
        //Set to pass as baseline. 
        Assert.True(true);
    }

    [Test]
    public void Test_C_Seq2Creation()
    {
        //Test the setup initalization. 
        Assert.AreEqual(1.0F, instA.E0);
        Assert.AreEqual(2.0F, instA.E1);
        Assert.AreNotEqual(1.0F, instA.E1);
        Assert.AreNotEqual(2.0F, instA.E0);

        //Reinitalise & re-test.
        instA = new C_Seq2(3.0F, 4.0F);
        Assert.AreEqual(3.0F, instA.E0);
        Assert.AreEqual(4.0F, instA.E1);
        Assert.AreNotEqual(3.0F, instA.E1);
        Assert.AreNotEqual(4.0F, instA.E0);
    }

    [Test]
    public void Test_C_Seq2Shorthand_Zero()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq2(0, 0), C_Seq2.Zero); 
    }

    [Test]
    public void Test_C_Seq2Shorthand_SeqX()
    {
        //Test that shorthand references are as expected.
        Assert.AreEqual(new C_Seq2(1, 0), C_Seq2.SeqX);
    }

    [Test]
    public void Test_C_Seq2Shorthand_SeqY()
    {
        //Test that shorthand references are as expected. 
        Assert.AreEqual(new C_Seq2(0, 1), C_Seq2.SeqY);
    }

    [Test]
    public void Test_C_Seq2GetElement()
    {
        //Test that the element accessing function is working with inital setup. 
        Assert.AreEqual(1.0F, instA.GetElement(0));
        Assert.AreEqual(2.0F, instA.GetElement(1));
        Assert.AreNotEqual(1.0F, instA.GetElement(1));
        Assert.AreNotEqual(2.0F, instA.GetElement(0));

        //Test that the reinitalised version carries same functionality. 
        instA = new C_Seq2(3.0F, 4.0F);

        Assert.AreEqual(3.0F, instA.GetElement(0));
        Assert.AreEqual(4.0F, instA.GetElement(1));
        Assert.AreNotEqual(3.0F, instA.GetElement(1));
        Assert.AreNotEqual(4.0F, instA.GetElement(0));
    }
}
