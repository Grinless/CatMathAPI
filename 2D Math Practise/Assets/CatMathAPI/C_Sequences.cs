public struct C_Seq2
{
    public float E0;
    public float E1;

    #region Shorthand Ref Properties. 
    private static readonly C_Seq2 _zero = new(0, 0);
    private static readonly C_Seq2 _seqX = new(1, 0);
    private static readonly C_Seq2 _seqY = new(0, 1);

    public static C_Seq2 Zero => _zero;
    public static C_Seq2 SeqX => _seqX;
    public static C_Seq2 SeqY => _seqY;
    #endregion

    public C_Seq2(float element1, float element2)
    {
        E0 = element1;
        E1 = element2;
    }

    public static void Copy(C_Seq2 a, ref  C_Seq2 b)
    {
        b.E0 = a.E0;
        b.E1 = a.E1;
    }

    public static void RowInterchange(ref C_Seq2 a, ref C_Seq2 b)
    {
        C_Seq2 r1Copy = new(0, 0);
        C_Seq2 r2Copy = new(0, 0);

        C_Seq2.Copy(a, ref r1Copy);
        C_Seq2.Copy(b, ref r2Copy);

        a.E0 = r2Copy.E0;
        a.E1 = r2Copy.E1;
        b.E0 = r1Copy.E0;
        b.E1 = r1Copy.E1;

    }

    public static implicit operator C_Seq3(C_Seq2 a) => 
        new(a.E0, a.E1, 0);

    public readonly float GetElement(int ID)
    {
        if (ID < 0 || ID > 1)
            return float.NaN;

        switch (ID)
        {
            case 0:
                return E0;
            case 1:
                return E1;
            default: return float.NaN;
        }
    }

    public override string ToString()
    {
        return string.Format("[{0} {1}]", E0, E1);
    }

    public override bool Equals(object obj)
    {
        if(!(obj is C_Seq2)) return false;
        C_Seq2 cs2 = (C_Seq2)obj;
        if(E0 == cs2.E0 && E1 == cs2.E1) return true;
        return false;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + E1.GetHashCode();
        hash = hash * 23 + E0.GetHashCode();
        return hash;
    }

    public static bool operator ==(C_Seq2 a, C_Seq2 b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(C_Seq2 a, C_Seq2 b)
    {
        return a.Equals(b);
    }
}

public struct C_Seq3
{
    public float E0;
    public float E1;
    public float E2;

    #region Shorthand Ref Properties. 

    private static readonly C_Seq3 _zero = new(0, 0, 0);
    private static readonly C_Seq3 _seqX = new(1, 0, 0);
    private static readonly C_Seq3 _seqY = new(0, 1, 0);
    private static readonly C_Seq3 _seqZ = new(0, 0, 1);

    public static C_Seq3 Zero => _zero;
    public static C_Seq3 SeqX => _seqX;
    public static C_Seq3 SeqY => _seqY;
    public static C_Seq3 SeqZ => _seqZ;
    #endregion

    public C_Seq3(float element1, float element2, float element3)
    {
        E0 = element1;
        E1 = element2;
        E2 = element3;
    }

    public static implicit operator C_Seq2(C_Seq3 column) =>
        new C_Seq2(column.E0, column.E1);

    public static C_Seq3 operator *(float a, C_Seq3 b) =>
        new(a * b.E0, a * b.E1, a * b.E2);

    public readonly float GetElement(int ID)
    {
        if (ID < 0 || ID > 2)
            return float.NaN;

        switch (ID)
        {
            case 0:
                return E0;
            case 1:
                return E1;
            case 2:
                return E2;
            default: return float.NaN;
        }
    }
}

public struct C_Seq4
{
    public float E0; 
    public float E1;
    public float E2;
    public float E3;

    #region Shorthand Ref Properties.
    private static readonly C_Seq4 _zero = new(0, 0, 0, 0);
    private static readonly C_Seq4 _seqX = new(1, 0, 0, 0);
    private static readonly C_Seq4 _seqY = new(0, 1, 0, 0);
    private static readonly C_Seq4 _seqZ = new(0, 0, 1, 0);
    private static readonly C_Seq4 _seqW = new(0, 0, 0, 1);

    public static C_Seq4 Zero => _zero;
    public static C_Seq4 SeqX => _seqX;
    public static C_Seq4 SeqY => _seqY;
    public static C_Seq4 SeqZ => _seqZ;
    public static C_Seq4 SeqW => _seqW;
    #endregion

    public C_Seq4(float x, float y, float z,  float w)
    {
        E0 = x; 
        E1 = y;
        E2 = z;
        E3 = w; 
    }

    public static C_Seq4 operator *(float a, C_Seq4 b) =>
        new(a * b.E0, a * b.E1, a * b.E2, a * b.E3);

    public readonly float GetElement(int ID)
    {
        if(ID < 0 || ID > 3)
            return float.NaN; 

        switch (ID)
        {
            case 0:
                return E0;
            case 1:
                return E1;
            case 2:
                return E2;
            case 3:
                return E3;
            default: return float.NaN;
        }
    }
}

public struct C_Seq5
{
    public float E0;
    public float E1;
    public float E2;
    public float E3;
    public float E4;

    #region Shorthand Ref Properties.
    private static readonly C_Seq5 _zero = new(0, 0, 0, 0, 0);
    private static readonly C_Seq5 _seqX = new(1, 0, 0, 0, 0);
    private static readonly C_Seq5 _seqY = new(0, 1, 0, 0, 0);
    private static readonly C_Seq5 _seqZ = new(0, 0, 1, 0, 0);
    private static readonly C_Seq5 _seqW = new(0, 0, 0, 1, 0);
    private static readonly C_Seq5 _seqK = new(0, 0, 0, 0, 1);
    public static C_Seq5 Zero => _zero;
    public static C_Seq5 SeqX => _seqX;
    public static C_Seq5 SeqY => _seqY;
    public static C_Seq5 SeqZ => _seqZ;
    public static C_Seq5 SeqW => _seqW;
    public static C_Seq5 SeqK => _seqK;
    #endregion

    public C_Seq5(float e1, float e2, float e3, float e4, float e5)
    {
        E0 = e1;
        E1 = e2;
        E2 = e3;
        E3 = e4;
        E4 = e5;
    }

    public static C_Seq5 operator *(float a, C_Seq5 b) =>
        new(a * b.E0, a * b.E1, a * b.E2, a * b.E3, a * b.E4);

    public readonly float GetElement(int ID)
    {
        if (ID < 0 || ID > 4)
            return float.NaN;

        switch (ID)
        {
            case 0:
                return E0;
            case 1:
                return E1;
            case 2:
                return E2;
            case 3:
                return E3;
            case 4:
                return E4;
            default: return float.NaN;
        }
    }
}