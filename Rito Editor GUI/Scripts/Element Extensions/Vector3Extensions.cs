#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-06-04 PM 8:59:26
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class Vector3Extensions
    {
        public static Vector3Field DrawField(this Vector3 @this, string label, Vector3Field vector3Field)
        {
            return vector3Field
                .SetData(label, @this)
                .DrawLayout();
        }
        public static Vector3Field DrawField(this Vector3 @this, string label)
            => DrawField(@this, label, Vector3Field.Default);


        public static Vector3Field DrawFieldRef(ref this Vector3 @this, string label, Vector3Field vector3Field)
        {
            return vector3Field
                .SetData(label, @this)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static Vector3Field DrawFieldRef(ref this Vector3 @this, string label)
            => DrawFieldRef(ref @this, label, Vector3Field.Default);
    }
}

#endif