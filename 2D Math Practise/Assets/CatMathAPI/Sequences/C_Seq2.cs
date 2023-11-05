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
