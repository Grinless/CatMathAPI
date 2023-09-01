using UnityEngine;

[System.Serializable]
public struct C_Point3D
{
    public float x;
    public float y;
    public float z;

    public C_Point3D(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z; 
    }

    public C_Point3D(Vector2 vec) : this(vec.x, vec.y, 0)
    {
    }

    public C_Point3D(Vector3 vec) : this(vec.x, vec.y, vec.z)
    {
    }

    public void DrawPoint()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(this, 0.5f);
    }

    public static implicit operator Vector2(C_Point3D a)
    {
        return new Vector2(a.x, a.y);
    }

    public static implicit operator Vector3(C_Point3D a)
    {
        return new Vector3(a.x, a.y, a.z);
    }

    public static implicit operator C_V3(C_Point3D a) =>
        new C_V3(a.x, a.y, a.z);

    public static C_Point3D operator +(C_Point3D a, C_Point3D b)
    {
        return new C_Point3D(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static C_Point3D operator *(int a, C_Point3D b)
    {
        return ((float)a * b);
    }

    public static C_Point3D operator *(float a, C_Point3D b)
    {
        return new C_Point3D(a * b.x, a *  b.y, a * b.z);
    }

    public static C_Point3D operator -(C_Point3D a, C_Point3D b)
    {
        return a + (-1 * b);
    }
}