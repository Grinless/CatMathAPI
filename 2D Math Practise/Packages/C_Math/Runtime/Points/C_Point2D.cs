using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct C_P2D
{
    public float x; 
    public float y;

    public C_P2D(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public C_P2D(Vector2 vec) : this(vec.x, vec.y)
    {
    }

    public void DrawPoint()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(new Vector3(x, y), 0.5f);
    }

    public static implicit operator C_V2(C_P2D a)
    {
        return new C_V2(a.x, a.y);
    }

    public static implicit operator Vector2(C_P2D a)
    {
        return new Vector2(a.x, a.y);
    }

    public static implicit operator Vector3(C_P2D a)
    {
        return new Vector3(a.x, a.y, 0);
    }

    public static explicit operator C_P2D(C_V2 a)
    {
        return new C_P2D(a.x, a.y);
    }

    public static C_P2D operator +(C_P2D a, C_P2D b)
    {
        return new C_P2D(a.x + b.x, a.y + b.y);
    }

    public static C_P2D operator +(C_P2D a, C_V2 b)
    {
        return new C_P2D(a.x + b.x, a.y + b.y);
    }

    public static C_P2D operator -(C_P2D a, C_P2D b)
    {
        return new C_P2D(a.x - b.x, a.y - b.y);
    }
}
