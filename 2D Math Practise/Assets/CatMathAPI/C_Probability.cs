using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Rendering;
using UnityEngine;

public struct Factorial
{
    public int n;
    public int r;

    public Factorial(int n)
    {
        this.n = n;
        r = 0; 
    }

    public Factorial(int n, int r)
    {
        this.n = n;
        this.r = r;
    }
    public int[] Expand(int _n, int _r)
    {
        int[] values = new int[_n];

        for (int i = 0; i < _n - r; i++)
            values[i] = _n - i;

        return values;
    }

    public int Multiply()
    {
        int output = n;
        int[] factorialExpansion = Expand(n, 0);
        Debug.Log("Output Init: " + output);

        for (int i = 1; i < factorialExpansion.Length; i++)
            output *= factorialExpansion[i];
        return output;
    }

    public int MultiplyWithR()
    {
        int output = n;
        int[] factorialExpansion = Expand(n, r);
        Debug.Log("Output Init: " + output);

        for (int i = 1; i < factorialExpansion.Length; i++)
            output *= factorialExpansion[i];
        return output;
    }
}

public struct C_Permutations
{
    public Factorial n;

    public C_Permutations(int n, int r)
    {
        this.n = new Factorial(n, r);
    }

    public int GetPermutations()
    {
        int numerator = n.Multiply();
        int denomenator = n.MultiplyWithR();
        if (denomenator == 0)
            return 0; 
        return numerator / denomenator;
    }
}

public struct C_Combinatorial
{
    public Factorial n;
    public Factorial r;

    public C_Combinatorial(int n, int r)
    {
        this.n = new Factorial(n);
        this.r = new Factorial(r);
    }

    public int GetPermutations()
    {
        int numerator = n.Multiply();
        int denomenator = n.MultiplyWithR();
        if (denomenator == 0)
            return 0;
        return numerator / (denomenator) * r.Multiply();
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
            converted[i] = C_Math.ConvertToRange(values[i], initalRange, pRange);
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
         C_Math.ConvertToRange(number, initalRange, pRange);

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
