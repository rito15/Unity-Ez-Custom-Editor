#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-06-04 PM 8:59:26
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class Vector3IntExtensions
    {
        public static Vector3IntField DrawField(this Vector3Int @this, string label, Vector3IntField vector3IntField)
        {
            return vector3IntField
                .SetData(label, @this)
                .DrawLayout();
        }
        public static Vector3IntField DrawField(this Vector3Int @this, string label)
            => DrawField(@this, label, Vector3IntField.Default);


        public static Vector3IntField DrawFieldRef(ref this Vector3Int @this, string label, Vector3IntField vector3IntField)
        {
            return vector3IntField
                .SetData(label, @this)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static Vector3IntField DrawFieldRef(ref this Vector3Int @this, string label)
            => DrawFieldRef(ref @this, label, Vector3IntField.Default);
    }
}

#endif