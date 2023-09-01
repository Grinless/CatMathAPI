/// <summary>
/// A struct containing information about the Normal of a 2D Vector. 
/// </summary>
public struct C_Norm2D
{
    /// <summary>
    /// The point at which the vector originates. 
    /// </summary>
    public C_Point2D midPoint;

    /// <summary>
    /// The direction of the normal. 
    /// </summary>
    public C_V2 normal;

    public C_Norm2D(C_Point2D midPoint, C_V2 normal)
    {
        this.midPoint = midPoint;
        this.normal = normal;
    }
}
