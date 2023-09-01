using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

public static class C_Math
{
    public const double E = 2.7182818284590451;
    public const double PI = 3.1415926535897931;
    public const double Rad2Deg = 180/PI;
    public const double Deg2Rad = PI/180;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Max(float a, float max) => 
        (a > max) ? max : a;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Min(float a, float min) => 
        (a < min) ? min : a;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Greater(float a, float b) =>
        (a > b) ? a : b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Lesser(float a, float b) => 
        (a < b) ? a : b;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Abs(float a) => 
        ((a < 0) ? -1 : 1) * a;

    public static float Clamp(float value, float min, float max) =>
        (value < min) ? min : (value > max) ? max : value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Clamp(float value, C_V2 range) =>
        Clamp(value, range.x, range.y);

}
