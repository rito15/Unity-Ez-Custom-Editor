#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-06-04 PM 8:59:26
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class Vector4Extensions
    {
        public static Vector4Field DrawField(this Vector4 @this, string label, Vector4Field vector4Field)
        {
            return vector4Field
                .SetData(label, @this)
                .DrawLayout();
        }
        public static Vector4Field DrawField(this Vector4 @this, string label)
            => DrawField(@this, label, Vector4Field.Default);


        public static Vector4Field DrawFieldRef(ref this Vector4 @this, string label, Vector4Field vector4Field)
        {
            return vector4Field
                .SetData(label, @this)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static Vector4Field DrawFieldRef(ref this Vector4 @this, string label)
            => DrawFieldRef(ref @this, label, Vector4Field.Default);
    }
}

#endif