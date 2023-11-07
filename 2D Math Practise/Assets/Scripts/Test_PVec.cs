using C_Math;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[System.Serializable]
public struct LineTester
{
    public C_P2D p1; 
    public C_P2D p2;
    
    public C_V2 VectorBetween => (p2 -  p1);

    public C_V2 GetUnitized => VectorBetween.Unitized;

    public C_V2 GetMidpoint
    {
        get
        {
            return C_MathF.GetLineMidpoint(p1, p2) * GetUnitized;
        }
    } 
        
        
}

public class Test_PVec : MonoBehaviour
{
    public C_V2 vec;
    public LineTester lineTester;

    public C_V2 v1Perp;
    public C_V2 v1Para;
    public C_V2 v1Reflection;

    private C_V2 GetPosAsC_V2
    {
        get => new C_V2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    private void OnDrawGizmos()
    {
        //Calculate Vectors. 
        v1Para = GetPosAsC_V2 + C_V2.Parallel(vec);
        v1Perp = GetPosAsC_V2 + C_V2.Perpendicular(vec);
        //v1Reflection = GetPosAsC_V2 + C_V2.Reflection(vec, pointNormal);


        //Draw vector. 
        Gizmos.color = Color.white;
        Gizmos.DrawLine(
            gameObject.transform.position, 
            gameObject.transform.position + (Vector3)((Vector2)vec)
            );

        //Draw parallel vector. 
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gameObject.transform.position, (Vector3)v1Para);

        //Draw perpendicular. 
        Gizmos.color = Color.green;
        Gizmos.DrawLine(gameObject.transform.position, (Vector3)v1Perp);

        //Draw reflection line. 
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(lineTester.p1, lineTester.p2);
        Gizmos.DrawSphere(lineTester.p1, 0.08F);
        Gizmos.DrawSphere(lineTester.p2, 0.08F);
        Gizmos.DrawSphere(lineTester.p1 + (Vector3)lineTester.GetMidpoint, 0.08F);

        ////Draw reflection normal. 
        //Gizmos.color = Color.white;
        //Gizmos.DrawLine(
        //    pointOfReflection,
        //    pointOfReflection + (Vector3)pointNormal
        //    );

        ////Draw reflection vector. 
        //Gizmos.color = Color.cyan;
        //C_V2 reflection = C_V2.Reflection(vec, pointNormal);
        //Gizmos.DrawLine(
        //    pointOfReflection,
        //    (Vector3)v1Reflection
        //    );

        //Gizmos.color = Color.white;
        //Gizmos.DrawLine(
        //    pointOfReflection2,
        //    pointOfReflection2 + (Vector3)pointNormal2
        //    );

        //Gizmos.color = Color.cyan;
        //C_V2 reflection2 = C_V2.Reflection(reflection, pointNormal2);
        //Gizmos.DrawLine(
        //    pointOfReflection2,
        //    pointOfReflection2 + (Vector3)reflection2
        //    );
    }
}
