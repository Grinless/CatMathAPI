using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Rendering;
using UnityEngine;
using C_Math;

public struct Factorial
{
    public int n;

    public Factorial(int n)
    {
        this.n = n;
    }

    public int[] Expansion => Expand(); 

    public int Value => Multiply(Expansion);

    private int[] Expand(int value)
    {
        int[] values = new int[n];

        for (int i = 0; i < n; i++)
            values[i] = n - i;

        return values;
    }

    private int[] Expand()
    {
        int[] values = new int[n];

        for (int i = 0; i < n; i++)
            values[i] = n - i;

        return values;
    }

    private int Multiply(int[] factors)
    {
        int output = factors[0];

        for (int i = 1; i < factors.Length; i++)
            output *= factors[i];
        return output;
    }

    public int NFacR(Factorial factorial)
    {
        return Multiply(Expand(n - factorial.n));
    }

    public string GetString()
    {
        string output =
            "Factor N: " + n + ", Factorial N: " + Value + "\n" +
            "Expansion N: \n";

        int[] expansionN = Expand();

        for (int i = 0; i < expansionN.Length; i++)
        {
            output += "(I: " + i + ", Coeff: " + expansionN[i] + ") \n";
        }

        return output;
    }
}

public class C_Probability
{
    //The [0, 1] range that probability is confined within. 
    private static readonly C_Seq2 pRange = new C_Seq2(0, 1);

    /// <summary>
    /// Returns the nieve probability: 
    /// number of outcomes in A/total outcomes. 
    /// </summary>
    /// <param name="numberOfOutcomesInA"> The number of outcomes in the set. </param>
    /// <param name="totalOutcomes"> The total number of possible outcomes. </param>
    public static float NieveProb(int numberOfOutcomesInA, int totalOutcomes)
    {
        return numberOfOutcomesInA / totalOutcomes;
    }

    /// <summary>
    /// returns an array of numbers converted to the range[0,1].
    /// </summary>
    /// <param name="values"> The values to convert. </param>
    /// <param name="initalRange"> The orignal range that the values were within. </param>
    public static double[] ConvertToProbability(float[] values, C_Seq2 initalRange)
    {
        double[] converted = new double[values.Length];

        for (int i = 0; i < values.Length; i++)
        {
            converted[i] = C_MathF.ConvertToRange(values[i], initalRange, pRange);
        }

        return converted;
    }

    /// <summary>
    /// Returns the value converted to the range [0, 1]. 
    /// </summary>
    /// <param name="number"> The number to convert. </param>
    /// <param name="initalRange"> The inital range that the number was confined within. </param>
    /// <returns></returns>
    public static double ConvertToProbability(float number, C_Seq2 initalRange) =>
         C_MathF.ConvertToRange(number, initalRange, pRange);

    /// <summary>
    /// Get the compliment of a. 
    /// </summary>
    /// <param name="a"> The probabalistic value to derive the complement of. </param>
    public static double Compliment(double a)
    {
        return 1 - a;
    }

    public static double AUB_Independant(double a, double b)
    {
        return a * b;
    }

    public static double AUB_Dependant(double a, double b)
    {
        return a * b;
    }

    public static bool MutuallyEx(double a, double b)
    {
        double AUB = AUB_Independant(a, b);

        return (AUB == 0.0D) ? true : false;
    }
}
