using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 날짜 : 2021-06-09 AM 1:55:54
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    /// <summary> 
    /// 수학 계산 확장 메소드 모음
    /// </summary>
    public static class MathExtensions
    {
        /***********************************************************************
        *                               Precisions
        ***********************************************************************/
        #region .

        /// <summary> 소수점 자리수 제한 </summary>
        public static float SetPrecision(ref this float @this, in int precision)
        {
            float cipher = Mathf.Pow(10f, precision);
            @this = Mathf.Round(@this * cipher) / cipher;
            return @this;
        }

        /// <summary> 소수점 자리수 제한 </summary>
        public static double SetPrecision(ref this double @this, in int precision)
        {
            double cipher = Math.Pow(10f, precision);
            @this = Math.Round(@this * cipher) / cipher;
            return @this;
        }

        /// <summary> 소수점 자리수 제한 </summary>
        public static Vector2 SetPrecision(ref this Vector2 @this, in int precision)
        {
            @this.x.SetPrecision(precision);
            @this.y.SetPrecision(precision);
            return @this;
        }

        /// <summary> 소수점 자리수 제한 </summary>
        public static Vector3 SetPrecision(ref this Vector3 @this, in int precision)
        {
            @this.x.SetPrecision(precision);
            @this.y.SetPrecision(precision);
            @this.z.SetPrecision(precision);
            return @this;
        }

        /// <summary> 소수점 자리수 제한 </summary>
        public static Vector4 SetPrecision(ref this Vector4 @this, in int precision)
        {
            @this.x.SetPrecision(precision);
            @this.y.SetPrecision(precision);
            @this.z.SetPrecision(precision);
            @this.w.SetPrecision(precision);
            return @this;
        }
        #endregion
    }
}