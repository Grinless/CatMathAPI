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
