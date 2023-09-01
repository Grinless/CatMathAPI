using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class C_Probability
{
    private static readonly C_Seq2 pRange = new C_Seq2(0, 1);

    public static float NieveProb(int numberOfOutcomesInA, int totalOutcomes)
    {
        return numberOfOutcomesInA / totalOutcomes;
    }

    public static double[] ConvertToProbability(float[] values, C_Seq2 initalRange)
    {
        double[] converted = new double[values.Length];

        for (int i = 0; i < values.Length; i++)
        {
            converted[i] = C_Math.ConvertToRange(values[i], initalRange, pRange);
        }

        return converted; 
    }

    public static double ConvertToProbability(float number, C_Seq2 initalRange) =>
         C_Math.ConvertToRange(number, initalRange, pRange);

    public static double Compliment(double a)
    {
        return 1 - a;
    }

}
