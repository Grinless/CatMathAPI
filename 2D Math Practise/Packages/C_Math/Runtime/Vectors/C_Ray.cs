using UnityEngine;
using C_Math.Collision;
using C_Math.Shapes;
using JetBrains.Annotations;

/// <summary>
/// Class responsible for generating rays. 
/// </summary>
[System.Serializable]
public struct C_Ray
{
    public C_P2D origin;
    public C_V2 direction;
    public float length;
    public float time;

    public Color rayColor;
    public Color originColor;
    public Color endColor;
    public Color currentRayColor;

    public C_V2 GetRayAtTime(float time)
    {
        float lerpValue = C_Math.C_MathF.Clamp(time, 0, length);
        return origin + (C_P2D)(lerpValue * direction.Unitized);
    }

    public static void SolveForIntercepts(
        C_Ray ray1, C_Ray ray2, out C_P2D iPRay1, out C_P2D iPRay2)
    {
        C_LineLineIntercept.SolveForIntercepts(ray1, ray2, out C_P2D a, out C_P2D b);
        iPRay1 = a; iPRay2 = b;
    }

    public static C_P2D SolveForIntercept(C_Ray ray1, C_Ray ray2) => 
        C_LineLineIntercept.SolveForIntercept(ray1, ray2);

    public C_Rect GetRayRect()
    {
        //Get the x length. 
        C_V2 parallel = C_V2.Parallel((length * direction));
        //Get the y length. 
        C_V2 perpendicular = C_V2.Perpendicular((length * direction));
        //get the center. 
        C_V2 rCenter = (C_V2)origin + ((length / 2) * direction);

        return new C_Rect((Vector3)rCenter, new Vector2(length/2, length/2), 0);
    }

    public void DrawRay()
    {
        Gizmos.color = rayColor;
        Vector3 endpoint = origin + length * (Vector3)direction.Unitized;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin, endpoint);
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(origin, 0.08f);
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(endpoint, 0.08f);
    }

    public void DrawCurrentLength()
    {
        Vector3 newVec = (Vector3)GetRayAtTime(time);
        Gizmos.color = currentRayColor;
        Gizmos.DrawSphere(newVec, 0.08f);
        Gizmos.DrawLine(origin, newVec);
    }

    public void DrawRayBoundingBox()
    {
        C_Rect bounds = GetRayRect();
        bounds.Draw();
    }
}
