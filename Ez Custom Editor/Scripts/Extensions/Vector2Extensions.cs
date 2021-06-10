#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-06-04 PM 8:59:26
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class Vector2Extensions
    {
        public static Vector2Field DrawField(this Vector2 @this, string label, Vector2Field vector2Field)
        {
            return vector2Field
                .SetData(label, @this)
                .DrawLayout();
        }
        public static Vector2Field DrawField(this Vector2 @this, string label)
            => DrawField(@this, label, Vector2Field.Default);


        public static Vector2Field DrawFieldRef(ref this Vector2 @this, string label, Vector2Field vector2Field)
        {
            return vector2Field
                .SetData(label, @this)
                .DrawLayout()
                .GetValue(out @this);
        }
        public static Vector2Field DrawFieldRef(ref this Vector2 @this, string label)
            => DrawFieldRef(ref @this, label, Vector2Field.Default);

    }
}

#endif