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

    public override bool Equals(object obj)
    {
        if (!(obj is C_Seq3)) 
            return false;

        C_Seq3 b = (C_Seq3)obj;
        if (E0 == b.E0 && 
            E1 == b.E1 && 
            E2 == b.E2) return true;
        return false;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        hash = hash * 23 + E0.GetHashCode();
        hash = hash * 23 + E1.GetHashCode();
        hash = hash * 23 + E2.GetHashCode();
        return hash;
    }

    public override string ToString()
    {
        return "[ " + E0 + ", " + E1.ToString() + ", " + E2.ToString() + "]";
    }

    public static bool operator ==(C_Seq3 a, C_Seq3 b)
    {
        return (a.E0 == b.E0 && a.E1 == b.E1 && a.E2 == b.E2);
    }

    public static bool operator !=(C_Seq3 a, C_Seq3 b)
    {
        return !(a == b);
    }
}
