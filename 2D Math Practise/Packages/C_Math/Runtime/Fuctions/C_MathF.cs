using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace C_Math
{
    public static class C_MathF
    {
        public const double E = 2.7182818284590451D;
        public const double PI = 3.1415926535897931D;
        public const double Rad2Deg = 180F / PI;
        public const double Deg2Rad = PI / 180F;

        /// <summary>
        /// Limit a value to the passed maximum.
        /// </summary>
        /// <param name="a"> The value to limit. </param>
        /// <param name="max"> The maximum that value can be.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float a, float max) =>
            (a > max) ? max : a;

        /// <summary>
        /// Limit a value above a minimum threshold. 
        /// </summary>
        /// <param name="a"> The value to limit. </param>
        /// <param name="min"> The minimum vaue threshold. </param>
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(float value, float min, float max) =>
            (value < min) ? min : (value > max) ? max : value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(float value, C_V2 range) =>
            Clamp(value, range.x, range.y);

        /// <summary>
        /// Convert a value within range A to a value within range B. 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="initalRange"></param>
        /// <param name="newRange"></param>
        /// <returns>value converted to the Range B scale. </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ConvertToRange(float value, C_Seq2 initalRange, C_Seq2 newRange)
        {
            return
                ((value - initalRange.E0) / (initalRange.E1 - initalRange.E0)) * (newRange.E1 - newRange.E0);
        }

        public static UnityEngine.Vector2 PerpendicularCW(UnityEngine.Vector2 v)
        {
            return C_M2X2.RotateC90(v);
        }

        public static UnityEngine.Vector2 PerpendicularCCW(UnityEngine.Vector2 v)
        {
            return C_M2X2.RotateCC90(v);
        }
    }
}
