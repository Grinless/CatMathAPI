﻿using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test_C_Probability
{
    [Test]
    public void Test_C_Probability_Compliment()
    {   
        Assert.AreEqual(1 - 0.05D, C_Probability.Compliment(0.05D));
        Assert.AreEqual(1 - 0.10D, C_Probability.Compliment(0.10D));
        Assert.AreEqual(1 - 0.15D, C_Probability.Compliment(0.15D));
        Assert.AreEqual(1 - 0.20D, C_Probability.Compliment(0.20D));
        Assert.AreEqual(1 - 0.25D, C_Probability.Compliment(0.25D));
        Assert.AreEqual(1 - 0.30D, C_Probability.Compliment(0.30D));
        Assert.AreEqual(1 - 0.35D, C_Probability.Compliment(0.35D));
        Assert.AreEqual(1 - 0.40D, C_Probability.Compliment(0.40D));
        Assert.AreEqual(1 - 0.45D, C_Probability.Compliment(0.45D));
        Assert.AreEqual(1 - 0.50D, C_Probability.Compliment(0.50D));
    }

    [Test]
    public void Test_C_Probability_ConvertToProbability()
    {
        Assert.AreEqual(0.5D, C_Probability.ConvertToProbability(50F, new C_Seq2(0, 100)));
        Assert.AreEqual(0.5D, C_Probability.ConvertToProbability(100F, new C_Seq2(0, 200)));
        Assert.AreEqual(0.25D, C_Probability.ConvertToProbability(25F, new C_Seq2(0, 100)));
        Assert.AreEqual(0.25D, C_Probability.ConvertToProbability(50F, new C_Seq2(0, 200)));
    }

    [Test]
    public void Test_C_Probability_RangeConversions()
    {
        C_Seq2 range = new C_Seq2(0, 100);
        float[] values = new float[] { 25F, 50F, 75F, 100F};
        double[] expected =  new double[] { 0.25D, 0.50D, 0.75D, 1.0D};
        double[] conversions = C_Probability.ConvertToProbability(values, range);

        //string output = ""; 

        for (int i = 0; i < conversions.Length; i++)
        {
            //If debugging. 
            //output += CreateProbConversionString(range, values[i], conversions[i], expected[i]); 
            Assert.AreEqual(expected[i], conversions[i]);
        }

        //Debug.Log(output);

        //string CreateProbConversionString(C_Seq2 range, float inital,
        //double conversion, double expected)
        //{
        //    return "Inital range " + range.ToString() + ", Inital: " + inital +
        //            ", Converted: " + conversion.ToString() +
        //            ", Expected: " + expected.ToString() + "\n";
        //}
    }
}