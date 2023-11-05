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
