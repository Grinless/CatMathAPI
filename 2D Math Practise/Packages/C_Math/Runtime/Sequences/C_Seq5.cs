
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