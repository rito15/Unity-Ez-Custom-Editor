#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-06-04 PM 8:59:26
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class Vector2IntExtensions
    {
        public static Vector2IntField DrawField(this Vector2Int @this, string label, Vector2IntField vector2IntField)
        {
            return vector2IntField
                .SetData(label, @this)
                .DrawLayout();
        }
        public static Vector2IntField DrawField(this Vector2Int @this, string label)
            => DrawField(@this, label, Vector2IntField.Default);


        public static Vector2IntField DrawFieldRef(ref this Vector2Int @this, string label, Vector2IntField vector2IntField)
        {
            return vector2IntField
                .SetData(label, @this)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static Vector2IntField DrawFieldRef(ref this Vector2Int @this, string label)
            => DrawFieldRef(ref @this, label, Vector2IntField.Default);
    }
}

#endif