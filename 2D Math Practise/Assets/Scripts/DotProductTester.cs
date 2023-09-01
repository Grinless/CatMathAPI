using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotProductTester : MonoBehaviour
{
    public Transform transA;
    public Transform transB;
    public C_V2 facingDirA;
    public C_V2 facingDirB;
    public bool sameDir;
    public bool inverseDir;
    public bool perpDir;
    public float dotProduct;

    public C_Point2D APosition
    {
        get => new C_Point2D(transA.position.x, transA.position.y);
    }

    public C_Point2D BPosition
    {
        get => new C_Point2D(transB.position.x, transB.position.y);
    }

    public C_V2 FWDVecA => APosition + facingDirA.Normalized;
    public C_V2 FWDVecB => BPosition + facingDirB.Normalized;

    private void Start()
    {
        C_Point2D a = new C_Point2D(0, 0);
        C_Point2D b = new C_Point2D(0, 1); 
        C_V2 AB = (b - a);
        C_V2 FWDB = new C_V2(0, -1);
        FWDB.Normalize();
        AB.Normalize();
        Debug.Log("CM: Dot Prod: " + C_V2.DotProduct(AB, FWDB));
        Debug.Log("MF: Dot Prod: " + Vector2.Dot(AB, FWDB));
    }


    #region Dot Product Debug. 
    public bool debug_DisplayLineAB = false;
    public bool debug_AForward = false;
    public bool debug_BForward = false;

    void DebugDotProd()
    {
        //Draw the line between.
        if (debug_DisplayLineAB)
        {
            Debug.DrawLine(APosition, BPosition, Color.green);
        }

        //Draw A Forward. 
        if (debug_AForward)
        {
            DebugFwrdVec(APosition, facingDirA, Color.red);
        }

        //Draw B Forward. 
        if (debug_BForward)
        {
            DebugFwrdVec(BPosition, facingDirB, Color.blue);
        }

        void DebugFwrdVec(C_Point2D pos, C_V2 direction, Color color)
        {
            Debug.DrawLine(pos, pos + direction.Normalized, color);
        }
    }
    #endregion
}
