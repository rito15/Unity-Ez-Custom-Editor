#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-06-04 PM 8:59:26
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class ObjectExtensions
    {
        public static ObjectField<T> DrawField<T>(this T @this, string label, ObjectField<T> objectField)
            where T : UnityEngine.Object
        {
            return objectField
                .SetData(label, @this)
                .DrawLayout();
        }
        public static ObjectField<T> DrawField<T>(this T @this, string label) where T : UnityEngine.Object
            => DrawField(@this, label, ObjectField<T>.Default);
    }
}

#endif