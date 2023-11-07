using System.Runtime.CompilerServices;
using UnityEngine;

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
        /// <param name="value"> The value to limit. </param>
        /// <param name="max"> The maximum that value can be.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float value, float max) =>
            (value > max) ? max : value;

        /// <summary>
        /// Limit a value above a minimum threshold. 
        /// </summary>
        /// <param name="value"> The value to limit. </param>
        /// <param name="min"> The minimum vaue threshold. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float value, float min) =>
            (value < min) ? min : value;

        /// <summary>
        /// Return the absolute value of a number.
        /// </summary>
        /// <param name="value"> The value to absolute. </param>
        /// <returns> The value with the sign set to positive. </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(float value) =>
            ((value < 0) ? -1 : 1) * value;

        /// <summary>
        /// Returns a value clamped within the range [Min, Max]. 
        /// </summary>
        /// <param name="value"> The inital value to clamp. </param>
        /// <param name="min">   The minimum range. </param>
        /// <param name="max">   The maximum range. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(float value, float min, float max) =>
            (value < min) ? min : (value > max) ? max : value;

        /// <summary>
        /// Returns a value clamped within the range [Min, Max]. 
        /// </summary>
        /// <param name="value"> The inital value to clamp. </param>
        /// <param name="range">   The range [Min, Max]. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(float value, C_V2 range) =>
            Clamp(value, range.x, range.y);

        /// <summary>
        /// Returns a value clamped within the range [Min, Max]. 
        /// </summary>
        /// <param name="value"> The inital value to clamp. </param>
        /// <param name="range">   The minimum range [Min, Max]. </param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(float value, C_Seq2 range) =>
            Clamp(value, range.E0, range.E1);

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
            float numerator = (value - initalRange.E0);
            float denominator = (initalRange.E1 - initalRange.E0);
            float newR = (newRange.E1 - newRange.E0);
            return numerator/denominator * newR;
        }

        /// <summary>
        /// Returns the vector perpendicular to the passed in vector.
        /// </summary>       
        public static Vector2 PerpendicularCW(Vector2 value)
        {
            return C_M2X2.RotateC90(value);
        }

        /// <summary>
        /// Returns the vector perpendicular to the passed in vector.
        /// </summary>
        public static Vector2 PerpendicularCCW(Vector2 v)
        {
            return C_M2X2.RotateCC90(v);
        }

        /// <summary>
        /// Returns the vector perpendicular to the passed in vector.
        /// </summary>
        public static C_V2 PerpendicularCW(C_V2 v)
        {
            return C_M2X2.Rot90C * v;
        }

        /// <summary>
        /// Returns the vector perpendicular to the passed in vector.
        /// </summary>
        public static C_V2 PerpendicularCCW(C_V2 v)
        {
            return C_M2X2.Rot90CC * v;
        }

        public static float GetLineMidpoint(C_P2D a, C_P2D b)
        {
            return ((C_V2)(b - a)).Magnitude / 2; 
        }

        public static float GetLineMidpoint(C_V2 vec)
        {
            return vec.Magnitude / 2;
        }
    }
}
